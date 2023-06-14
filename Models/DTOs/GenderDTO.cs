using Azure.Core;

namespace CtrlLove.Models.DTOs;

public class GenderDTO
{
    public string Name { get; set; }
    private int Value { get; set; }

    public static Task<List<GenderDTO>> GetAllGenders()
    {
        var names = Enum.GetNames(typeof(Gender));
        return names.Select((name, i) => new GenderDTO { Name = name, Value = i });
    }
}