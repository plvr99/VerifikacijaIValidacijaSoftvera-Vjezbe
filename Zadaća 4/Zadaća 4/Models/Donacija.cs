using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum VrstaDonacije
    {
        [Display(Name = "Društvo za pomaganje")]
        Drustvo,
        [Display(Name = "Lokalna zajednica")]
        Zajednica,
        [Display(Name = "Samostalno")]
        Samostalno
    }

    public class Donacija
    {
        [Key]
        [Required]
        [RegularExpression(@"[A-Z]{4}-[0-9]{4}",
         ErrorMessage = "Serijski broj ima format AAAA-1111!")]
        [DisplayName("Serijski broj:")]
        public string SerijskiBroj { get; set; }

        [Required]
        [EnumDataType(typeof(VrstaDonacije))]
        [DisplayName("Vrsta donacije:")]
        public VrstaDonacije Vrsta { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Opis sadržaja donacije:")]
        public string OpisSadrzaja { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Protuvrijednost mora biti veća od 0 KM!")]
        [DisplayName("Protuvrijednost:")]
        public double Protuvrijednost { get; set; }

        [DisplayName("Donacija je za posebnu prigodu")]
        public bool PosebnaPrigoda { get; set; }

        [DisplayName("Želim da se moje ime javno objavi")]
        public bool Javna { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Pošiljalac:")]
        public string Posiljalac { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Primalac:")]
        public string Primalac { get; set; }
    }
}
