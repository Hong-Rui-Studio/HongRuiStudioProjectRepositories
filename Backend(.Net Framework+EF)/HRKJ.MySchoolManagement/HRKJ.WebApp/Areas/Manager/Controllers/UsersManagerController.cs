using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using HRKJ.Dtos;
using PagedList;
using HRKJ.WebApp.App_Start;
using HRKJ.WebApp.Areas.Manager.Data.Users;
using CodeCarvings.Piczard;
using HRKJ.WebApp.Areas.Manager.Filters;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class UsersManagerController : Controller
    {
        private IUsersBll usersSvc = new UsersBll();
        private IRolesBll rolesSvc = new RolesBll();

        [HttpGet]
        public async Task<ActionResult> List(string search,int page =1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var data = await usersSvc.GetUsersByTitleAsync(search);

            var pageData = data.Select(u => new UsersListViewModel
            {
                Id= u.Id,
                RealName=u.RealName,
                BornDate=u.BornDate.ToString("yyyy-MM-dd"),
                Gender = u.Gender == 1 ? "男" : "女",
                Email=u.Email,
                Phone= u.Phone,
                QQNumBer = u.QQNumber,
                WeChat=u.WeChat,
                RolesTitle = GetRolesByTitle(u.RolesId),
                Photo = u.Photo,
                Images= u.Images,
                UpdateTime = u.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page, PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pageData);
        }

        [HttpGet]
        public async Task<ActionResult> Add() 
        {
            await BindRolesList(null);
            return View(new UsersAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(UsersAddViewModel entity) 
        {
            if (ModelState.IsValid) 
            {
                var imagesArr = UploadFiles(entity.Photo, "../../Contents/upload/users/");
                var pwd = Md5Helper.Encryption(entity.Pwd);

                var res = await usersSvc.AddUsersAsync(entity.RealName, entity.BornDate, entity.Gender, entity.Email, entity.Phone,pwd, entity.QQNumBer, entity.WeChat, entity.RolesId, imagesArr[0], imagesArr[1]);
                if (res > 0)
                    return Redirect("../../Manager/UsersManager/List");
            }
            await BindRolesList(entity.RolesId);
            return View(entity);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var data = await usersSvc.GetUsersByIdAsync(id);
            if(data == null)
              return  Redirect("../../Manager/UsersManager/List");

            await BindRolesList(data.RolesId);

            return View(new UsersEditViewModel 
            {
                Id = data.Id,
                RealName = data.RealName,
                Email   = data.Email,
                Phone = data.Phone,
                QQNumBer    = data.QQNumber,
                BornDate = data.BornDate,
                Gender = data.Gender,
                WeChat = data.WeChat,
                RolesId = data.RolesId,
                Images = data.Photo
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UsersEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                string[] imgList = model.Photo == null || string.IsNullOrEmpty(model.Photo.FileName) ? new string[2] : UploadFiles(model.Photo, "../../Contents/upload/users/");

                var res = await usersSvc.EditUsersAsync(model.Id, model.RealName, model.BornDate, model.Gender, model.Email, model.Phone, model.QQNumBer, model.WeChat, model.RolesId, imgList[0], imgList[1]);
                if(res > 0)
                    return Redirect("../../../Manager/UsersManager/List");

            }

            await BindRolesList(model.RolesId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            var res = await usersSvc.DeleteUsersAsync(id);
            return Redirect("../../Manager/UsersManager/List");
        }

        [HttpGet]
        public async Task<ActionResult> ChangePwd(int id) 
        {
                var data = await usersSvc.GetUsersByIdAsync(id);
                if(data == null)
                return Redirect("../../Manager/UsersManager/List");
                return View(new UsersChangePwdViewModel 
                {
                        Id = data.Id
                });
        }


        [HttpPost]
        public async Task<ActionResult> ChangePwd(UsersChangePwdViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await usersSvc.ChangeUsersPwdAsync(model.Id, model.NewPwd);
                if(res > 0)
                    return   Redirect("../../../Manager/UsersManager/List");
            }
            return View(model);
        }




        private async Task BindRolesList(int? rolesId) 
        {
            var data = await rolesSvc.GetAllRolesAsync();
            SelectList sl = rolesId == null ? new SelectList(data,"Id","Title") 
                                            : new SelectList(data,"Id","Title",rolesId) ;
            ViewBag.RolesList = sl;
        }


        private string GetRolesByTitle(int rolesId) 
        {
            var data = rolesSvc.GetRoleById(rolesId);
            return data == null ? "" : data.Title;
        }

        public string[] UploadFiles(HttpPostedFileBase file, string url)
        {
            if (file != null || !file.FileName.Equals(""))
            {
                Random r = new Random();
                var newName = DateTime.Now.ToString("yyyyMMddHHmmss")
                                    + r.Next(1000, 10000)
                                    + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                var path = Server.MapPath(url + newName);

                file.SaveAs(path); //保存的正常大小的图片

                ImageProcessingJob job = new ImageProcessingJob(); //实例化第三方缩略图插件
                job.Filters.Add(new FixedResizeConstraint(24, 24));
                //202004041437051234_sm.png
                var sm_name = newName.Substring(0, newName.LastIndexOf('.'))
                                     + "_sm"
                                     + newName.Substring(newName.LastIndexOf('.'));
                var sm_path = Server.MapPath(url + sm_name);
                job.SaveProcessedImageToFileSystem(path, sm_path);
                return new string[] { newName, sm_name };
            }

            return new string[] { "default.jpeg", "default.png" };
        }
    }
}