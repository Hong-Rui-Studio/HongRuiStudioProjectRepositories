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
using HRKJ.WebApp.Areas.Manager.Data.Students;
using HRKJ.WebApp.App_Start;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class StudentsManagerController : Controller
    {
        private IClassesBll classesSvc = new ClassesBll();
        private IGradesBll gradesSvc = new GradesBll();
        private IStudentsBll studentsSvc = new StudentsBll();

        [HttpGet]
        public async Task<ActionResult> List(string search,int page=1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var data = await studentsSvc.GetStudentsByNameAsync(search);
            IPagedList<StudentsListViewModel> pages = data.Select(s => new StudentsListViewModel
            {
                Id = s.Id,
                RealName = s.RealName,
                BornDate = s.BornDate.ToString("yyyy-MM-dd"),
                Gender = s.Gender == 1 ? "男" : "女",
                Email = s.Email,
                Phone= s.Phone,
                QQNumber= s.QQNumber,
                WeChat = s.WeChat,
                ClassTitle = GetClassesTitle(s.ClassesId),
                UpdateTime = s.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]
        public ActionResult Add()
        {
            BindClassesList(0);
            return View(new StudentsAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(StudentsAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await studentsSvc.AddStudentsAsync(model.RealName, model.BornDate, model.Gender, model.Email, model.Phone, "无", model.QQNumber, model.WeChat, model.ClassesId);
                if (res > 0)
                    return Redirect("../../Manager/StudentsManager/List");
            }
            BindClassesList(model.ClassesId);
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var data = await studentsSvc.GetStudentsByIdAsync(id);
            if(data == null || string.IsNullOrEmpty(data.RealName))
                return Redirect("../../Manager/StudentsManager/List");

            BindClassesList(data.ClassesId);
            return View(new StudentsEditViewModel
            {
                Id = data.Id,
                RealName = data.RealName,
                BornDate = data.BornDate,
                Gender = data.Gender,
                Email = data.Email,
                Phone = data.Phone,
                QQNumber = data.QQNumber,
                WeChat = data.WeChat,
                ClassesId = data.ClassesId           
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(StudentsEditViewModel model) 
        {

            if (ModelState.IsValid) 
            {
                var res = await studentsSvc.EditStudentsAsync(model.Id, model.RealName, model.BornDate, model.Gender, model.Email, model.Phone, "", model.QQNumber, model.WeChat, model.ClassesId);
                if (res > 0)
                    return Redirect("../../../Manager/StudentsManager/List");
            }

            BindClassesList(model.ClassesId);
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            await studentsSvc.DeleteStudentsAsync(id);
            return RedirectToAction("List","StudentsManager");
        }


        private void BindClassesList(int classesId) 
        {
            var data = classesSvc.GetAllClasses();
            SelectList sl = classesId == 0 ? new SelectList(data, "Id", "Title") : new SelectList(data, "Id", "Title", classesId); 
            ViewBag.ClassesList = sl;
        }


        private string GetClassesTitle(int classesId) 
        {
            var classesModel = classesSvc.GetClassById(classesId);
            if (classesModel == null || string.IsNullOrEmpty(classesModel.Title))
                return "";
            var gradesModel = gradesSvc.GetGradesById(classesModel.GradesId);
            return gradesModel.Title + "T"+classesModel.Title;
        }
    }
}