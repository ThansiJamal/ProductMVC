using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("AddProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Brand", product.Brand);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.ExecuteNonQuery();
            connect.Close();
            return View();
        }
        public ActionResult ListProduct()
        {
            List<Product> products = new List<Product>();
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("ListProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product product = new Product();
                product.Id = (int)dr["Id"];
                product.Name = (string)dr["Name"];
                product.Brand = (string)dr["Brand"];
                product.Quantity = (string)dr["Quantity"];
                product.Price = (string)dr["Price"];
                products.Add(product);
            }
            connect.Close();
            return View(products);
        }
        public ActionResult EditProduct(int id)
        {
            Product product = new Product();
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmdd = new SqlCommand("DetailProduct", connect);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmdd.ExecuteReader();
            dr.Read();
            //product.Id = (int)dr["Id"];
            product.Name = (string)dr["Name"];
            product.Brand = (string)dr["Brand"];
            product.Quantity = (string)dr["Quantity"];
            product.Price = (string)dr["Price"];
            dr.Close();

            SqlCommand cmd = new SqlCommand("EditProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Brand", product.Brand);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.ExecuteReader();
            connect.Close();
            return View(product);

        }
        public ActionResult DetailsProduct(int id)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("DetailProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Product product = new Product();
            //product.Id = (int)dr["Id"];
            product.Name = (string)dr["Name"];
            product.Brand = (string)dr["Brand"];
            product.Quantity = (string)dr["Quantity"];
            product.Price = (string)dr["Price"];
            connect.Close();
            return View(product);
        }
        public ActionResult DeleteProduct(int id)
        {
            Product product = new Product();
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmdd = new SqlCommand("DetailProduct", connect);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmdd.ExecuteReader();
            dr.Read();
            //product.Id = (int)dr["Id"];
            product.Name = (string)dr["Name"];
            product.Brand = (string)dr["Brand"];
            product.Quantity = (string)dr["Quantity"];
            product.Price = (string)dr["Price"];
            dr.Close();

            SqlCommand cmd = new SqlCommand("DeleteProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            connect.Close();
            return View(product);
        }
    }
}