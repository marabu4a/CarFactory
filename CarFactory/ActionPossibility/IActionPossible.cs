namespace CarFactory.ActionPossibility
{
    public interface IActionPossible
    {
        bool IsPossible { get; }
        
        string Reason { get; }
    }
}