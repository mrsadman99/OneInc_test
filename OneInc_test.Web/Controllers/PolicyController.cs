using Newtonsoft.Json;
using OneInc_test.Core.Entities;
using OneInc_test.Web.Converters;
using OneInc_test.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace OneInc_test.Web.Controllers
{
    public class PolicyController : Controller
    {
        private readonly HttpClient _client = new HttpClient();
        
        public PolicyController()
        {
            _client.BaseAddress = new Uri("http://localhost:44301/");
        }
        public async Task<ActionResult> Index()
        {
            var result = await _client.GetAsync("api/PolicyAPI");
            IEnumerable<PolicyDtoCreated> policies;
            if (result.IsSuccessStatusCode)
            {
                policies=await result.Content
                    .ReadAsAsync<List<PolicyDtoCreated>>();
            }
            else
            {
                policies = Enumerable.Empty<PolicyDtoCreated>();
                ModelState.AddModelError(string.Empty
                    , "Cannot get policies");
            }
            return View(policies);
        }

        [System.Web.Mvc.HttpPost, 
            System.Web.Mvc.Route("Policy/filtered/{filter}")]
        public async Task<ActionResult> GetByOption(Models.Filter filter)
        {
            var result = await _client.PostAsync("api/PolicyAPI/filtered"
                ,Serializer.ToStringContent(filter));
            
            if (result.IsSuccessStatusCode)
            {
                ViewBag.updateDate = filter.updateDate;
                ViewBag.name = filter.name;
                ViewBag.surname = filter.surname;
                ViewBag.state = filter.state;
                ViewBag.objectName = filter.objectName;
                ViewBag.nameSelected = filter.nameSelected;

                if (filter.nameSelected)
                {
                    var content = await result.Content
                    .ReadAsAsync<List<Owner>>();
                    if(content!=null)
                        return PartialView("~/Views/Policy/_ownerCollection.cshtml"
                            ,content);
                }
                else
                {
                    var content = await result.Content
                    .ReadAsAsync<List<PolicyDtoCreated>>();
                    if (content != null)
                        return PartialView("~/Views/Policy/_policyCollection.cshtml"
                        , content);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _client.GetAsync("api/PolicyAPI/"+id);
            if (result.IsSuccessStatusCode)
            {
                var policy = await result.Content
                    .ReadAsAsync<PolicyDtoCreated>();
                if (policy != null)
                    return View(policy);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var result = await _client.GetAsync("api/PolicyAPI/" + id);
            if (result.IsSuccessStatusCode)
            {
                var policy = await result.Content
                    .ReadAsAsync<PolicyDtoCreated>();
                if (policy != null)
                {
                    return View(policy);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "Id,UpdateDate,ObjectType,ObjectName,NameOwner,SurnameOwner")]
                PolicyEdit editPolicy)
        {
            var fullPolicy = await BindWithUnmodified(editPolicy);
            if (fullPolicy == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                var result = await _client.PostAsync("api/PolicyAPI"
                , Serializer.ToStringContent(fullPolicy));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                if (result.StatusCode == HttpStatusCode.Conflict)
                {
                    ModelState.AddModelError(string.Empty, "The record you attempted to delete "
                    + "was modified by another user");
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(fullPolicy);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var result = await _client.GetAsync("api/PolicyAPI/" + id);
            if (result.IsSuccessStatusCode)
            {
                var policy = await result.Content
                    .ReadAsAsync<PolicyDtoCreated>();
                if (policy == null)
                {
                    return HttpNotFound();
                }
                return View(policy);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(
            [Bind(Include = "Id,UpdateDate,ObjectType,ObjectName,NameOwner,SurnameOwner")]
        PolicyEdit deletedPolicy)
        {
            var result =await _client.DeleteAsync("api/PolicyAPI/"+deletedPolicy.Id);
            switch (result.StatusCode){
                case HttpStatusCode.Conflict:
                    var fullPolicy= await BindWithUnmodified(deletedPolicy);
                    if (fullPolicy == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    
                    ModelState.AddModelError(string.Empty, "The record you attempted to delete "
                        + "was modified by another user");
                    return View(fullPolicy);
                
                case HttpStatusCode.BadRequest:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View(new PolicyDtoCreate());
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PolicyDtoCreate newPolicy)
        {
            if (ModelState.IsValid)
            {
                var result=await _client.PutAsync("api/PolicyAPI"
                    , Serializer.ToStringContent(newPolicy));
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(newPolicy);
        }

        public ActionResult GetFilter(
            [Bind(Include= "updateDate,name,surname,state,objectName,nameSelected")]
        Models.Filter filter)
        {
            return PartialView("~/Views/Policy/_filter.cshtml",filter);
        }

        private async Task<PolicyDtoCreated> BindWithUnmodified(PolicyEdit editData)
        {
            var result = await _client.GetAsync("api/PolicyAPI/" + editData.Id);
            if (result.IsSuccessStatusCode)
            {
                var policy = await result.Content
                    .ReadAsAsync<PolicyDtoCreated>();
                if (policy!=null)
                    return editData.Convert(policy);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _client.Dispose();
            base.Dispose(disposing);
        }
    }
}