using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFAPPS.Entities
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public short CourseHourPerWeek { get; set; }
    }
}
