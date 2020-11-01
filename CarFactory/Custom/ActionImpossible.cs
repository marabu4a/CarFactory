namespace CarFactory.Custom
{
    public class ActionImpossible : IActionPossible
    {
        private string _reason;
        
        public bool IsPossible => false;

        public string Reason => _reason;

        public ActionImpossible(string reason)
        {
            _reason = reason;
        }
        
    }
}