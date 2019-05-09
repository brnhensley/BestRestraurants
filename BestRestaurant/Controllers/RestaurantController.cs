using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;

namespace BestRestaurant.Controllers
{
  public class RestaurantController : Controller
  {

    [HttpGet("/restaurants")]
    public ActionResult Index()
    {
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      return View(allRestaurants);
    }

    [HttpGet("/restaurants/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/restaurants")]
    public ActionResult Create(string name, string restaurantType, int id)
    {
      Restaurant newRestaurant = new Restaurant(name, restaurantType, id);
      newRestaurant.Save();
      return RedirectToAction("Index");
    }

    [HttpPost("/restaurants/delete")]
    public ActionResult DeleteAll()
    {
      Restaurant.ClearAll();
      return RedirectToAction("Index");

    }

    [HttpPost("/restaurants/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Restaurant foundRestaurant = Restaurant.Find(id);
      foundRestaurant.DeleteRestaurant();
      return RedirectToAction("Index");
      // return View();
    }

    [HttpGet("/restaurants/{id}")]
    public ActionResult Show(int id)
    {
      Restaurant restaurant = Restaurant.Find(id);
      return View(restaurant);
    }
  }
}
