using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zadaca420212022.Models
{
    public enum Edicija
    {
        [Display(Name = "Spider-man")]
        Spiderman, 
        [Display(Name = "X-Men")]
        XMen,
        [Display(Name = "The Avengers")]
        Avengers,
        [Display(Name = "Fantastic Four")]
        FF
    }

    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid
                         (object date, ValidationContext validationContext)
        {
            if ((DateTime)date < DateTime.Now.AddYears(-100))
                return new ValidationResult("Datum izdavanja stripa ne smije biti stariji od 100 godina u prošlosti!");
            else if ((DateTime)date > DateTime.Now.AddMonths(6))
                return new ValidationResult("Datum izdavanja stripa ne smije biti noviji od 3 mjeseca u budućnosti!");
            else
                return ValidationResult.Success;
        }
    }

    public class Strip
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [EnumDataType(typeof(Edicija))]
        [DisplayName("Edicija stripa:")]
        public Edicija EdicijaStripa { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Naziv stripa:")]
        public string NazivStripa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ValidateDate]
        [DisplayName("Datum dospjeća:")]
        public DateTime DatumDospjeća { get; set; }

        [DisplayName("Opis stripa:")]
        public string OpisStripa { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Strip se ocjenjuje ocjenom između 1 i 5!")]
        [DisplayName("Ocjena:")]
        public int Ocjena { get; set; }
    }
}
