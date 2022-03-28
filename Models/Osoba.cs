using System.ComponentModel.DataAnnotations;

namespace RokPrzestepny.Models
{
    public class Osoba
    {
        [Display(Name = "Imię użytownika")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"),
            StringLength(100, ErrorMessage = "{0} może mieć maksymalnie {1} znaków")]
        public string? Imie { get; set; }

        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"),
            Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Rok { get; set; }
        
        public bool Przestepny;

        private void CzyPrzestepny()
        {
            if ((Rok % 4 == 0 && Rok % 100 != 0) || (Rok % 400 == 0))
                Przestepny = true;
            else
                Przestepny = false;
        }

        public string Message()
        {
            string message = "";
            if (Przestepny)
                message += "rok przestępny";
            else
                message += "rok nieprzestępny";
            return message;
        }
        public string AlertMessage()
        {
            CzyPrzestepny();
            string message = $"{Imie}: urodził się w {Rok} roku.";
            if (Przestepny)
                message += " To jest rok przestępny";
            else
                message += " To nie jest rok przestępny";
            return message;
        }
    }
}
