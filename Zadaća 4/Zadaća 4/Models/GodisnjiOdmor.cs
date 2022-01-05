using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum Zaposlenik
    {
        [Display(Name = "Tony Stark")]
        Zaposlenik1,
        [Display(Name = "Bruce Banner")]
        Zaposlenik2,
        [Display(Name = "Peter Parker")]
        Zaposlenik3
    }

    public class DatumIzBudućnosti : RangeAttribute
    {
        public DatumIzBudućnosti() : base(typeof(DateTime), DateTime.Now.ToString(), DateTime.Now.AddMonths(12).ToString())
        {

        }
    }

    public class GodisnjiOdmor
    {
        [Key]
        [Required]
        [RegularExpression(@"[0-9]+-[0-9]+-[0-9]+",
         ErrorMessage = "Neispravan format za broj protokola (0-0-0)!")]
        [DisplayName("Broj protokola:")]
        public string BrojProtokola { get; set; }

        [Required]
        [EnumDataType(typeof(Zaposlenik))]
        [DisplayName("Zaposlenik:")]

        public Zaposlenik Zaposlenik { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatumIzBudućnosti(ErrorMessage = "Datum početka godišnjeg odmora mora biti u budućnosti, ne kasnije od godinu dana!")]
        [DisplayName("Datum početka godišnjeg odmora:")]
        public DateTime? Pocetak { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatumIzBudućnosti(ErrorMessage = "Datum kraja godišnjeg odmora mora biti u budućnosti, ne kasnije od godinu dana!")]
        [DisplayName("Datum kraja godišnjeg odmora:")]
        public DateTime? Kraj { get; set; }

        [Required]
        [Range(12, 36, ErrorMessage = "Broj dana mora biti između 12 i 36!")]
        [DisplayName("Broj dana godišnjeg odmora:")]
        public int BrojRadnihDana { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Postoje samo prvi i drugi dio godišnjeg odmora!")]
        [DisplayName("Dio godišnjeg odmora:")]
        public int Dio { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Zaposlenik koji je dao odobrenje:")]
        public string Odobrio { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Napomena:")]
        public string Napomena { get; set; }
    }
}
