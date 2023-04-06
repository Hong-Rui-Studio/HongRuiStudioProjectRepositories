using HRGS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRGS.WebApp.Areas.Management.Data.Roles;
using HRGS.Commons;
namespace HRGS.WebApp.Areas.Management.Controllers
{
    public class RolesManagementController : Controller
    {
        private IRolesService _rolesSvc;
        public RolesManagementController(IRolesService rolesSvc)
        {
            _rolesSvc = rolesSvc;
        }

        [HttpGet]
        public async Task<ActionResult> List(string search="",int page =1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;

            var list =await _rolesSvc.GetRolesByTitleAsync(search);
            

            List<RolesListViewModel> dataList = new List<RolesListViewModel>();
            for (int i = 0, dataNum = 1; i < list.Count; i++,dataNum++) 
            {
                dataList.Add(new RolesListViewModel
                {
                    Id = list[i].Id,
                    Title = list[i].RolesTitle,
                    UpdateTime = list[i].UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")

                });
            }
            IPagedList<RolesListViewModel> pages = dataList.ToPagedList(page,PageConfig.PageSize);

            ViewBag.Search = search; 
            return View(pages);
        }


        [HttpGet]
        public ActionResult Add() 
        {
            return View(new RolesAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(RolesAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await _rolesSvc.AddRolesAsync(model.Title);
                if(res > 0)
                    return RedirectToAction("List");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) 
        {
            var model = await _rolesSvc.GetRolesByIdAsync(id);
            if (model == null || string.IsNullOrEmpty(model.RolesTitle)) 
            {
                return RedirectToAction("List");
            }

            return View(new RolesEditViewModel 
            {
                Id = model.Id,
                Title = model.RolesTitle
            });
        }


        [HttpPost]
        public async Task<ActionResult> Edit(RolesEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await _rolesSvc.EditRolesAsync(model.Id,model.Title);
                if(res > 0)
                    return RedirectToAction("List");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(Guid id) 
        {
            await _rolesSvc.DeleteRolesAsync(id);
            return RedirectToAction("List");
        }
    }
}