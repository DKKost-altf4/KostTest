using KostTest.DataBase;
using KostTest.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KostTest.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var t = _context.mouse_cordinates.ToList();
        }


        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPostClick([FromForm] int x, [FromForm] int y)
        {
            try
            {
                var mouseData = new
                {
                    X = x,
                    Y = y,
                    Timestamp = DateTime.UtcNow
                };

                var jsonData = JsonSerializer.Serialize(mouseData);

                var mouseCoords = new mouse_cordinates()
                {
                    DataMouse = jsonData
                };

                _context.mouse_cordinates.Add(mouseCoords);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true, x, y });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }
    }
}
