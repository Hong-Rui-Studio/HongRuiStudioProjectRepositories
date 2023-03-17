using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using HRKJ.WebApp.Areas.Manager.Data.Roles;
using HRKJ.WebApp.Areas.Manager.Data.SystemMenus;
using HRKJ.WebApp.Areas.Manager.Data.UsersPermission;
using HRKJ.WebApp.Areas.Manager.Filters;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class UsersPermissionManagerController : Controller
    {
        private IUsersPermissionBll permissionSvc = new UsersPermissionBll();
        private IRolesBll rolesSvc = new RolesBll();
        private ISystemMenusBll menuSvc = new SystemMenusBll();

        [HttpGet]
        public async Task<ActionResult> List()
        {
            await RolesListBind(0);
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> List(RolesListViewModel roles)
        {
            await RolesListBind(roles.Id); //这个是下拉列表的绑定

            var permissionList = await permissionSvc.GetPermissionByRolesIdAsync(roles.Id);
            var data = await menuSvc.GetMenusByTitleAsync(""); //查询所有的系统菜单列表
            var allMenuList = new List<SystemMenusListViewModel>();
            foreach (var item in data)
            {
                SystemMenusListViewModel smvm = new SystemMenusListViewModel
                {
                    Id = item.Id,
                    Title = item.Title
                };
                allMenuList.Add(smvm);
            }

            var haveData = (from sm in allMenuList
                            where (from ap in permissionList select ap.MenusId).Contains(sm.Id)
                            select sm).ToList();

            var noneHave = (from sm in allMenuList
                            where !(from ap in permissionList select ap.MenusId).Contains(sm.Id)
                            select sm).ToList();

            ViewBag.HaveList = haveData;
            ViewBag.NoHave = noneHave;
            return View();
        }




        private async Task RolesListBind(int rolesId)
        {
            var data = await rolesSvc.GetAllRolesAsync();
            var rolesList = new List<RolesListViewModel>();
            foreach (var item in data)
            {
                RolesListViewModel rlvm = new RolesListViewModel
                {
                    Id = item.Id,
                    Title = item.Title
                };
                rolesList.Add(rlvm);
            }
            if (rolesId == 0)
            {
                SelectList sl = new SelectList(rolesList, "Id", "Title");
                ViewBag.Roles = sl;
            }
            else
            {
                SelectList sl = new SelectList(rolesList, "Id", "Title", rolesId);
                ViewBag.Roles = sl;
                ViewBag.RolesId = rolesId;
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add(AddUsersPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var menuId in model.SystemMenuId)
                {
                    await permissionSvc.AddUsersPermissionAsync(model.RolesId, menuId);
                }
            }

            return RedirectToAction("List", "UsersPermissionManager");
        }


        [HttpPost]
        public async Task<ActionResult> Delete(DeleteUsersPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.SystemMenuId)
                {
                    await permissionSvc.DeleteUsersPermissionAsync(model.RolesId, item);
                }
            }

            return RedirectToAction("List", "UsersPermissionManager");
        }



    }
}