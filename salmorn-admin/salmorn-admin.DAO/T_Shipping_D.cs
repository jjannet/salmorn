//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace salmorn_admin.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Shipping_D
    {
        public int id { get; set; }
        public int hId { get; set; }
        public int orderId { get; set; }
        public string code { get; set; }
    
        public virtual T_Shipping_H T_Shipping_H { get; set; }
    }
}
