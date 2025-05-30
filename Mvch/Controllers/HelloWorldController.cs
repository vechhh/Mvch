﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Mvch.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Привет" + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}
