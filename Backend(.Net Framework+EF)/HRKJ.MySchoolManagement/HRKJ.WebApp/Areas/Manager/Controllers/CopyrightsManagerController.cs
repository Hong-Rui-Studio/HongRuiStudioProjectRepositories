using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using HRKJ.IService;
using HRKJ.Service;
using HRKJ.WebApp.Areas.Manager.Data.Copyright;
using CodeCarvings.Piczard;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    public class CopyrightsManagerController : Controller
    {
        private ICopyrightBll copyrightSvc = new CopyrightBll();
        [HttpGet]
        public async Task<ActionResult> Info()
        {
            var data = await copyrightSvc.GetCopyrightInfoAsync();

            return View(new CopyrightInfoViewModel 
            {
                Id = data.Id,
                Title = data.Title,
                Content= data.Content,
                Phone= data.Phone,
                Tel = data.Tel,
                Address= data.Address,
                Photo= data.Photo,
                Images= data.Images,
                Logo= data.Logo,
                SmallLogo= data.SmallLogo,
                Remark1= data.Remark1,
                Remark2= data.Remark2
            });
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(CopyrightInfoViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                int res = 0; 
                var logoList = UploadFiles(model.LogoBase, "../../Contents/upload/copyrights/");
                var photoList = UploadFiles(model.PhotoBase, "../../Contents/upload/copyrights/");
                if (model.Id == 0)
                {
                   
                    res = await copyrightSvc.AddCopyrightAsync(model.Title, model.Content, model.Phone, model.Tel, model.Address, photoList[0], photoList[1], logoList[0], logoList[1], model.Remark1, model.Remark2);
                }
                else 
                {
                    res = await copyrightSvc.EditCopyrightAsync(model.Id, model.Title, model.Content, model.Phone, model.Tel, model.Address, photoList[0], photoList[1], logoList[0], logoList[1], model.Remark1, model.Remark2);
                }
                if (res > 0)
                    return RedirectToAction("Info", "CopyrightsManager");
            }
            return View(model);
        }


        private string[] UploadFiles(HttpPostedFileBase file, string url)
        {
            if (file != null && !string.IsNullOrEmpty(file.FileName))
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

            return new string[] { "", "" };
        }
    }
}