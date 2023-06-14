using Azure.Core;

namespace CtrlLove.Models.DTOs;

public class GenderDTO
{
    public string Name { get; set; }
    public int Value { get; set; }

    public static List<GenderDTO> GetAllGenders()
    {
        var names = Enum.GetNames(typeof(Gender));
        return names.Select((name, i) => new GenderDTO { Name = name, Value = i }).ToList();
    }
}