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
    
    public partial class T_Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public int typeId { get; set; }
        public bool isActive { get; set; }
        public string author { get; set; }
        public int authorId { get; set; }
        public Nullable<System.DateTime> targetDate { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public int updateBy { get; set; }
    
        public virtual M_PostType M_PostType { get; set; }
    }
}
