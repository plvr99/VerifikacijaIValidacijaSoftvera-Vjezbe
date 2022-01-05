using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum TipUmjetnine
    {
        [Display(Name = "Ulje na platnu")]
        UljeNaPlatnu,
        [Display(Name = "Tempera")]
        Tempera,
        [Display(Name = "Olovka")]
        Olovka
    }
    public class Umjetnina
    {
        [Key]
        [Required]
        [RegularExpression(@"GR-[0-9]+",
         ErrorMessage = "Format galerije je GR-x, gdje x predstavlja proizvoljan broj cifri!")]
        [DisplayName("Kod galerije:")]
        public string KodGalerije { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Naziv umjetnine:")]
        public string Naziv { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Autor umjetnine:")]
        public string Autor { get; set; }

        [Required]
        [EnumDataType(typeof(TipUmjetnine))]
        [DisplayName("Tip umjetnine:")]
        public TipUmjetnine Tip { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatumIzProšlosti(ErrorMessage = "Datum registracije mora biti u prošlosti!")]
        [DisplayName("Datum registracije umjetnine:")]
        public DateTime? DatumRegistracije { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cijena mora biti veća od 0 KM!")]
        [DisplayName("Cijena umjetnine:")]
        public double Cijena { get; set; }

        [DisplayName("Umjetnina je historijsko naslijeđe")]
        public bool Naslijede { get; set; }

        [DisplayName("Želite li pokloniti umjetninu muzeju?")]
        public bool Poklon { get; set; }
    }
}
