using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadaća_4.Models
{
    public enum Lokacija
    {
        [Display(Name = "Sarajevo")]
        Sarajevo,
        [Display(Name = "Mostar")]
        Mostar
    }

    public enum Restoran
    {
        [Display(Name = "Montana")]
        Montana,
        [Display(Name = "U2")]
        U2,
        [Display(Name = "Burger House")]
        BurgerHouse
    }

    public class KućnaDostava
    {
        [Key]
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Broj kartice sastoji se od tačno 5 karaktera!")]
        [DisplayName("Broj članske kartice:")]
        public string BrojKartice { get; set; }

        [Required]
        [EnumDataType(typeof(Lokacija))]
        [DisplayName("Lokacija:")]
        public Lokacija Lokacija { get; set; }

        [Required]
        [EnumDataType(typeof(Restoran))]
        [DisplayName("Restoran:")]
        public Restoran Restoran { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Cijena narudžbe mora biti između 1 KM i 100 KM!")]
        [DisplayName("Cijena narudžbe:")]
        public double Cijena { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "Morate unijeti opis narudžbe!")]
        [DisplayName("Opis narudžbe:")]
        public string OpisNarudzbe { get; set; }

        [Required]
        [DisplayName("Posebne pogodnosti")]
        public bool VIP { get; set; }

        [Required]
        [DisplayName("Hitna narudžba")]
        public bool Hitno { get; set; }

        [DisplayName("Broj telefona")]
        public string BrojTelefona { get; set; }
    }
}
