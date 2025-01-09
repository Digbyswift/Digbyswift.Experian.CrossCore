namespace Digbyswift.Experian.CrossCore.AmlRequestObjects;

public class RequestPayload
{
    public string Source { get; } = "Web";

    public Control[] Control { get; set; } = [new()];
    public Contact[] Contacts { get; private set; } = [];
    public Application Application { get; private set; } = new();

    public void SetContact(Contact contact)
    {
        Contacts = [contact];
        Application.Applicants =
        [
            new Applicant()
            {
                ContactId = contact.Id
            }
        ];
    }
}
