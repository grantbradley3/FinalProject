using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using RedsMVC_API.Models;
using RedsMVC_API.Services;
using System.Text.Json;

namespace RedsMVC_API.Controllers
{
    public class PlayerController : Controller
    {
        public async Task<IActionResult> Index(string query)
        {
            var cincinattiApi = new CincinattiApi();

            var root = await cincinattiApi.GetPlayers(query);

            return View(root);
        }
    }
}
