//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RicePK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCity
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public long StateId { get; set; }
    
        public virtual tblState tblState { get; set; }
    }
}