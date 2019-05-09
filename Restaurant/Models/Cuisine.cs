using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Restaurant.Models
{
  public class Cuisine
  {
    public string Name {get; set;}
    public string Origin {get; set;}
    public int Id {get; set;}

    public Cuisine (string name, string origin, int id = 0)
    {
      Name = name;
      Origin = origin;
      Id = id;
    }

    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisines = new List<Cuisine>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM  cuisines;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        string origin = rdr.GetString(2);
        int id = rdr.GetInt32(0);

        Cuisine newCuisine = new Cuisine(name, origin, id);
        allCuisines.Add(newCuisine);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCuisines;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM cuisines";
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
      cmd.CommandText = @"INSERT INTO `cuisines` (`name`, `origin`) VALUES (@CuisineName, @CuisineOrigin);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@CuisineName";
      name.Value = this.Name;

      MySqlParameter origin = new MySqlParameter();
      origin.ParameterName = "@CuisineOrigin";
      origin.Value = this.Origin;


      cmd.Parameters.Add(name);
      cmd.Parameters.Add(origin);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Cuisine Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `cuisines` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string cuisineName = "";
      string cuisineOrigin = "";
      int cuisineId = 0;

      while (rdr.Read())
      {
        cuisineName = rdr.GetString(1);
        cuisineOrigin = rdr.GetString(2);
        cuisineId = rdr.GetInt32(0);
      }

      Cuisine foundCuisine = new Cuisine(cuisineName, cuisineOrigin, cuisineId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return foundCuisine;
    }


    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool nameEquality = (this.Name == newCuisine.Name);
        bool originEquality = (this.Origin == newCuisine.Origin);
        bool idEquality = (this.Id == newCuisine.Id);
        return (idEquality && nameEquality && originEquality);
      }
    }
  }
}
