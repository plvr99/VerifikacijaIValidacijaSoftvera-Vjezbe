using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum VrstaPrijave
    {
        [Display(Name = "Nesavjesno ponašanje")]
        Nesavjesnost,
        [Display(Name = "Opasnost po okolinu")]
        Opasnost,
        [Display(Name = "Ostalo")]
        Ostalo
    }

    public class DatumIzProšlosti : RangeAttribute
    {
        public DatumIzProšlosti() : base(typeof(DateTime), DateTime.MinValue.ToString(), DateTime.Now.ToString())
        {

        }
    }

    public class Prijava
    {
        [Key]
        [Required]
        [RegularExpression(@"[0-9]+-[0-9]+-[0-9]+",
         ErrorMessage = "Neispravan format za broj protokola (0-0-0)!")]
        [DisplayName("Broj protokola:")]
        public string BrojProtokola { get; set; }        

        [DisplayName("Ime i prezime podnosioca prijave:")]
        public string ImeIPrezime { get; set; }

        [Required]
        [DisplayName("Želim ostati anoniman")]
        public bool Anonimnost { get; set; }

        [Required]
        [EnumDataType(typeof(VrstaPrijave))]
        [DisplayName("Vrsta prekršaja:")]
        public VrstaPrijave VrstaPrijave { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Lokacija prekršaja:")]
        public string Lokacija { get; set; }

        [Required]
        [Range(1000, 100000, ErrorMessage = "Validni poštanski brojevi su između 1000 i 100000!")]
        public int PostanskiBroj { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Opis prekršaja:")]
        public string Opis { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatumIzProšlosti(ErrorMessage = "Datum prekršaja mora biti u prošlosti!")]
        [DisplayName("Datum prekršaja:")]
        public DateTime? DatumPrekrsaja { get; set; }

        
    }
}
