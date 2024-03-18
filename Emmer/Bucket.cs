namespace Emmer;

public class Bucket : Container
{
    private const int BaseCapacity = 12;
    
    public Bucket() : this(BaseCapacity)
    {
        
    }
    
    public Bucket(int capacity) : base(Containerversions.Bucket) 
    {
        if (capacity > 2500 || capacity < 10)
        {
            if (capacity <= 0)
            {
                throw new NegativeNumberException("De waarde moet positief zijn en geen 0");
            }
            Console.WriteLine("Deze waarde is niet toegestaan");
            Capacity = BaseCapacity;
        }
        else
        {
            Capacity = capacity; 
        }
    }
    
    public void FillWithOtherBucket(Bucket b)
    {
        int availableSpace = Capacity - Content;
        
        // geef de naam weer van de emmer waarin de inhoud zit en de inhoud van de emmer. 


        if (b.Content <= availableSpace)
        {
            Content += b.Content;
            b.Content = 0;
            Console.WriteLine("In deze emmer zit: " + Content);
            Console.WriteLine("In de andere emmer zit: " + b.Content);
        } else
        {
            Content += availableSpace;
            b.Content -= availableSpace;
            Console.WriteLine("In deze emmer zit: " + Content);
            Console.WriteLine("In de andere emmer zit: " + b.Content);
        }
        
    }
}