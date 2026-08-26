using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize(Roles = "Admin,Dentist")]
public class TreatmentController : Controller
{
    public async Task<IActionResult> Index()
    {

        return View();
    }
}
