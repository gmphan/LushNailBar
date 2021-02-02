using System;
using System.Collections.Generic;
using System.Linq;
using LushNailBar.Data;
using LushNailBar.Models;
using LushNailBar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LushNailBar.Controllers
{
    public class ServiceController : Controller
    {
        private readonly DatabaseContext _db;
        List<Service> serviceList;
        HomeViewModel homeViewModel; 

        public ServiceController(DatabaseContext db)
        {
            _db = db;
            serviceList = _db.Service.ToList();
            homeViewModel = new HomeViewModel(serviceList);
        }

        public IActionResult Index()
        {
            
            return View(homeViewModel);
        }

        public IActionResult Create()
        {
            return View(homeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomeViewModel obj)
        {
            // ModelSate.IsValid checking base on [Required] from Sevice model
            // This is for server validation 
            if(ModelState.IsValid)
            {
                Service newService = new Service();
                newService.ServiceType = obj.Service.ServiceType;
                newService.ServiceName = obj.Service.ServiceName;
                newService.ServicePrice = obj.Service.ServicePrice;
                newService.Description = obj.Service.Description;
                // newService.SortByType = 1;
                newService.CreatedDate = DateTime.Now;
                newService.UpdatedDate = DateTime.Now;
                _db.Service.Add(newService);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeViewModel);
        }

        // Get (Edit)
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Service serviceObj = _db.Service.Find(id);
            // _db.Entry(serviceObj).State = EntityState.Detached;
            if(serviceObj == null)
            {
                return NotFound();
            }
            return View(serviceObj);
        }

        // POST (Edit)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service updatedService)
        {
            // _db.Entry(updatedService).State = EntityState.Detached;
            if(ModelState.IsValid)
            {
                // catching the tracked instance into service 
                // then reassign the values to updating fields
                // then save it without doing db update the dbcontext take care of the update.
                // I don't understand this completely and need to read more about it. 
                // doing update without catching the instance, the dbcontext package will complain
                // about an existing instance is being tracked using the same id

                // var service = _db.Service.Where(p => p.Id == updatedService.Id).FirstOrDefault();
                var service = _db.Service.FirstOrDefault(p => p.Id == updatedService.Id); //shortcut of the above
                service.ServiceName = updatedService.ServiceName;
                service.ServiceType = updatedService.ServiceType;
                service.ServicePrice = updatedService.ServicePrice;
                service.Description = updatedService.Description;
                // _db.Service.Update(updatedService);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            // https://github.com/dotnet/efcore/issues/7064
            return View(updatedService);
        }

        // Get (Delete)
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Service serviceObj = _db.Service.Find(id);
            // _db.Entry(serviceObj).State = EntityState.Detached;
            if(serviceObj == null)
            {
                return NotFound();
            }
            return View(serviceObj);
        }

        // POST (Delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        // can't have same Delete name like above becuase the paramenter is same, too 
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Service.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Service.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}