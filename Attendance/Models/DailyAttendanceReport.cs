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
    
    public partial class DailyAttendanceReport
    {
        public long id { get; set; }
        public string pin { get; set; }
        public Nullable<System.TimeSpan> thetime1 { get; set; }
        public Nullable<System.TimeSpan> thetime2 { get; set; }
        public string Name { get; set; }
        public string DEPTNAME { get; set; }
        public string device_name2 { get; set; }
        public string thedate1 { get; set; }
        public string device_name1 { get; set; }
        public string thedate2 { get; set; }
    }
}
