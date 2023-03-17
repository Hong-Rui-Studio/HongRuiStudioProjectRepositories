using HRKJ.IService;
using HRKJ.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PagedList;
using HRKJ.WebApp.Areas.Manager.Data.ExamInfos;
using HRKJ.WebApp.App_Start;

namespace HRKJ.WebApp.Areas.Manager.Controllers
{
    public class ExamInfosManagerController : Controller
    {
        private IExamInfosBll examInfosSvc = new ExamInfosBll(); 
        private ISubjectsBll subjectsSvc = new SubjectsBll();
        [HttpGet]
        public async Task<ActionResult> List(string search,int page =1)
        {
            search = string.IsNullOrEmpty(search) ? "" : search;
            var data = await examInfosSvc.GetExamInfosByTitleAsync(search);
            IPagedList<ExamInfosListViewModel> pages = data.Select(e => new ExamInfosListViewModel 
            {
                Id = e.Id,
                Title= e.Title,
                ExamDate = e.ExamDate.ToString("yyyy-MM-dd"),
                SubjectsNames = GetSubjects(e.SubjectsId),
                UpdateTime = e.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToPagedList(page,PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }


        [HttpGet]
        public ActionResult Add()
        {
            GetAllSubjects(null);
            return View(new ExamInfosAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(ExamInfosAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await examInfosSvc.AddExamInfosAsync(model.Title, model.ExamDate, string.Join(",", model.SubjectIdList));
                if(res > 0)
                    return RedirectToAction("List", "ExamInfosManager");
            }
            GetAllSubjects(null);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var data = await examInfosSvc.GetExamInfosByIdAsync(id);
            if (data == null || string.IsNullOrEmpty(data.Title))
                return RedirectToAction("List", "ExamInfosManager");

            GetAllSubjects(data.SubjectsId);
            return View(new ExamInfosEditViewModel 
            {
                Id = data.Id,
                Title = data.Title,
                ExamDate = data.ExamDate,
                SubjectIdList = data.SubjectsId.Split(',')
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ExamInfosEditViewModel model) 
        {
            var idList = string.Join(",", model.SubjectIdList);
            if (ModelState.IsValid) 
            {
                var res = await examInfosSvc.EditExamInfosAsync(model.Id, model.Title, model.ExamDate, idList);
                if (res > 0)
                    return Redirect("../../../Manager/ExamInfosManager/List");
            }
            GetAllSubjects(string.Join(",", idList));
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            await examInfosSvc.DeleteExamInfosAsync(id);
            return RedirectToAction("List", "ExamInfosManager");

        }




        private void GetAllSubjects(string idList) 
        {
            var data = subjectsSvc.GetAllSubjects();
            List<ChooseSubjectsViewModel> list = null;
            if (idList == null)
            {
                list = new List<ChooseSubjectsViewModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    list.Add(new ChooseSubjectsViewModel { Id = data[i].Id, Title = data[i].Title, IsChoose = false });
                }
            }
            else 
            {
                list = new List<ChooseSubjectsViewModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    if (idList.Contains(data[i].Id.ToString()))
                    {
                        list.Add(new ChooseSubjectsViewModel { Id = data[i].Id, Title = data[i].Title, IsChoose = true });
                    }
                    else 
                    {
                        list.Add(new ChooseSubjectsViewModel { Id = data[i].Id, Title = data[i].Title, IsChoose = false });
                    }
                    
                }
            }
            ViewBag.SubjectsList = list;
            
        }


        private string GetSubjects(string subjectIds) 
        {
            var idList = subjectIds.Split(',');
            var titleList = "";
            for (var i= 0; i < idList.Length;i++) 
            {
                var data = subjectsSvc.GetSubjectsById(int.Parse(idList[i]));
                titleList += data.Title;
                if (i < idList.Length - 1) 
                {
                    titleList+= ",";
                }
            }
            return titleList;
        }
    }
}