using ProductMVC011KH.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC011KH.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            List<Products> Prod = new List<Products>();
            try
            {  //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True";

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
               // cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Products";
               // cmd.CommandText = "ShowProducts";


                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Prod.Add(new Products { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() });

                }
                dr.Close();
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }


            return View(Prod);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True";

            cn.Open();

            SqlCommand edit = new SqlCommand();
            edit.Connection = cn;
            edit.CommandType = System.Data.CommandType.Text;
            edit.CommandText = "Select * from Products where ProductId = @ProductId";
            edit.Parameters.AddWithValue("@ProductId",id);

            SqlDataReader dr = edit.ExecuteReader();

            Products obj = null;

            if(dr.Read())
            {

                obj = new Products { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() };

            }
            else
            {
                ViewBag.err = "Not Found";
            }

            cn.Close();
            return View(obj);

            //return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True";

            cn.Open();

            SqlCommand edit = new SqlCommand();
            edit.Connection = cn;
            //edit.CommandType = System.Data.CommandType.Text;
            edit.CommandType = System.Data.CommandType.StoredProcedure;
            edit.CommandText = "UpdateProcedure";


            //edit.CommandText = "Update Products set ProductId=@ProductId, ProductName =@ProductName,Rate=@Rate,@Description =@Description,CategoryName = @CategoryName where  ProductId =@ProductId";


            edit.Parameters.AddWithValue("@ProductId",obj.ProductId);
            edit.Parameters.AddWithValue("@ProductName", obj.ProductName);
            edit.Parameters.AddWithValue("@rate", obj.Rate);
            edit.Parameters.AddWithValue("@Description", obj.Description);
            edit.Parameters.AddWithValue("@CategoryName", obj.CategoryName);


            edit.ExecuteNonQuery();
            cn.Close();

            return RedirectToAction("Index");



            //try
            //{


            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
