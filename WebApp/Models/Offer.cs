//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    public partial class Offer
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Model { get; set; }
        [Range(1900, 2100)]
        public Nullable<int> Year { get; set; }
        [Range(0, 9999999)]
        public Nullable<int> Distance { get; set; }
        [Range(0, 9999)]
        [DisplayName("Power(KW)")]
        public Nullable<int> Power_KW_ { get; set; }
        [Range(0, 9999)]
        [DisplayName("Power(HP)")]
        public Nullable<int> Power_HP_ { get; set; }
       
        [Range(0, 999999)]
        [DisplayName("Price (EUR)")]
        public Nullable<int> Price { get; set; }
        public string Desription { get; set; }
        public string Notice { get; set; }
        public string Contact { get; set; }
        public Nullable<int> Category { get; set; }
        
        [DisplayName("Upload picture")]
        public string Picture { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [DisplayName("Category")]
        public virtual Category Category1 { get; set; }
    }
}
