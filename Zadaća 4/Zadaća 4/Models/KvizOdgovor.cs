using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum Recenzija
    {
        [Display(Name = "Ne želim ostaviti recenziju")]
        Opcija1,
        [Display(Name = "Kviz je veoma zanimljiv")]
        Opcija2,
        [Display(Name = "Kviz mi se ne sviđa")]
        Opcija3
    }
    public class KvizOdgovor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Ime i prezime:")]
        public string Ime { get; set; }

        [Required]
        [Range(1800, 2020, ErrorMessage = "Niste ispravno unijeli godište!")]
        [DisplayName("Godište rođenja:")]
        public int Godište { get; set; }

        [Required]
        [DisplayName("Ovo nije moj prvi odgovor")]
        public bool DodatniOdgovor { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email adresa nije ispravna!")]
        [DisplayName("Email adresa:")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Primaj novosti preko emaila")]
        public bool Novosti { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Broj telefona:")]
        public string BrojTelefona { get; set; }

        [Required]
        [EnumDataType(typeof(Recenzija))]
        [DisplayName("Mišljenje o kvizu:")]
        public Recenzija Recenzija { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Morate unijeti barem 5 karaktera!")]
        [DisplayName("Odgovor na kviz pitanje:")]
        public string Odgovor { get; set; }
    }
}
