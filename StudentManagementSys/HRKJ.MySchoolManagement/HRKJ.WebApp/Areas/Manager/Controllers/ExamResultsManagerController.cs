using HRKJ.IService;
using HRKJ.Service;
using HRKJ.WebApp.Areas.Manager.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.ExamResults;
using HRKJ.WebApp.App_Start;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class ExamResultsManagerController : Controller
    {
        private IExamResultsBll examResultsSvc = new ExamResultsBll();
        private IExamInfosBll examInfoSvc = new ExamInfosBll();
        private IStudentsBll studentsSvc = new StudentsBll();
        private IClassesBll classesSvc = new ClassesBll();
        [HttpGet]
        public async Task<ActionResult> ResultList(int id,int page = 1)
        {
            var data= await examResultsSvc.GetExamResultsByExamIdAsync(id);
            var examData = await examInfoSvc.GetExamInfosByIdAsync(id);

            IPagedList<ExamResultsListViewModel> pages = data.Select(e => new ExamResultsListViewModel
            {
                Id = e.Id,
                ExamTitle = examData.Title,
                StudentsName = GetStudentsName(e.StudentId),
                Scores = e.Scores,
                UpdateTime = e.UpdateTime.ToString("yyyy-MM-dd")
            }).OrderByDescending(e => e.Scores).ToPagedList(page, PageConfig.PageSize);

            ViewBag.ExamId = id;
            return View(pages);
        }


        private string GetStudentsName(int studentId) 
        {
            var data = studentsSvc.GetStudentsById(studentId);
            return data == null || string.IsNullOrEmpty(data.RealName) ? "" : data.RealName; 
        }

        [HttpGet]
        public ActionResult List(int id)
        {
            BindClasses();
            ViewBag.ExamId = id;
            return View(new ResultsAddViewModel());
        }


        private  void BindClasses() 
        {
            var data = classesSvc.GetAllClasses();
            SelectList sl = new SelectList(data, "Id", "Title");
            ViewBag.ClassesList = sl;
        }

        [HttpGet]
        public ActionResult GetStudents(int classesId) 
        {
            var data = studentsSvc.GetStudentsByClassesId(classesId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ResultsAddViewModel model)
        {
            if (ModelState.IsValid) 
            {
                for (var i = 0; i < model.StudentList.Length; i++) 
                {
                    await examResultsSvc.AddExamResultsAsync(model.ExamsId, model.StudentList[i], model.ScoresList[i]);
                }
            }


            return RedirectToAction("List", "ExamInfosManager");
        }

    }
}