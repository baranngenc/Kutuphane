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
    public partial class Kasa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string AyAdi { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public string Tutar { get; set; }
    }
}
