using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RokPrzestepny.Models;
using Newtonsoft.Json;

namespace RokPrzestepny.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Osoba Osoba { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Osoba.CzyPrzestepny();
                TempData["Message"] = Osoba.AlertMessage();

                List<Osoba>? Osoby;
                var Data = HttpContext.Session.GetString("Data");
                if(Data != null)
                {
                    Osoby = JsonConvert.DeserializeObject<List<Osoba>>(Data);
                    Osoby.Add(Osoba);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Osoby));
                }
                else
                {
                    Osoby = new List<Osoba>();
                    Osoby.Add(Osoba);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Osoby));
                }
            }
            return Page();
        }
    }
}