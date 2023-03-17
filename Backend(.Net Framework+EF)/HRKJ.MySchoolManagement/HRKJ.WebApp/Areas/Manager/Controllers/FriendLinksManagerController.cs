using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.FriendLinks;
using HRKJ.WebApp.App_Start;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    public class FriendLinksManagerController : Controller
    {
        private IFriendLinksBll linksSvc = new FriendLinksBll();

        [HttpGet]
        public async Task<ActionResult> List(string search ,int page = 1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;

            var data = await linksSvc.GetFriendLinksByTitleAsync(search);

            IPagedList<FriendLinksListViewModel> pages = data.Select(f => new FriendLinksListViewModel
            {
                Id = f.Id,
                Title = f.Title,
                Link= f.Link,
                IsShow = f.IsShow == 1 ? "显示" : "不显示",
                UpdateTime = f.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);

            ViewBag.Search = search;
            return View(pages);
        }


        [HttpGet]
        public ActionResult Add() 
        {
            return View(new FriendLinksAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(FriendLinksAddViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var res = await linksSvc.AddFriendLinksAsync(model.Title,model.Link,model.IsShow);
                if (res > 0)
                    return RedirectToAction("List", "FriendLinksManager");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var data = await linksSvc.GetFriendLinksByIdAsync(id);
            return View(new FriendLinksEditViewModel 
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                IsShow = data.IsShow
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(FriendLinksEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await linksSvc.EditFriendLinksAsync(model.Id, model.Title, model.Link, model.IsShow);
                if (res > 0)
                    return RedirectToAction("List", "FriendLinksManager");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            await linksSvc.DeleteFriendLinksAsync(id);
            return RedirectToAction("List", "FriendLinksManager");
        }

    }
}