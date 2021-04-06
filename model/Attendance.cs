using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Attendance
    {

        public Object TeacherId { get; set; }
        public Object CourseId { get; set; }
        public Object RoomId { get; set; }
        public String StartTime { get; set; }
        public String LeaveTime { get; set; }
        public String Comment { get; set; }

        public Attendance(Object TeacherId,Object CourseId, Object RoomId, String StartTime, String LeaveTime, String Comment)
        {
            this.TeacherId = TeacherId;
            this.CourseId = CourseId;
            this.RoomId = RoomId;
            this.StartTime = StartTime;
            this.LeaveTime = LeaveTime;
            this.Comment = Comment;
        }

     
    }
}
