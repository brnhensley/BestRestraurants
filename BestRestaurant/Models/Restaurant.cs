using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public string Name {get; set;}
    public string Type {get; set;}
    public int Id {get; set;}

    public Restaurant (string name, string type, int id = 0)
    {
      Name = name;
      Type = type;
      Id = id;
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM  restaurants;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        string type = rdr.GetString(2);
        int id = rdr.GetInt32(0);

        Restaurant newRestaurant = new Restaurant(name, type, id);
        allRestaurants.Add(newRestaurant);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRestaurants;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `restaurants` (`name`, `type`) VALUES (@RestaurantName, @RestaurantType);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@RestaurantName";
      name.Value = this.Name;

      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@RestaurantType";
      type.Value = this.Type;


      cmd.Parameters.Add(name);
      cmd.Parameters.Add(type);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Restaurant Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `restaurants` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string cuisineName = "";
      string cuisineType = "";
      int cuisineId = 0;

      while (rdr.Read())
      {
        cuisineName = rdr.GetString(1);
        cuisineType = rdr.GetString(2);
        cuisineId = rdr.GetInt32(0);
      }

      Restaurant foundRestaurant = new Restaurant(cuisineName, cuisineType, cuisineId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundRestaurant;
    }

    public void DeleteRestaurant()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants WHERE id = @RestaurantId;";
      MySqlParameter restaurantIdParameter = new MySqlParameter();
      restaurantIdParameter.ParameterName = "@RestaurantId";
      restaurantIdParameter.Value = this.Id;
      cmd.Parameters.Add(restaurantIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if (!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool nameEquality = (this.Name == newRestaurant.Name);
        bool typeEquality = (this.Type == newRestaurant.Type);
        bool idEquality = (this.Id == newRestaurant.Id);
        return (nameEquality && typeEquality && idEquality);
      }
    }
  }
}
