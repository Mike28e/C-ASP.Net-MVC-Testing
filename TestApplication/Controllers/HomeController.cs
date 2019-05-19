using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using TestApplication.Models;



namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            String connectionString = "Data Source=MIKE\\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TestSproc";


            SqlCommand cmd1 = new SqlCommand("SELECT * FROM studentlist", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM professorlist", conn);

            var model = new ProfessorStudent();
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var student = new Student();
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Class = rdr["Class"].ToString();

                    model.Student.Add(student);
                }
                rdr.Close();

                rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    var professor = new Professor();
                    professor.FirstName = rdr["FirstName"].ToString();
                    professor.LastName = rdr["LastName"].ToString();
                    professor.Class = rdr["Class"].ToString();

                    model.Professor.Add(professor);
                }

            }


            return View(model);
        }
    }
}