using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.WebMenus;
using HRKJ.WebApp.App_Start;
using HRKJ.WebApp.Areas.Manager.Filters;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class WebMenusManagerController : Controller
    {
        private IWebMenusBll menusSvc = new WebMenusBll();

        [HttpGet]
        public async Task<ActionResult> List(string search,int page = 1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;

            var data = await menusSvc.GetMenusByTitleAsync(search);
            IPagedList<WebMenusListViewModel> pages = data.Select(w => new WebMenusListViewModel
            {
                Id = w.Id,
                Title = w.Title,
                Link = w.Link,
                Icons = w.Icons,
                ParentTitle = GetMenusTitle(w.ParentId),
                UpdateTime = w.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page,PageConfig.PageSize);

            ViewBag.Search = search;

            return View(pages);
        }


        [HttpGet]
        public async Task<ActionResult> Add() 
        {
            var firstMenu = await menusSvc.GetMenusByParentIdAsync(0);
            SelectList firstMenuList = new SelectList(firstMenu, "Id", "Title");
            ViewBag.FirstMenu = firstMenuList;

            if (firstMenu.Count > 0)
            {
                var sonMenu = await menusSvc.GetMenusByParentIdAsync(firstMenu[0].Id);
                SelectList sonMenuList = new SelectList(sonMenu, "Id", "Title");
                ViewBag.SecondMenu = sonMenuList;
            }
            return View(new WebMenusAddViewModel());

        }


        [HttpPost]
        public async Task<ActionResult> Add(WebMenusAddViewModel model, string[] level)
        {
            if (ModelState.IsValid)
            {
                if (level[0] == "0")
                {
                    model.ParentId = 0;
                }
                else if (level[0] == "1")
                {
                    model.ParentId = int.Parse(level[1]);
                }
                else if (level[0] == "2")
                {
                    model.ParentId = int.Parse(level[2]);
                }

                int rs = await menusSvc.AddWebMenusAsync(model.Title, model.Link, model.Icons, model.ParentId);

                return Redirect("../../Manager/WebMenusManager/List");

            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await menusSvc.GetMenusByIdAsync(id);
            int level = 0; //用于记录菜单的等级
            int parentId = 0; //记录父级菜单id的
            int sonId = 0; //用于记录子级菜单id的

            if (model.ParentId == 0) //当当前对象的父级菜单id为空的时候代表为一级菜单
            {
                level = 0;
            }
            else //可能是二级菜单 或 三级菜单
            {
                var data = await menusSvc.GetMenusByIdAsync(model.ParentId);
                if (data.ParentId == 0)  //父级菜单的 父级id为空则为二级菜单
                {
                    level = 1;
                    parentId = data.Id;
                }
                else //否则为三级菜单
                {
                    level = 2;
                    parentId = data.ParentId;
                    sonId = data.Id;
                }
            }

            //下拉列表的值绑定
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("0", "一级菜单");
            dic.Add("1", "二级菜单");
            dic.Add("2", "三级菜单");

            var secondMenus = await menusSvc.GetMenusByParentIdAsync(0);
            var thirdMenus = await menusSvc.GetMenusByParentIdAsync(secondMenus[0].Id);

            SelectList first = new SelectList(dic, "key", "value", level);
            SelectList second = new SelectList(secondMenus, "Id", "Title", parentId);
            SelectList third = new SelectList(thirdMenus, "Id", "Title", sonId);

            ViewBag.First = first;
            ViewBag.Second = second;
            ViewBag.Third = third;

            return View(new WebMenusEditViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Link = model.Link,
                ParentId = model.ParentId,
                Icons = model.Icons

            });
        }


        [HttpPost]
        public async Task<ActionResult> Edit(WebMenusEditViewModel model, string[] level)
        {
            if (ModelState.IsValid)
            {
                if (level[0] == "0")
                {
                    model.ParentId = 0;
                }
                else if (level[0] == "1")
                {
                    model.ParentId = int.Parse(level[1]);
                }
                else if (level[0] == "2")
                {
                    model.ParentId = int.Parse(level[2]);
                }

                var res = await menusSvc.EditWebMenusAsync(model.Id, model.Title, model.Link, model.Icons, model.ParentId);
                if (res > 0)
                    return Redirect("../../../Manager/WebMenusManager/List");
            }
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await menusSvc.DeleteWebMenusAsync(id);
            return Redirect("../../Manager/WebMenusManager/List");
        }


        [HttpGet]
        public async Task<JsonResult> GetSonMenus(int parentId)
        {
            var data = await menusSvc.GetMenusByParentIdAsync(parentId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        private string GetMenusTitle(int parentId) 
        {
            var data = menusSvc.GetMenusById(parentId);
            return data == null || string.IsNullOrEmpty(data.Title) ? "顶级菜单" : data.Title;
        }
     }
}