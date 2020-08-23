using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingDb.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Classroom Classroom { get; set; }
        public int ClassroomId { get; set; }
        public List<Subject> Subjects { get; set; }

    }
}
