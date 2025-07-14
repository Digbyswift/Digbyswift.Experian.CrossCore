# Digbyswift - Experian CrossCore

[![NuGet version (Digbyswift.Experian.CrossCore)](https://img.shields.io/nuget/v/Digbyswift.Experian.CrossCore.svg)](https://www.nuget.org/packages/Digbyswift.Experian.CrossCore/)
[![Build and publish package](https://github.com/Digbyswift/Digbyswift.Experian.CrossCore/actions/workflows/dotnet-build-publish.yml/badge.svg)](https://github.com/Digbyswift/Digbyswift.Experian.CrossCore/actions/workflows/dotnet-build-publish.yml)

## Overview

This is a roll-your-own implementation of the Experian API AML (Anti-Money Laundering) function set. The offical API .NET library
is https://github.com/experianplc/experian-dotnet but at the time of writing, this does not cater for AML checks.

## Request implementation

The client is expected to be registered at application start up along with the configuration:

```
composition.Register<IExperianCrossCoreConfig, ExperianCrossCoreConfig>(Lifetime.Singleton);
composition.Register<ExperianClient>(Lifetime.Singleton);

```

Requests can then be called as such:

```
var payload = new RequestPayload();

var result = await _client.PostAsync<AmlResponse>(url, payload);

```


## Response implementation

Assuming that configuration is correct, all requests should return an AmlResponse object:

```
public class AmlResponse
{
    public ResponseHeader ResponseHeader { get; set; }
}
```

The response header will include all the data required to determine whether the request was acceted or not.

Assuming the request hasn't caused an application error, there are a range of decisions that an AML check can
return. The only decision denoting a successful check is "Success".

Other decisions can be:

 - No decision
 - Stop
 - Refer


## Admin dashboard

The Experian AML dashboard can be found:

https://uk-api.experian.com/decisionanalytics

