using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class Professor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
    }


    public class ProfessorStudent
    {
        public ProfessorStudent()
        {
            Professor = new List<Professor>();
            Student = new List<Student>();
        }

        public List<Professor> Professor { get; set; }
        public List<Student> Student { get; set; }
    }
}