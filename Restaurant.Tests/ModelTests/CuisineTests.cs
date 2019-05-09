using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Models;
using RestaurantDatabase;
using System.Collections.Generic;
using System;

namespace Restaurant.Tests
{
  [TestClass]
  public class CuisineTest : IDisposable
  {

    public void Dispose()
    {
      Cuisine.ClearAll();
    }

    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=restaurant_tests;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_CuisineList()
    {
      //Arrange
      List<Cuisine> newList = new List<Cuisine> { };

      //Act
      List<Cuisine> result = Cuisine.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsCuisines_CuisineList()
    // {
    //   //Arrange
    //   Cuisine newCuisine1 = new Cuisine("Cerebus", "Greece");
    //   newCuisine1.Save();
    //   Cuisine newCuisine2 = new Cuisine("Baal", "Egyptian");
    //   newCuisine2.Save();
    //   List<Cuisine> expectedResult = new List<Cuisine> { newCuisine1, newCuisine2 };
    //
    //   //Act
    //   List<Cuisine> actualResult = Cuisine.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(expectedResult, actualResult);
    // }

    [TestMethod]
    public void Equals_ReturnsTrueIfNameAreTheSame_Cuisine()
    {
      // Arrange, Act
      Cuisine firstCuisine = new Cuisine("Baal", "Egyptian");
      Cuisine secondCuisine = new Cuisine("Baal", "Egyptian");

      // Assert
      Assert.AreEqual(firstCuisine, secondCuisine);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CuisineList()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Baal", "Egyptian");
      testCuisine.Save();

      //Act
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Baal", "Egyptian");

      //Act
      testCuisine.Save();
      Cuisine savedCuisine = Cuisine.GetAll()[0];

      int result = savedCuisine.Id;
      int testId = testCuisine.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCuisine_Cuisine()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Baal", "Egyptian");
      testCuisine.Save();

      //Act
      Cuisine foundCuisine = Cuisine.Find(testCuisine.Id);

      //Assert
      Assert.AreEqual(testCuisine, foundCuisine);
    }

//      Adjust this
    // [TestMethod]
    // public void Edit_UpdatesItemInDatabase_String()
    // {
    //   //Arrange
    //   string firstDescription = "Walk the Dog";
    //   Item testItem = new Item(firstDescription);
    //   testItem.Save();
    //   string secondDescription = "Mow the lawn";
    //
    //   //Act
    //   testItem.Edit(secondDescription);
    //   string result = Item.Find(testItem.GetId()).GetDescription();
    //
    //   //Assert
    //   Assert.AreEqual(secondDescription, result);
    // }


  }
}
