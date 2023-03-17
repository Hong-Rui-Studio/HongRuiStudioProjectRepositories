using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.Seos;
using HRKJ.WebApp.App_Start;
using HRKJ.Dtos;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    public class SeosManagerController : Controller
    {
        private ISeosBll seosSvc = new SeosBll();
        private IWebMenusBll menuSvc = new WebMenusBll();

        [HttpGet]
        public async Task<ActionResult> List(string search ,int page =1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var data = await seosSvc.GetSeosByTitleAsync(search);

            IPagedList<SeosListViewModel> pages = data.Select(s => new SeosListViewModel 
            {
                Id = s.Id,
                Title = s.Title,
                Keyword= s.Keyword,
                Description= s.Description.Length >= 50 ? s.Description.Substring(0,50)+"..." : s.Description ,
                MenusTitle = GetMenusTitle(s.MenusId),
                UpdateTime = s.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]
        public ActionResult Add() 
        {
            BindMenusList(0);
            return View(new SeosAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(SeosAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await seosSvc.AddSeosAsync(model.Title, model.Keyword, model.Description, model.WebMenusId);
                if (res > 0)
                    return Redirect("../../Manager/SeosManager/List");
            }
            BindMenusList(model.WebMenusId);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var data = await seosSvc.GetSeosByIdASync(id);
            BindMenusList(data.MenusId);
            return View(new SeosEditViewModel 
            {
                Id = data.Id,
                Title = data.Title,
                Keyword= data.Keyword,
                Description = data.Description,
                WebMenusId = data.MenusId
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SeosEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await seosSvc.EditSeosAsync(model.Id, model.Title, model.Keyword, model.Description, model.WebMenusId);
                if(res > 0)
                    return RedirectToAction("List", "SeosManager");
            }
            BindMenusList(model.WebMenusId);
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await seosSvc.DeleteSeosAsync(id);
            return RedirectToAction("List", "SeosManager");
        }

        private void BindMenusList(int menusId) 
        {
            List<WebMenusDto> menusList = menuSvc.GetAllMenus();
            SelectList sl = menusId == 0 ? new SelectList(menusList,"Id","Title") 
                : new SelectList(menusList,"Id","Title",menusId);
            ViewBag.MenusList = sl;
        }

        private string GetMenusTitle(int menusId) 
        {
            var data = menuSvc.GetMenusById(menusId);
            return data == null || string.IsNullOrEmpty(data.Title) ? "" : data.Title;
        }
    }
}