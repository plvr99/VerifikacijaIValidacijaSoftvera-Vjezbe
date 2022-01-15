using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zadaca420212022.Models
{
    public enum Žanr
    {
        [Display(Name = "Pop-rock")]
        PopRock,
        [Display(Name = "Jazz")]
        Jazz,
        [Display(Name = "Instrumental")]
        Instrumental,
        [Display(Name = "Koncertni soundtrack")]
        Koncert
    }

    public class ValidateDate3 : ValidationAttribute
    {
        protected override ValidationResult IsValid
                         (object date, ValidationContext validationContext)
        {
            if ((DateTime)date < DateTime.Now.AddYears(-1000))
                return new ValidationResult("Datum objavljivanja pjesme ne smije biti stariji od 1000 godina u prošlosti!");
            else if ((DateTime)date > DateTime.Now)
                return new ValidationResult("Nije dozvoljen unos datuma objavljivanja pjesama u budućnosti!");
            else
                return ValidationResult.Success;
        }
    }

    public class Pjesma
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [EnumDataType(typeof(Žanr))]
        [DisplayName("Žanr pjesme:")]
        public Žanr Žanr { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Naziv pjesme:")]
        public string NazivPjesme { get; set; }

        [DisplayName("Izvođač:")]
        public string Izvođač { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidateDate3]
        [DisplayName("Datum objavljivanja:")]
        public DateTime DatumObjavljivanja { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Dozvoljeni rating pjesme je između 1 i 10!")]
        [DisplayName("Rating:")]
        public int Rating { get; set; }
    }
}
