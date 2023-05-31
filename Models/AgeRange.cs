namespace CtrlLove.Models;

public class AgeRange
{
    private const byte BaseAgeRangeBottom = 18;
    private const byte BaseAgeRangeTop = 100;
    private const byte MinimumAge = 18;
    private const byte MaximumAge = 100;
    
    public byte Bottom { get; set; }
    public byte Top { get; set; }

    public AgeRange(byte bottom, byte top)
    {
        Bottom = Math.Clamp(bottom, MinimumAge, MaximumAge);
        Top = Math.Clamp(top, MinimumAge, MaximumAge);
    }

    public AgeRange()
    {
        Bottom = BaseAgeRangeBottom;
        Top = BaseAgeRangeTop;
    }
}