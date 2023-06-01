namespace CtrlLove.Models;

public struct AgeRange
{
    private const byte MinimumAge = 18;
    private const byte MaximumAge = 100;

    private byte Bottom { get; set; }
    private byte Top { get; set; }

    public AgeRange(byte bottom, byte top)
    {
        Bottom = Math.Clamp(bottom, MinimumAge, MaximumAge);
        Top = Math.Clamp(top, MinimumAge, MaximumAge);
    }

    public AgeRange()
    {
        Bottom = MinimumAge;
        Top = MaximumAge;
    }

    public bool IsInRange(int number)
    {
        return number <= Top && number >= Bottom;
    }
}