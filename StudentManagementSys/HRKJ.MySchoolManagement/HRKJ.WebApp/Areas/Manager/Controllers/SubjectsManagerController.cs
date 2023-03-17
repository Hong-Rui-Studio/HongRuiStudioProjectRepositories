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
using HRKJ.WebApp.Areas.Manager.Data.Subjects;
using HRKJ.WebApp.App_Start;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class SubjectsManagerController : Controller
    {
        private ISubjectsBll subjectsSvc = new SubjectsBll();
        private IGradesBll gradesSvc = new GradesBll();

        [HttpGet]
        public async Task<ActionResult> List(string search, int page = 1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;

            var data = await subjectsSvc.GetSubjectsByTitleAsync(search);

            IPagedList<SubjectsListViewModel> pages = data.Select(s => new SubjectsListViewModel
            {
                Id = s.Id,
                Title = s.Title,
                GradesTitle = GetGradesTitle(s.GradesId),
                UpdateTime = s.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);

            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]
        public ActionResult Add()
        {
            BindGradesList(0);
            return View(new SubjectsAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(SubjectsAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await subjectsSvc.AddSubjectsAsync(model.Title, model.GradesId);
                if (res > 0)
                    return Redirect("../../Manager/SubjectsManager/List");
            }
            BindGradesList(model.GradesId);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var data = await subjectsSvc.GetSubjectsByIdAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return Redirect("../../Manager/SubjectsManager/List");

            BindGradesList(data.GradesId);
            return View(new SubjectsEditViewModel
            {
                Id = data.Id,
                Title = data.Title,
                GradesId = data.GradesId,
            });

        }

        [HttpPost]
        public async Task<ActionResult> Edit(SubjectsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await subjectsSvc.EditSubjectsAsync(model.Id, model.Title, model.GradesId);
                if (res > 0)
                    return Redirect("../../../Manager/SubjectsManager/List");
            }

            BindGradesList(model.GradesId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            await subjectsSvc.DeleteSubjectsAsync(id);
            return Redirect("../../Manager/SubjectsManager/List");
        } 


        private void BindGradesList(int gradesId) 
        {
            var data = gradesSvc.GetAllGrades();

            SelectList sl = gradesId == 0 ? new SelectList(data,"Id","Title") : new SelectList(data,"Id","Title",gradesId);

            ViewBag.GradesList = sl;
        }



        private string GetGradesTitle(int gradesId)
        {
            var data = gradesSvc.GetGradesById(gradesId);
            return data == null || string.IsNullOrEmpty(data.Title) ? "" : data.Title;
        }
    }
}