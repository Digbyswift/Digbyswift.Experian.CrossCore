namespace Digbyswift.Experian.CrossCore.AmlResponseObjects;

public class OverallResponse
{
#if NETFRAMEWORK
    public string Decision { get; set; }
    public string DecisionText { get; set; }
    public string[] DecisionReasons { get; set; }
    public object[] RecommendedNextActions { get; set; }
    public object[] SpareObjects { get; set; }
#else
    public string? Decision { get; set; }
    public string? DecisionText { get; set; }
    public string[] DecisionReasons { get; set; } = [];
    public object[] RecommendedNextActions { get; set; } = [];
    public object[] SpareObjects { get; set; } = [];
#endif
}
