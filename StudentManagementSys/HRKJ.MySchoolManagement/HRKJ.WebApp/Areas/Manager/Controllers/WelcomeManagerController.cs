using HRKJ.IService;
using HRKJ.Service;
using HRKJ.WebApp.Areas.Manager.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class WelcomeManagerController : Controller
    {
        private IClassesBll classesSvc = new ClassesBll();
        private ISubjectsBll subjectsSvc = new SubjectsBll();
        private IStudentsBll studentsSvc = new StudentsBll();
        private IExamInfosBll examsInfoSvc = new ExamInfosBll();


        [HttpGet]
        public async Task<ActionResult> List()
        {
            var classesData = await classesSvc.GetAllClassesAsync();
            var subjectsData = await subjectsSvc.GetAllSubjectsAsync();
            var studentsData = await studentsSvc.GetAllStudentsAsync();
            var examsData = await examsInfoSvc.GetAllExamInfosAsync();
            ViewBag.Classes = classesData.Any() ? classesData.Count : 0;
            ViewBag.Subjects = subjectsData.Any() ? subjectsData.Count : 0;
            ViewBag.Students = studentsData.Any() ? studentsData.Count : 0;
            ViewBag.Exams = examsData.Any() ? examsData.Count : 0;
            return View();
        }
    }
}