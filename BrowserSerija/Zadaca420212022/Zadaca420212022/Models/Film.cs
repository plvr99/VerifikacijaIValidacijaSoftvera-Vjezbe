using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zadaca420212022.Models
{
    public enum Vrsta
    {
        [Display(Name = "Hollywoodski")]
        Hollywood,
        [Display(Name = "Festivalski")]
        Festival,
        [Display(Name = "Domaći")]
        Domaći,
        [Display(Name = "Kratki")]
        Kratki
    }

    public class ValidateDate4 : ValidationAttribute
    {
        protected override ValidationResult IsValid
                         (object date, ValidationContext validationContext)
        {
            if ((DateTime)date < DateTime.Now.AddYears(-1))
                return new ValidationResult("Datum izlaska filma ne smije biti stariji od godinu dana!");
            else if ((DateTime)date > DateTime.Now)
                return new ValidationResult("Nije dozvoljen unos filmova koji će biti objavljeni u budućnosti!");
            else
                return ValidationResult.Success;
        }
    }

    public class Film
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [EnumDataType(typeof(Vrsta))]
        [DisplayName("Vrsta filma:")]
        public Vrsta VrstaFilma { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Naziv filma:")]
        public string NazivFilma { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidateDate4]
        [DisplayName("Datum izlaska:")]
        public DateTime DatumIzlaska { get; set; }

        [DisplayName("Glumci:")]
        public string Glumci { get; set; }

        [Required]
        [Range(1, 240, ErrorMessage = "Dozvoljeno trajanje filma je između 1 min i 4 h!")]
        [DisplayName("Dužina trajanja (u minutama):")]
        public int DužinaTrajanja { get; set; }
    }
}
