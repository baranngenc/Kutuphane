//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Iletisim
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string MesajKonusu { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string Mesaj { get; set; }
    }
}
