using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; } //cheia primara are numele clasei si ID

        public int CourseId { get; set; }
        public int StudentId { get; set; } //este echivalentul ID-ului din student
        
        public Grade? Grade { get; set; } //initial va fi nullable

        //prop de navigare
        public virtual Student Student { get; set; } //enrollment-ul meu are un student; studentul este inrolat la mai multe discipline; ssytemul va crea un foreign key
        public virtual Course Course { get; set; } //systemul va crea un foreign key
    }

    public enum Grade
    {
        A,B,C,D,F
    }
}