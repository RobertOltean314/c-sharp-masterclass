const int threshhold = 30_000;

var emailChangeNotifier = new EmailPriceChangeNotifier(threshhold);
var pushChangeNotifier = new PushPriceChangeNotifier(threshhold);

var goldPriceReader = new GoldPriceReader();
goldPriceReader.AttachObserver(emailChangeNotifier);
goldPriceReader.AttachObserver(pushChangeNotifier);

for (int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

public class GoldPriceReader : IObservable<decimal>
{
    private int _currentGoldPrice;
    private readonly List<IObserver<decimal>> _observers = new List<IObserver<decimal>>();

    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(20_000, 50_000);

        NotifyObservers();
    }

    public void AttachObserver(IObserver<decimal> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentGoldPrice);
        }
    }
}

public class EmailPriceChangeNotifier : IObserver<decimal>
{
    private readonly decimal _notificationThreshhold;
    public EmailPriceChangeNotifier(decimal notificationThreshhold)
    {
        _notificationThreshhold = notificationThreshhold;
    }
    public void Update(decimal price)
    {
        if (price > _notificationThreshhold)
        {
            Console.WriteLine($"The gold price exceeded {_notificationThreshhold} " +
                $"and is now {price}. " +
                $"You receive this notification on E-Mail");
        }
    }
}

public class PushPriceChangeNotifier : IObserver<decimal>
{
    private readonly decimal _notificationThreshhold;
    public PushPriceChangeNotifier(decimal notificationThreshhold)
    {
        _notificationThreshhold = notificationThreshhold;
    }
    public void Update(decimal price)
    {
        if (price > _notificationThreshhold)
        {
            Console.WriteLine($"The gold price exceeded {_notificationThreshhold} " +
                $"and is now {price} " +
                $"You receive this notification via SMS.");
        }
    }
}

public interface IObserver<TData>
{
    void Update(TData data);
}

public interface IObservable<TData>
{
    void AttachObserver(IObserver<TData> observer);
    void DetachObserver(IObserver<TData> observer);
    void NotifyObservers();
}