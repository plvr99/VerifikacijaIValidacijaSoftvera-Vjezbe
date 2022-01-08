using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zadaca420212022.Models
{
    public enum Aktivnost
    {
        [Display(Name = "Trčanje")]
        Trčanje,
        [Display(Name = "Biciklizam")]
        Biciklizam,
        [Display(Name = "Piknik")]
        Piknik,
        [Display(Name = "Rekreacija")]
        Rekreacija
    }

    public class ValidateDate2 : ValidationAttribute
    {
        protected override ValidationResult IsValid
                         (object date, ValidationContext validationContext)
        {
            if ((DateTime)date < DateTime.Now.AddDays(-7))
                return new ValidationResult("Izleti stariji od 7 dana u prošlosti ne mogu se unositi!");
            else if ((DateTime)date > DateTime.Now)
                return new ValidationResult("Nije dozvoljen unos izleta u budućnosti!");
            else
                return ValidationResult.Success;
        }
    }

    public class Izlet
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [EnumDataType(typeof(Aktivnost))]
        [DisplayName("Aktivnost:")]
        public Aktivnost Aktivnost { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Lokacija:")]
        public string Lokacija { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidateDate2]
        [DisplayName("Datum aktivnosti:")]
        public DateTime DatumAktivnosti { get; set; }

        [DisplayName("Profesionalni trening")]
        public bool ProfesionalniTrening { get; set; }

        [Required]
        [Range(0.01, 24.0, ErrorMessage = "Dozvoljeno trajanje izleta je između 0.01 h i 24 h!")]
        [DisplayName("Trajanje (u h):")]
        public double Trajanje { get; set; }
    }
}
