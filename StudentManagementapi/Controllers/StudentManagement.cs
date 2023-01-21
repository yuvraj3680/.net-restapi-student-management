using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using StudentManagementApi.Model;
namespace StudentController;
using StudentManagementApi.DAL;


namespace StudentManagementapi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    

    private readonly ILogger<StudentController> _logger;

    

    [HttpGet]
    [EnableCors()]
    public IEnumerable<Student> GetAllStudents()
    {
        List<Student> Students=StudentsDataAccess.GetAllStudents();
         return Students;
    }
     
     [Route("{id}")]
    [HttpGet]
    [EnableCors()]
    public ActionResult<Student> GetOneStudent(int id)
    {
        Student Students = StudentsDataAccess.GetStudentById(id);
        return Students;
    }

     [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewStudent(Student Student)
    {
        studentsDataAccess.SaveNewStudent(Student);
        return Ok(new { message = "Student created" });
    }
    

     [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public ActionResult<Student> DeleteOneStudent(int id)
    {
        StudentsDataAccess.DeleteStudentById(id);
        return Ok(new { message = "Student deleted" });
    }
}
