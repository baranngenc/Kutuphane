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
    
    public partial class Ceza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public int Uye { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public int Emanet { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public System.DateTime BaslamaTarihi { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public System.DateTime BitisTarihi { get; set; }
        [Required(ErrorMessage = "Bo� Ge�ilemez!")]
        public decimal CezaUcreti { get; set; }
    
        public virtual Emanet Emanet1 { get; set; }
        public virtual Uye Uye1 { get; set; }
    }
}