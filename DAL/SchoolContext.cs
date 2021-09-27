using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext") //initializam baza noastra de date, cu date de test, printr-o metoda 'seed'; isi va crea o baza de date cu numele SchoolContext
        {
        }

        //definim relatiile catre tabele
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        //daca eu defineste dbseturile la sg, systemul va pluraliza automat; daca vreau sa am control, le definesc la plural si dau remove la acea convention de pluralizare
        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}