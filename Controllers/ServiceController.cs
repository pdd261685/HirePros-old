﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HirePros.Data;
using HirePros.Models;
using HirePros.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HirePros.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceDbContext context;

        public ServiceController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        //Get Controller
        public IActionResult Index()
        {
            List<Services> servs = context.Services.ToList();
            return View(servs);
        }

        //Get Controller
        public IActionResult Add()
        {
            AddServiceViewModel addServiceViewModel = new AddServiceViewModel();
            return View(addServiceViewModel);

        }

        //Post Controller

        [HttpPost]
        public IActionResult Add(AddServiceViewModel addServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                Services newService = new Services
                {
                    ServiceName = addServiceViewModel.ServiceName,
                    ServiceDesc = addServiceViewModel.ServiceDesc
                };

                context.Services.Add(newService);
                context.SaveChanges();

                return Redirect("/Service");
            }

            return View(addServiceViewModel);
        }
    }
}