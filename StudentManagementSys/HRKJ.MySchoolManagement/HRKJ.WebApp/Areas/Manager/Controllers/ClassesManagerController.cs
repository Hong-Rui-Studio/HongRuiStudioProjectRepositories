using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using HRKJ.WebApp.Areas.Manager.Filters;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.Classes;
using System.Web.WebSockets;
using HRKJ.WebApp.App_Start;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class ClassesManagerController : Controller
    {
        private IClassesBll classesSvc = new ClassesBll();
        private IGradesBll gradesSvc = new GradesBll();

        [HttpGet]
        public async Task<ActionResult> List(string search , int page = 1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;

            var data = await classesSvc.GetClassesByTitleAsync(search);

            IPagedList<ClassesListViewModel> pages = data.Select(c => new ClassesListViewModel
            {
                Id = c.Id,
                Title = c.Title,
                GradesTitle = GetGradesTitle(c.GradesId),
                UpdateTime = c.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);

            ViewBag.Search = search;
            return View(pages);
        }


        private string GetGradesTitle(int gradesId) 
        {
            var data = gradesSvc.GetGradesById(gradesId);
            return data == null || string.IsNullOrEmpty(data.Title) ? "" : data.Title;
        }


        private async Task BindGradesListAsync(int gradesId) 
        {
            var data = await gradesSvc.GetAllGradesAsync();

            SelectList sl = gradesId == 0 ? new SelectList(data, "Id", "Title") : new SelectList(data, "Id", "Title", gradesId);

            ViewBag.GradesList = sl;
        }



        [HttpGet]
        public async Task<ActionResult> Add() 
        {
            await BindGradesListAsync(0);
            return View(new ClassesAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(ClassesAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await classesSvc.AddClassesAsync(model.Title,model.GradesId);
                if (res > 0)
                    return Redirect("../../Manager/ClassesManager/List");
            }
            await BindGradesListAsync(model.GradesId);
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var data = await classesSvc.GetClassesByIdAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return Redirect("../../Manager/ClassesManager/List");
            await BindGradesListAsync(data.GradesId);
            return View(new ClassesEditViewModel 
            {
                Id = data.Id,
                Title = data.Title,
                GradesId = data.GradesId
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ClassesEditViewModel model) 
        {
            if (ModelState.IsValid)
            { 
                var res = await classesSvc.EditClassesAsync(model.Id,model.Title,model.GradesId);
                return Redirect("../../../Manager/ClassesManager/List");
            }
            await BindGradesListAsync(model.GradesId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            await classesSvc.DeleteClassesAsync(id);
            return Redirect("../../Manager/ClassesManager/List");
        }

    }
}