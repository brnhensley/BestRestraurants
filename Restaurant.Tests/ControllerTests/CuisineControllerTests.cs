using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Restaurant.Controllers;
using Restaurant.Models;

namespace Restaurant.Tests
{
  [TestClass]
  public class CuisineControllerTest
  {


    // public CuisineTest()
    // {
    //   DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=restaurant_tests;";
    // }

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    {
      //Arrange
      CuisineController controller = new CuisineController();

      //Act
      IActionResult view = controller.Create(1, "Italian", "Italy");

      //Assert
      Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
      //Arrange
      CuisineController controller = new CuisineController();
      RedirectToActionResult actionResult = controller.Create(1, "Italian", "Italy") as RedirectToActionResult;

      //Act
      string result = actionResult.ActionName;

      //Assert
      Assert.AreEqual(result, "Index");
    }

  }
}
