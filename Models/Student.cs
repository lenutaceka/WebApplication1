using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {
        public int ID { get; set; } //acest field va fi by default cheia primara
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        //studentul trebuie sa il legam de tabela de enrollment - relatie 1 to many student-enrollment
        public virtual ICollection<Enrollment> Enrollments { get; set; } //leg inversa dintre student - enrollment

    }
}