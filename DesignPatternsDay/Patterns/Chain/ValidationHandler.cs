namespace DesignPatternsDay.Patterns.Chain
{
    public abstract class ValidationHandler
    {
        private ValidationHandler _nextHandler;

        public ValidationHandler SetNext(ValidationHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }

        public virtual string Handle(object request)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(request);

            return null; 
        }
    }
}