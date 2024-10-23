
const int threshhold = 30_000;

var emailChangeNotifier = new EmailPriceChangeNotifier(threshhold);
var pushChangeNotifier = new PushPriceChangeNotifier(threshhold);

var goldPriceReader = new GoldPriceReader();
goldPriceReader.PriceRead += emailChangeNotifier.Update;
goldPriceReader.PriceRead += pushChangeNotifier.Update;


for (int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}


public class PriceReadEventArgs : EventArgs
{
    public decimal Price { get; }

    public PriceReadEventArgs(decimal price)
    {
        Price = price;
    }
}

public class GoldPriceReader
{
    // Define an event that gets triggered when the price is read
    public event EventHandler<PriceReadEventArgs>? PriceRead;

    // Method to simulate reading the current gold price
    public void ReadCurrentPrice()
    {
        // Simulate getting a random gold price between 20,000 and 50,000
        var currentGoldPrice = new Random().Next(20_000, 50_000);

        // Trigger the PriceRead event and pass the current price
        OnPriceRead(currentGoldPrice);
    }

    // Protected method to invoke the event
    protected virtual void OnPriceRead(decimal price)
    {
        PriceRead?.Invoke(this, new PriceReadEventArgs(price));
    }
}

public class EmailPriceChangeNotifier
{
    private readonly decimal _notificationThreshhold;

    public EmailPriceChangeNotifier(decimal notificationThreshhold)
    {
        _notificationThreshhold = notificationThreshhold;
    }

    // Event handler method that gets called when the PriceRead event is triggered
    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshhold)
        {
            Console.WriteLine($"The gold price exceeded {_notificationThreshhold} " +
                $"and is now {eventArgs.Price}. " +
                $"You receive this notification on E-Mail.");
        }
    }
}

public class PushPriceChangeNotifier
{
    private readonly decimal _notificationThreshhold;

    public PushPriceChangeNotifier(decimal notificationThreshhold)
    {
        _notificationThreshhold = notificationThreshhold;
    }

    // Event handler method that gets called when the PriceRead event is triggered
    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshhold)
        {
            Console.WriteLine($"The gold price exceeded {_notificationThreshhold} " +
                $"and is now {eventArgs.Price}. " +
                $"You receive this notification via SMS.");
        }
    }
}
