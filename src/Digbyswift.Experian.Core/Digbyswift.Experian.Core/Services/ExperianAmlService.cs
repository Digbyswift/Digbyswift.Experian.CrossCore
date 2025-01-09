using System;
using System.Configuration;
using System.Threading.Tasks;
using Digbyswift.Experian.Core.AmlRequestObjects;
using Digbyswift.Experian.Core.Extensions;
using Serilog;

namespace Digbyswift.Experian.Core.Services;

public class ExperianAmlService : IAmlService
{
    private readonly ExperianClient _client;
    private readonly Endpoints _endpoints;

#if NETFRAMEWORK
    public ExperianAmlService(ExperianClient client)
    {
        _client = client;
        _endpoints = new Endpoints();
    }
#else
    public ExperianAmlService(ExperianClient client, Endpoints endpoints)
    {
        _client = client;
        _endpoints = endpoints;
    }
#endif

    public RequestPayload CreatePayload(AmlCheckDto dto)
    {
        var payload = new RequestPayload();

        var contact = new Contact
        {
            Person = new Person(dto.Title, dto.FullName),
            Addresses =
            [
                new Address
                {
                    Street = dto.AddressLine1,
                    Postal = dto.PostCode,
                    PostTown = dto.TownCity,
                    County = dto.County
                }
            ]
        };

        if (!String.IsNullOrWhiteSpace(dto.Email))
        {
            contact.Emails =
            [
                new EmailAddress(dto.Email)
            ];
        }
        else
        {
            contact.Emails = [];
        }

        if (!String.IsNullOrWhiteSpace(dto.Telephone))
        {
            contact.Telephones =
            [
                new Telephone(dto.Telephone)
            ];
        }
        else
        {
            contact.Telephones = [];
        }

        payload.SetContact(contact);

        return payload;
    }

    public async Task<AmlCheckResult> PerformCheckAsync(RequestPayload payload)
    {
        try
        {
            Log.Debug("Posting payload: {message} #aml #experian", payload.Serialize());

            var result = await _client.PostAsync<AmlResponse>(_endpoints.AmlServiceUrl, payload);
            if (result?.ResponseHeader?.OverallResponse == null)
            {
                Log.Warning("Check failed: {message}, {payload} #aml #experian", result?.ResponseHeader?.ResponseMessage, payload.Serialize());
                return new(AmlCheckStatus.Error, null);
            }

            Log.Information("Check succeeded: {decision}, {requestId} #aml #experian", result.ResponseHeader.OverallResponse.Decision, result.ResponseHeader.ExpRequestId);

            switch (result.ResponseHeader.OverallResponse.Decision)
            {
                case null:
                case OverallDecision.NoDecision:
                case OverallDecision.Refer:
                case OverallDecision.Stop:
                    return new(AmlCheckStatus.Failed, result.ResponseHeader.ExpRequestId);
            }

            return AmlCheckResult.Success(result.ResponseHeader.ExpRequestId);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Check errored {payload} #aml #experian", payload.Serialize());
            return new(AmlCheckStatus.Error, null);
        }
    }
}
