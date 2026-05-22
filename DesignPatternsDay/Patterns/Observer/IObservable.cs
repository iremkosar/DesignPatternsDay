namespace DesignPatternsDay.Patterns.Observer
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify(string eventType, object data);
    }
}
