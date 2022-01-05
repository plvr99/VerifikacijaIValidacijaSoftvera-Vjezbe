using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum Planeta
    {
        [Display(Name = "Zemlja")]
        Zemlja,
        [Display(Name = "Mars")]
        Mars,
        [Display(Name = "Pluton")]
        Pluton
    }
    public class SvemirskiBrod
    {
        [Key]
        [Required]
        [RegularExpression(@"[A-Z]{4}-[0-9]{4}",
         ErrorMessage = "Serijski broj ima format AAAA-1111!")]
        [DisplayName("Serijski broj:")]
        public string SerijskiBroj { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Naziv broda:")]
        public string Naziv { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Postoje samo kvadranti od 1 do 4!")]
        [DisplayName("Kvadrant:")]
        public int Kvadrant { get; set; }

        [Required]
        [EnumDataType(typeof(Planeta))]
        [DisplayName("Planeta:")]
        public Planeta Planeta { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Brod može biti starosti od 0 do 100 godina!")]
        [DisplayName("Starost broda:")]
        public int Starost { get; set; }

        [Required]
        [DisplayName("Brod prevozi vanzemaljce")]
        public bool Vanzemaljci { get; set; }

        [Required]
        [DisplayName("Brod leti približno svjetlosnom brzinom")]
        public bool SvjetlosnaBrzina { get; set; }

        [DisplayName("Vaša profilna slika (opcionalno):")]
        public string Slika { get; set; }
    }
}
