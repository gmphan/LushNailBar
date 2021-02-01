using System;
using System.Collections.Generic;
using System.Linq;
using LushNailBar.Data;
using LushNailBar.Models;
using LushNailBar.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            }
            return RedirectToAction("Index");
        }
    }
}