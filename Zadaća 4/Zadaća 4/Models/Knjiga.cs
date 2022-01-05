using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum Žanr
    {
        [Display(Name = "Dječija")]
        Dječija,
        [Display(Name = "Omladinska")]
        Omladinska,
        [Display(Name = "Politička")]
        Politička
    }

    public class Knjiga
    {
        [Key]
        [Required]
        [RegularExpression(@"[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*",
         ErrorMessage = "Neispravan format za ISBN!")]
        [DisplayName("ISBN broj:")]
        public String ISBN { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Naziv knjige mora imati barem 5 karaktera!")]
        [DisplayName("Naziv knjige:")]
        public String Naziv { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Ime autora knjige mora imati barem 5 karaktera!")]
        [DisplayName("Autor knjige:")]
        public String Autor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Datum izdavanja:")]
        public DateTime? DatumIzdavanja { get; set; }

        [Required]
        [EnumDataType (typeof(Žanr))]
        [DisplayName("Žanr:")]
        public Žanr Žanr { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Broj stranica mora biti veći od 0!")]
        [DisplayName("Broj stranica:")]
        public int BrojStranica { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Broj izdanja mora biti veći od 0!")]
        [DisplayName("Broj izdanja:")]
        public int Izdanje { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Ime izdavača mora imati barem 5 karaktera!")]
        [DisplayName("Izdavač:")]
        public string Izdavač { get; set; }
    }
}
