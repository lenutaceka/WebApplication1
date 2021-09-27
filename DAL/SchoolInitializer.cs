using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstName = "Popescu", LastName = "Ion", EnrollmentDate = DateTime.Parse("2007-09-01")},
                new Student{FirstName = "Ionescu", LastName = "Virgil", EnrollmentDate = DateTime.Parse("2009-09-01")},
                new Student{FirstName = "Iliescu", LastName = "Nicolae", EnrollmentDate = DateTime.Parse("2007-09-01")},
                new Student{FirstName = "Popa", LastName = "Elena", EnrollmentDate = DateTime.Parse("2007-09-01")},
                new Student{FirstName = "Vlad", LastName = "Ileana", EnrollmentDate = DateTime.Parse("2011-09-01")},
                new Student{FirstName = "Mihacea", LastName = "Ana", EnrollmentDate = DateTime.Parse("2009-09-01")},
                new Student{FirstName = "Ion", LastName = "Lavinia", EnrollmentDate = DateTime.Parse("2007-09-01")},
            };

            //colectia de studenti trebuie adaugata in DBSetul de students
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1000, Title = "C#", Credits = 5},
                new Course {CourseID = 1002, Title = "Java", Credits = 3},
                new Course {CourseID = 1005, Title = "Ruby", Credits = 4},
                new Course {CourseID = 1006, Title = "DB", Credits = 5},
                new Course {CourseID = 1007, Title = "C++", Credits = 4},
                new Course {CourseID = 1008, Title = "EF", Credits = 4},
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{ StudentId = 1, CourseId = 1000, Grade = Grade.A },
                new Enrollment{ StudentId = 1, CourseId = 1002, Grade = Grade.B },
                new Enrollment{ StudentId = 2, CourseId = 1000, Grade = Grade.C },
                new Enrollment{ StudentId = 2, CourseId = 1007, Grade = Grade.A },
                new Enrollment{ StudentId = 3, CourseId = 1002, Grade = Grade.A },
                new Enrollment{ StudentId = 4, CourseId = 1005},
                new Enrollment{ StudentId = 4, CourseId = 1006},
                new Enrollment{ StudentId = 4, CourseId = 1008, Grade = Grade.D },
                new Enrollment{ StudentId = 5, CourseId = 1000, Grade = Grade.A },
                new Enrollment{ StudentId = 5, CourseId = 1008, Grade = Grade.B },
                new Enrollment{ StudentId = 6, CourseId = 1005},
                new Enrollment{ StudentId = 7, CourseId = 1002, Grade = Grade.B },
                new Enrollment{ StudentId = 7, CourseId = 1007, Grade = Grade.C },
            };
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
        }
    }
}