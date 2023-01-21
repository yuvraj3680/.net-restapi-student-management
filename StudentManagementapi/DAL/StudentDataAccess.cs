namespace StudentManagementApi.DAL;

using StudentManagementApi.Model;
using System.Data;
using MySql.Data.MySqlClient;


public class StudentsDataAccess{
     public static string conString = @"server=localhost; port=3306; user=root; password=root; database=student";
     public static List<Student> GetAllStudents(){
         List<Student> allNotes = new List<Student>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from Students";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Student student = new Student
                {
                    studentid = int.Parse(row["studentid"].ToString()),
                    studentname = row["studentname"].ToString(),
                    studentqty = row["studentqty"].ToString(),
                    price = row["price"].ToString()
                };
                allNotes.Add(student);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }

    public static Student GetStudentById(int id)
    {
        Student student = null;
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "select * from users where studentid=" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                student = new Student
                {
                    studentid = int.Parse(reader["studentid"].ToString()),
                    studentname = reader["studentname"].ToString(),
                    studentcource = reader["studentcource"].ToString(),
                    studentjoindate = reader["studentjoindate"].ToString()
                };
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return student;
    }

    public static void SaveNewStudent(Student student)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"insert into students(studentid,studentname,studentcource,studentjoindate) values('{student.studentid}', '{student.studentname}', '{student.studentcource}'{student.studentjoindate})";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeleteStudentById(int id)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "delete from students where studentid =" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

}

     