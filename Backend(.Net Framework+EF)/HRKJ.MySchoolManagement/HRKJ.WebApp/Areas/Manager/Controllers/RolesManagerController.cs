using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using HRKJ.WebApp.Areas.Manager.Data.Roles;
using HRKJ.WebApp.App_Start;
using System.Security.Cryptography;
using HRKJ.WebApp.Areas.Manager.Filters;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class RolesManagerController : Controller
    {
        private IRolesBll rolesSvc = new RolesBll();
        [HttpGet]
        public async Task<ActionResult> List(string search , int page=1)
        {
            var kw = string.IsNullOrEmpty(search) ? "" : search;
            var data = await rolesSvc.GetRolesByTitleAsync(kw);

            var pageData = data.Select(r => new RolesListViewModel
            {
                Id = r.Id,
                Title= r.Title,
                UpdateTime = r.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page,PageConfig.PageSize);

            ViewBag.Search = search;
            return View(pageData);
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
               var res = await rolesSvc.AddRolesAsync(model.Title);
                if (res > 0)
                    return Redirect("../../Manager/RolesManager/List");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var data = await rolesSvc.GetRolesByIdAsync(id);
            if (data == null)
                return Redirect("../../Manager/RolesManager/List");
            return View(new RolesEditViewModel 
            {
                Id = data.Id,
                Title = data.Title
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RolesEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await rolesSvc.EditRolesAsync(model.Id,model.Title);
                if (res > 0)
                    return Redirect("../../../Manager/RolesManager/List");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            var res = await rolesSvc.DeleteRolesAsync(id);

            return Redirect("../../Manager/RolesManager/List");
        }
    }
}