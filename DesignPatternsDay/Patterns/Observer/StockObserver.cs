namespace DesignPatternsDay.Patterns.Observer
{
    public class StockObserver : IObserver
    {
        public void Update(string eventType, object data)
        {
            if(eventType=="LowStock")
            {
                Console.WriteLine($"⚠️ Düşük stok uyarısı: {data}");
            }
            else if(eventType=="OutOfStock")
            {
                Console.WriteLine($"❌ Stok tükendi: {data}");
            }
        }
    }
}
