//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhenWillIGetThere
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commutes
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> Stop { get; set; }
    
        public virtual Routes Routes { get; set; }
    }
}
