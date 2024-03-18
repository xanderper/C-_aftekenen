using Emmer;

namespace EmmerTest;

public class Testen
{
    [TestCase(12, 12)]
    [TestCase(20, 20)]
    [TestCase(5, 12)]
    [TestCase(10, 10)]
    [TestCase(2500, 2500)]
    [TestCase(2501, 12)]
    [TestCase(50, 50)]
    [TestCase(100, 100)]
    [TestCase(500, 500)]
    
    public void Testenemmer(int input, int result)
    {
        Bucket emmer = new Bucket(input);

        int answer = emmer.Capacity;
        
        Assert.AreEqual(result,answer);
    }
    
    [TestCase(-5, "De waarde moet positief zijn en geen 0")]
    [TestCase(0, "De waarde moet positief zijn en geen 0")]
    public void Testexeption(int input, string result)
    {
        var exception = Assert.Throws<NegativeNumberException>(() => new Bucket(input));
        
        Assert.AreEqual(result,exception.Message);
    }
    
    
    [TestCase(12)]
    public void Testenemmergeeninput(int result)
    {
        Bucket emmer = new Bucket();

        int answer = emmer.Capacity;
        
        Assert.AreEqual(result,answer);
    }

    [TestCase(159)]
    public void Oilbarreltesten(int result)
    {
        Oilbarrel oilbarrel = new Oilbarrel();

        int answer = oilbarrel.Capacity;

        Assert.AreEqual(result, answer);
    }
    
    [TestCase(Rainbarrelsize.Size80,80)]
    [TestCase(Rainbarrelsize.Size100,100)]
    [TestCase(Rainbarrelsize.Size120,120)]
    public void Rainbarreltesten(Rainbarrelsize input,int result)
    {
        Rainbarrel rainbarrel = new Rainbarrel(input);
        
        int answer = rainbarrel.Capacity;
        
        Assert.AreEqual(result,answer);
    }
    
    //Testcases voor de events
    [TestCase(12,12,true)]
    [TestCase(12,13,false)]
    [TestCase(12,11,false)]
    public void Fulltesten(int input,int amount,bool result)
    {
        bool tested = false;
        
        Bucket emmer = new Bucket(input);

        emmer.FullEvent += (o, e) => tested = true;
        
        emmer.Fill(amount);
        
        Assert.AreEqual(result, tested);
    }
    
    
    [TestCase(12,12,false)]
    [TestCase(12,13,true)]
    [TestCase(12,11,false)]
    public void Overflowtesten(int input, int amount, bool result)
    {
        bool tested = false;
        
        Bucket emmer = new Bucket(input);

        emmer.OverflowEvent += (o, e) => tested = true;
        
        emmer.Fill(amount);
        
        Assert.AreEqual(result, tested);
    }
    
    [TestCase(12,12,false)]
    [TestCase(12,13,true)]
    [TestCase(12,11,false)]
    public void Overflowedtesten(int input, int amount, bool result)
    {
        bool tested = false;
        
        Bucket emmer = new Bucket(input);
        

        emmer.OverflowEvent += (o, e) =>
        {
            OverflowedEventArgs args = new OverflowedEventArgs();
            
            emmer.OnOverflowedEvent(args);
        };

        emmer.OverflowedEvent += (sender, args) => tested = true;
        
        emmer.Fill(amount);
        
        Assert.AreEqual(result, tested);
        
    }
}


    
    
