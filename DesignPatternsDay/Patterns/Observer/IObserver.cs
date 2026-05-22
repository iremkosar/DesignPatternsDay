namespace DesignPatternsDay.Patterns.Observer
{
    public interface IObserver
    {
        void Update(string eventType, object data);
    }
}
