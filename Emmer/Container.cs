namespace Emmer
{
    
    public class OverflowedEventArgs : EventArgs
    {
        public int Overflowedamount { get; set; }
    }

    public class AmountArgs : EventArgs
    {
        public int Amount { get; set; }
    }
    
    public delegate void OverflowDelegate(object sender, AmountArgs e);
    public delegate void FullDelegate(object sender, EventArgs e);
    public delegate void OverflowedDelegate(object sender, OverflowedEventArgs e);
    
    public abstract class Container
    {
        public int Capacity { get; protected set; }
        public int Content { get; protected set; }
        public Containerversions Type { get; protected set; }
        
        public OverflowDelegate OverflowEvent;
        public FullDelegate FullEvent;
        public OverflowedDelegate OverflowedEvent;

        public Container(Containerversions type)
        {
            Type = type;
        }

        public void Subscribe()
        {
            OverflowEvent += HandleOverflow;
            FullEvent += HandleFull;
            OverflowedEvent += HandleOverflowedEvent;
        }

        public void OnOverflow(AmountArgs e)
        {
            OverflowEvent?.Invoke(this, e);
        }

        public void OnFullEvent()
        {
            FullEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnOverflowedEvent(OverflowedEventArgs e)
        {
            OverflowedEvent?.Invoke(this, e);
        }

        public void Fill(int amount)
        {
            int filled = Content + amount;
            
            if (amount < 0)
            {
              Console.WriteLine("Negatieve waardes zijn niet toegestaan");
              return;
            }
            if (filled <= Capacity)
            {
                Content = filled;
                if (Content == Capacity)
                {
                    OnFullEvent();
                }
            }
            else
            {
                OnOverflow(new AmountArgs { Amount = amount });
            }
        }

        public void Empty()
        {
            Content = 0;
        }

        public void HandleOverflow(object sender, AmountArgs e)
        {
            Console.WriteLine("Hij gaat overstromen weet je zeker dat je dit wilt? (Y/N)");

            string userInput = Console.ReadLine();

            if (userInput != null && userInput.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                OverflowedEventArgs args = new OverflowedEventArgs();
                 
                args.Overflowedamount = Content + e.Amount - Capacity;
                
                Content = Capacity;
                
                OnOverflowedEvent(args);
            }
            else
            {
                Content = Capacity;
                OnFullEvent();
            }
        }

        public void HandleFull(object sender, EventArgs e)
        {
            Console.WriteLine($"{Type} is full.");
        }

        public void HandleOverflowedEvent(object sender, OverflowedEventArgs e)
        {
            Console.WriteLine($"{Type} is overstroomd met {e.Overflowedamount}");
            OnFullEvent();
        }
    }
}
