using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRKJ.WebApp.Areas.Manager.Data.Login;
using System.Threading.Tasks;
using HRKJ.WebApp.App_Start;
using HRKJ.Dtos;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    public class LoginManagerController : Controller
    {
        private IUsersBll usersSvc = new UsersBll();
        private IUsersPermissionBll permissionSvc = new UsersPermissionBll();
        private ISystemMenusBll menusSvc = new SystemMenusBll();
        [HttpGet]
        public ActionResult SignIn()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> SignIn(LoginViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var data = await usersSvc.LoginAsync(model.Email, Md5Helper.Encryption(model.Pwd));
                if (data != null) 
                {
                    Session["LoginOk"] = data.Id;
                    Session["RolesId"] = data.RolesId;

                    return Redirect("../../Manager/WelcomeManager/List");
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> GetUsersInfo()
        {
            var obj = Session["LoginOk"];
            if(obj != null) 
            {
                int usersId = int.Parse(obj.ToString());
                var data = await usersSvc.GetUsersByIdAsync(usersId);
                if (data != null || !string.IsNullOrEmpty(data.RealName))
                {
                    return Json(new UsersInfoViewModel
                    {
                        Code = 200,
                        UserImg = data.Images,
                        UserName = data.RealName
                    },JsonRequestBehavior.DenyGet);
                }
            }

            return Json(new UsersInfoViewModel 
            {
                Code = 404,
                UserName = "",
                UserImg = ""
            }, JsonRequestBehavior.DenyGet);

        }


        [HttpGet]
        public async Task<JsonResult> GetAllMenusByRolesId() 
        {
            var rolesObj = Session["RolesId"];
            if (rolesObj != null)
            {
                var permissionList = permissionSvc.GetPermissionByRolesId(int.Parse(rolesObj.ToString()));
                var allMenus = await menusSvc.GetAllMenusAsync();

                var menus = new List<SystemMenusDto>();
                for (int i = 0; i < allMenus.Count; i++)
                {
                    for (int j = 0; j < permissionList.Count; j++)
                    {
                        if (allMenus[i].Id == permissionList[j].MenusId)
                        {
                            menus.Add(allMenus[i]);
                        }
                    }
                }

                //4. 在上面得到所有能看到菜单当中找出一级菜单
                var parents = menus.Where(m => m.ParentId == 0).OrderBy(m => m.UpdateTime);
                //5. 得到最后要往界面返回的集合内容
                List<LeftMenuListViewModel> list = new List<LeftMenuListViewModel>();

                foreach (var item in parents)
                {
                    //1. 通过一级菜单的id查找对应的子级菜单
                    List<LeftMenuListViewModel> sonList = new List<LeftMenuListViewModel>();
                    var sonData = from all in menus
                                  where all.ParentId == item.Id
                                  select all;
                    foreach (var sonItem in sonData)
                    {
                        LeftMenuListViewModel son = new LeftMenuListViewModel
                        {
                            Title = sonItem.Title,
                            Link = sonItem.Link,
                            Icon = sonItem.Icons
                        };
                        sonList.Add(son);
                    }
                    //下面填充的内容为直接展示的内容
                    LeftMenuListViewModel lmlvm = new LeftMenuListViewModel
                    {
                        Title = item.Title,
                        Icon = item.Icons,
                        Link = item.Link,
                        SonList = sonList
                    };

                    list.Add(lmlvm);
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                return null;
            }
            
        }
    }
}