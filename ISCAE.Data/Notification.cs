//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISCAE.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int ActorId { get; set; }
        public int TargetId { get; set; }
        public string Message { get; set; }
        public byte NotificationStatus { get; set; }
        public string TableName { get; set; }
        public int RecordId { get; set; }
        public System.DateTime DateNotification { get; set; }
    }
}
