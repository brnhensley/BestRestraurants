using System;
using MySql.Data.MySqlClient;
using RestaurantDatabase;
using System.Collections.Generic;

namespace Restaurant.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
