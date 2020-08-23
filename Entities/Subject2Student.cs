using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingDb.Entities
{
    public class Subject2Student : BaseEntity
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public DateTime DateOfEnrollment { get; set; }

    }
}
