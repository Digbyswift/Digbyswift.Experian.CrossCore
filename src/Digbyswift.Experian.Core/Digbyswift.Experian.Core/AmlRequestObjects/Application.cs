namespace Digbyswift.Experian.Core.AmlRequestObjects;

public class Application
{
    public Applicant[] Applicants { get; set; }
    public string Type { get; set; } = "INDIVIDUAL";
}