using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingDb.Entities;

namespace TeachingDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                //Subject2Student st = new Subject2Student()
                //{
                //    StudentId = 8,
                //    DateOfEnrollment = new DateTime(2018, 8, 5),
                //    SubjectId = 1
                //};


                //db.Subject2Students.Add(st);
                //db.SaveChanges();

                //Console.WriteLine(db.Students.Select(s => s.Name).ToList().Aggregate((a,b) => $"{a},{b}"));

                //var filtered = db.Students.Where(s => s.ClassroomId == 1).Select(s => s.Surname + s.Name);
                //var filtered = db.Students;
                //var filtered2 = db.Students.ToList();


                //var joined = db.Classrooms.Join(db.Students, c => c.Id, s => s.ClassroomId,
                //    (c, s) => new
                //    {
                //        Trida = c.Name,
                //        Prijmeni = s.Surname,
                //        Krestni = s.Name

                //    }).Where(cId => cId.Trida == "8.A");

                var firstJoin = db.Students.Join(db.Subject2Students,
                    st => st.Id,
                    s2s => s2s.StudentId,
                    (st, s2s) => new
                    {
                        StudentName = ($"{st.Name} {st.Surname}"),
                        SubjectId = s2s.SubjectId
                    }).Join(db.Subjects,
                                    s2s => s2s.SubjectId,
                                    sb => sb.Id,
                                    (s2s, sb) => new
                                    {
                                        StudentName = s2s.StudentName,
                                        SubjectName = sb.Name
                                    }).ToList();

                var grouped = firstJoin.GroupBy(n => n.StudentName).ToList();

                var final = grouped.Select(
                    s => new
                    {
                        StudentName = s.Key,
                        Subjects = s.Select(sb => sb.SubjectName).Aggregate((a, b) => $"{a},{b}")
                    }).ToList();

                foreach (var s in final)
                {
                    Console.WriteLine($"{s.StudentName} {s.Subjects}");
                }










                //    var joined = db.Students
                //        .Join(db.Subject2Students,
                //            s => s.Id,
                //            s2s => s2s.StudentId,
                //            (s, s2s) => new
                //            {
                //                FullName = s.Name + " " + s.Surname,
                //                SubjectId = s2s.SubjectId
                //            })
                //        .Join(db.Subjects,
                //            a => a.SubjectId,
                //            s => s.Id,
                //            (a, s) => new
                //            {
                //                FullName = a.FullName,
                //                SubjectName = s.Name

                //            })
                //        .ToList();

                //    var joinedSecond = joined
                //         .GroupBy(s => s.SubjectName);


                //    var joinedThird = joinedSecond
                //        .Select(s => new
                //        {
                //            SubjectName = s.Key,
                //            Students = s.Select(a => a.FullName).Aggregate((a, b) => $"{a},{b}")
                //        });
                //}


                //var numbers = new List<int> { 1, 2, 4, 3, 2 };

                //var counted = numbers.Aggregate((a, b) => a + b);


                //Console.ReadLine();
            }
        }
    }
}
