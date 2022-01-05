using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum VrstaNekretnine
    {
        [Display(Name = "Kuća")]
        Kuća,
        [Display(Name = "Stan")]
        Stan,
        [Display(Name = "Zemljište")]
        Zemljište
    }
    public class Nekretnina
    {
        [Key]
        [Required]
        [RegularExpression(@"[A-Z]+",
         ErrorMessage = "Šifra se smije sastojati samo od velikih slova!")]
        [DisplayName("Šifra nekretnine:")]
        public string Sifra { get; set; }

        [Required]
        [EnumDataType(typeof(VrstaNekretnine))]
        [DisplayName("Vrsta nekretnine:")]
        public VrstaNekretnine Vrsta { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Lokacija:")]
        public string Lokacija { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Kvadratura mora biti pozitivan broj!")]
        [DisplayName("Kvadratura:")]
        public double Kvadratura { get; set; }

        [DisplayName("Imovinsko-pravni odnosi su riješeni")]
        public bool ZKCist { get; set; }

        [DisplayName("Nekretnina posjeduje pristupni put")]
        public bool PristupniPut { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Broj soba mora biti pozitivan broj!")]
        [DisplayName("Broj soba:")]
        public int BrojSoba { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Zaduženi agent:")]
        public string ZaduzeniAgent { get; set; }
    }
}
