//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Attendance.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DELAY
    {
        public int id { get; set; }
        public string pin { get; set; }
        public Nullable<System.DateTime> thedate { get; set; }
        public string Name { get; set; }
        public Nullable<System.TimeSpan> thetime { get; set; }
        public Nullable<int> delayinmin { get; set; }
        public string device_name { get; set; }
        public string DEPTNAME { get; set; }
    }
}
