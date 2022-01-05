using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum Zemlja
    {
        [Display(Name = "Bosna i Hercegovina")]
        BiH,
        [Display(Name = "Turska")]
        Turska,
        [Display(Name = "Malezija")]
        Malezija
    }
    public class Cvijet
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Vrsta cvijeća:")]
        public string Vrsta { get; set; }

        [Key]
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Latinski naziv vrste:")]
        public string LatinskiNaziv { get; set; }

        [Required]
        [EnumDataType(typeof(Zemlja))]
        [DisplayName("Zemlja porijekla:")]
        public Zemlja ZemljaPorijekla { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatumIzProšlosti(ErrorMessage = "Datum dospjeća mora biti u prošlosti!")]
        [DisplayName("Datum dospjeća:")]
        public DateTime DatumDospjeca { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Kolićina mora biti pozivitan broj!")]
        [DisplayName("Količina:")]
        public int Kolicina { get; set; }
        
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Cvjećara u koju je otpremljeno:")]
        public string Cvjecara { get; set; }

        [DisplayName("Cvijeće može stajati")]
        public bool MozeStajati { get; set; }

        [Required]
        [Range(1, 14, ErrorMessage = "Cvijet ne može biti svjež manje od 1 dana niti više od 14 dana!")]
        [DisplayName("Dani svježine:")]
        public int DaniSvjezine { get; set; }
    }
}
