using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System;

namespace Restaurant.Controllers
{
  public class CuisineController : Controller
  {

    [HttpGet("/cuisines")]
    public ActionResult Index()
    {
      List<Cuisine> allCuisines = Cuisine.GetAll();
      return View(allCuisines);
    }

    [HttpGet("/cuisines/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/cuisines")]
    public ActionResult Create(int id, string name, string origin)
    {
      Cuisine newCuisine = new Cuisine(name, origin, id);
      newCuisine.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/cuisines/{id}")]
    public ActionResult Show(int id)
    {
      Cuisine hellbeast = Cuisine.Find(id);
      return View(hellbeast);
    }
  }
}
