using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BestRestaurant.Controllers;
using BestRestaurant.Models;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class RestaurantControllerTest
  {

    // public RestaurantTest()
    // {
    //   DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=restaurant_test;";
    // }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      RestaurantController controller = new RestaurantController();

      //Act
      IActionResult view = controller.Create("Italian", "Italy", 1);

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      //Arrange
      RestaurantController controller = new RestaurantController();
      RedirectToActionResult actionResult = controller.Create("Italian", "Italy", 1) as RedirectToActionResult;

      //Act
      string result = actionResult.ActionName;

      //Assert
      Assert.AreEqual(result, "Index");
    }

  }
}
