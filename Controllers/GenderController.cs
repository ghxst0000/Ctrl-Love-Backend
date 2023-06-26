using CtrlLove.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CtrlLove.Controllers;


[Controller]
[Route("/api/v1/genders")]
public class GenderController : ControllerBase
{
    [HttpGet]
    public List<GenderDTO> GetAllGenders()
    {
        return GenderDTO.GetAllGenders();
    }
}