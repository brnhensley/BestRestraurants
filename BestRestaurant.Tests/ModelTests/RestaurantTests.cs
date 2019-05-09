using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurant.Models;
using BestRestaurantDatabase;
using System.Collections.Generic;
using System;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class RestaurantTest : IDisposable
  {

    public void Dispose()
    {
      Restaurant.ClearAll();
    }

    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=restaurant_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_RestaurantList()
    {
      //Arrange
      List<Restaurant> newList = new List<Restaurant> { };

      //Act
      List<Restaurant> result = Restaurant.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsRestaurants_RestaurantList()
    // {
    //   //Arrange
    //   Restaurant newRestaurant1 = new Restaurant("Cerebus", "Greece");
    //   newRestaurant1.Save();
    //   Restaurant newRestaurant2 = new Restaurant("Baal", "Egyptian");
    //   newRestaurant2.Save();
    //   List<Restaurant> expectedResult = new List<Restaurant> { newRestaurant1, newRestaurant2 };
    //
    //   //Act
    //   List<Restaurant> actualResult = Restaurant.GetAll();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(expectedResult, actualResult);
    // }

    [TestMethod]
    public void Equals_ReturnsTrueIfNameAreTheSame_Restaurant()
    {
      // Arrange, Act
      Restaurant firstRestaurant = new Restaurant("Baal", "Egyptian");
      Restaurant secondRestaurant = new Restaurant("Baal", "Egyptian");

      // Assert
      Assert.AreEqual(firstRestaurant, secondRestaurant);
    }

    [TestMethod]
    public void Save_SavesToDatabase_RestaurantList()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Baal", "Egyptian");
      testRestaurant.Save();

      //Act
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Baal", "Egyptian");

      //Act
      testRestaurant.Save();
      Restaurant savedRestaurant = Restaurant.GetAll()[0];

      int result = savedRestaurant.Id;
      int testId = testRestaurant.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRestaurant_Restaurant()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Baal", "Egyptian");
      testRestaurant.Save();

      //Act
      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.Id);

      //Assert
      Assert.AreEqual(testRestaurant, foundRestaurant);
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
