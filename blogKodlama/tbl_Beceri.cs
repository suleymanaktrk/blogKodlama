//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace blogKodlama
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Beceri
    {
        public int id { get; set; }
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public int kid { get; set; }
    
        public virtual tbl_Becerikategori tbl_Becerikategori { get; set; }
    }
}