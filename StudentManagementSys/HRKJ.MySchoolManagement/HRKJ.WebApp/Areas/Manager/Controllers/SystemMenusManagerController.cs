using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.SystemMenus;
using HRKJ.WebApp.App_Start;
using HRKJ.Dtos;
using HRKJ.WebApp.Areas.Manager.Filters;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class SystemMenusManagerController : Controller
    {
        private ISystemMenusBll menusSvc = new SystemMenusBll();
        [HttpGet]
        public async Task<ActionResult> List(string search ,int page = 1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var data = await menusSvc.GetMenusByTitleAsync(search);
            IPagedList<SystemMenusListViewModel> pages = data.Select(m => new SystemMenusListViewModel 
            {
                Id = m.Id,
                Title = m.Title,
                Link= m.Link,
                Icons= m.Icons,
                ParentTitle = GetParentMenusTitle(m.ParentId),
                UpdateTime = m.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page,PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]
        public async Task<ActionResult> Add() 
        {
            var firstMenu = await menusSvc.GetAllMenusByParentIdAsync(0);
            SelectList firstMenuList = new SelectList(firstMenu, "Id", "Title");
            ViewBag.FirstMenu = firstMenuList;

            if (firstMenu.Count > 0)
            {
                var sonMenu = await menusSvc.GetAllMenusByParentIdAsync(firstMenu[0].Id);
                SelectList sonMenuList = new SelectList(sonMenu, "Id", "Title");
                ViewBag.SecondMenu = sonMenuList;
            }
            return View(new SystemMenusAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(SystemMenusAddViewModel model, string[] level) 
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

                int rs = await menusSvc.AddMenusAsync(model.Title, model.Link, model.Icons, model.ParentId);

                return Redirect("../../Manager/SystemMenusManager/List");

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

            var secondMenus = await menusSvc.GetAllMenusByParentIdAsync(0);
            var thirdMenus = await menusSvc.GetAllMenusByParentIdAsync(secondMenus[0].Id);

            SelectList first = new SelectList(dic, "key", "value", level);
            SelectList second = new SelectList(secondMenus, "Id", "Title", parentId);
            SelectList third = new SelectList(thirdMenus, "Id", "Title", sonId);

            ViewBag.First = first;
            ViewBag.Second = second;
            ViewBag.Third = third;

            return View(new SystemMenusEditViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Link = model.Link,
                ParentId = model.ParentId,
                Icons = model.Icons

            });
        }


        [HttpPost]
        public async Task<ActionResult> Edit(SystemMenusEditViewModel model, string[] level) 
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

                var res = await menusSvc.EditMenusAsync(model.Id, model.Title, model.Link, model.Icons, model.ParentId);
                if (res > 0)
                    return Redirect("../../../Manager/SystemMenusManager/List");
            }
                return View(model);
            
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            var res = await menusSvc.DeleteMenusAsync(id);
            return Redirect("../../Manager/SystemMenusManager/List");
        }


        [HttpGet]
        public async Task<JsonResult> GetSonMenus(int parentId) 
        {
            var data = await menusSvc.GetAllMenusByParentIdAsync(parentId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }


        private string GetParentMenusTitle(int id) 
        {
            var data = menusSvc.GetMenusById(id);
            return data == null || string.IsNullOrEmpty(data.Title) ? "顶级菜单" : data.Title;
        }
    }
}