//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Time_Sheet_Header
    {
        public byte[] timestamp { get; set; }
        public string No_ { get; set; }
        public System.DateTime Starting_Date { get; set; }
        public System.DateTime Ending_Date { get; set; }
        public string Resource_No_ { get; set; }
        public string Owner_User_ID { get; set; }
        public string Approver_User_ID { get; set; }
        public System.Guid C_systemId { get; set; }
    }
}
