namespace DesignPatternsDay.Patterns.Observer
{
    public class ProductObservable : IObservable
    {
        private readonly List<IObserver> _observers = new();
      
        public void Subscribe(IObserver observer)=>_observers.Add(observer);
      
        public void Unsubscribe(IObserver observer)=>_observers.Remove(observer);
        
        public void Notify(string eventType, object data)
        {
            foreach (var observer in _observers)
                observer.Update(eventType, data);
        }
        public void CheckStock(string productName,int stock)
        {
            if(stock==0)
            {
                Notify("OutOfStock", productName);
            }
            else if(stock<=5)
                Notify("LowStock", $"{productName} - Kalan: {stock}");
        }
    }
}
