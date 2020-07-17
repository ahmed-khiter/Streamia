﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamia.Models;
using Streamia.Models.Interfaces;

namespace Streamia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> movieRepository;

        public MoviesController(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie model)
        {
            if (ModelState.IsValid)
            {
                await movieRepository.Add(model);
                return View("Manage");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            return View(await movieRepository.GetAll());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}