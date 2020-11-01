namespace CarFactory.Custom
{
    public interface IActionPossible
    {
        bool IsPossible { get; }
        
        string Reason { get; }
    }
}