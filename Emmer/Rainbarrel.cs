namespace Emmer;

public class Rainbarrel : Container
{
    
    public Rainbarrel(Rainbarrelsize capacity) : base(Containerversions.Rainbarrel)
    {
        switch (capacity)
        {
            case Rainbarrelsize.Size80:
                Capacity = (int)Rainbarrelsize.Size80;
                break;
            case Rainbarrelsize.Size100:
                Capacity = (int)Rainbarrelsize.Size100;
                break;
            case Rainbarrelsize.Size120:
                Capacity = (int)Rainbarrelsize.Size120;
                break;
        }
    }
}