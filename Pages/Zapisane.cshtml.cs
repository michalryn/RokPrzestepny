using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RokPrzestepny.Models;
using Newtonsoft.Json;

namespace RokPrzestepny.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<Osoba>? Osoby { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (!string.IsNullOrEmpty(Data))
            {
                Osoby = JsonConvert.DeserializeObject<List<Osoba>>(Data);
            }
        }
    }
}
