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
using HRKJ.WebApp.Areas.Manager.Data.Grades;
using HRKJ.WebApp.App_Start;
using HRKJ.Entity;
namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class GradesManagerController : Controller
    {
        private IGradesBll gradesSvc = new GradesBll();
        [HttpGet]
        public async Task<ActionResult> List(string search,int page =1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var data = await gradesSvc.GetGradesByTitleAsync(search);

            IPagedList<GradesListViewModel> pages = data.Select(g => new GradesListViewModel
            {
                Id = g.Id,
                Title = g.Title,
                UpdateTime = g.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);

            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new GradesAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(GradesAddViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var res = await gradesSvc.AddGradesAsync(model.Title);
                if (res > 0)
                    return Redirect("../../Manager/GradesManager/List");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var data = await gradesSvc.GetGradesByIdAsync(id);
            if (data == null) 
            {
                return Redirect("../../Manager/GradesManager/List");
            }
            return View(new GradesEditViewModel
            {
                Id = data.Id,
                Title= data.Title
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(GradesEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await gradesSvc.EditGradesAsync(model.Id, model.Title);
                if (res > 0)
                    return Redirect("../../../Manager/GradesManager/List");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            await gradesSvc.DeleteGradesAsync(id);
            return Redirect("../../Manager/GradesManager/List");
        }
    }
}