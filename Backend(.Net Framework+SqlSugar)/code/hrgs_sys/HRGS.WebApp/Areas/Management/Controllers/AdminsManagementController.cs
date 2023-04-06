using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRGS.IServices;
using System.Threading.Tasks;
using CodeCarvings.Piczard;
using HRGS.WebApp.Areas.Management.Data.Admins;
using PagedList;
using HRGS.Commons;

namespace HRGS.WebApp.Areas.Management.Controllers
{
    public class AdminsManagementController : Controller
    {
        private IRolesService _rolesSvc;
        private IAdminsService _adminsSvc;
        public AdminsManagementController(IRolesService rolesSvc,IAdminsService adminsSvc)
        {
            _adminsSvc = adminsSvc;
            _rolesSvc = rolesSvc;
        }

        [HttpGet]
        public async Task<ActionResult> List(string search="",int page=1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var list =  await _adminsSvc.GetAdminsByNickNameAsync(search);
            List<AdminsListViewModel> alvm = new List<AdminsListViewModel>();
            for (int i = 0,count=0; i < list.Count; i++,count++)
            {
                AdminsListViewModel al = new AdminsListViewModel 
                {
                    Id = list[i].Id,
                    NickName = list[i].NickName,
                    BornDate = list[i].BornDate.ToString("yyyy-MM-dd"),
                    Gender  = list[i].Gender == 1 ? "男":"女",
                    Email = list[i].Email,
                    Photo  = list[i].Photo,
                    Images = list[i].Images,
                    Address = list[i].Address,
                    WeChat  = list[i].WeChat,
                    RolesName = GetRolesTitle(list[i].RolesId),
                    UpdateTime = list[i].UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
                };
                alvm.Add(al);
            }
            IPagedList<AdminsListViewModel> pages = alvm.OrderByDescending(a => a.UpdateTime).ToPagedList(page, PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            await BindRoles(Guid.Empty);
            return View(new AdminsAddViewModel());
        }


        private async Task BindRoles(Guid id) 
        {
            SelectList sl = null;
            var data = await _rolesSvc.GetAllRolesAsync();
            if (id == Guid.Empty)
            {
                sl = new SelectList(data, "Id", "RolesTitle");
            }
            else 
            {
                sl = new SelectList(data, "Id", "RolesTitle",id);
            }
            ViewBag.RolesList = sl;
        }


        private string GetRolesTitle(Guid id) 
        {
            var data = _rolesSvc.GetRolesById(id);
            return data.RolesTitle;
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