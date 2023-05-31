namespace CtrlLove.Models;

public class AgeRange
{
    private const byte BaseAgeRangeBottom = 18;
    private const byte BaseAgeRangeTop = 100;
    
    public byte Bottom { get; set; }
    public byte Top { get; set; }

    public AgeRange(byte bottom, byte top)
    {
        Bottom = bottom;
        Top = top;
    }

    public AgeRange()
    {
        Bottom = BaseAgeRangeBottom;
        Top = BaseAgeRangeTop;
    }
}