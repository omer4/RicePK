using RicePK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace RicePK.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(string Username, string UserPassword,string UserType)
        {
            tblUser objUser = new tblUser();
            try
            {
                //create new sqlconnection and connection to database by using connection string from web.config file  
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Helper.GetString();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tblUser WHERE (UserName COLLATE Latin1_General_CS_AS = @UserName) AND (UserPassword COLLATE Latin1_General_CS_AS = @UserPassword)", conn);

                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();

                da.Fill(dt);
                

                //int i = cmd.ExecuteNonQuery()
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["UserType"] = "Admin";
                    if (string.IsNullOrEmpty(dt.Rows[0]["UserType"].ToString()))
                    {
                       
                        return RedirectToAction("Index", "DailyRatelist");
                    }
                  else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return RedirectToAction("Index", "Login");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult logout()
        {
            try
            {
                Session.Remove("UserType");
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}