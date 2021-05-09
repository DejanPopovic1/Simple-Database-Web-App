using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Models;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Routing;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        private DB_Entities _db = new DB_Entities();

        // GET: Home
        public ActionResult Index(string id)
        {
            if (Session["idUser"] != null)
            {
                MainPageModel mpm = getMainPageModel(id);//Fetch all data from database and saves it in mpm object
                ViewData["mpm"] = mpm;
                return View(mpm);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //I'm using parameterised queries as opposed to concatenated strings to avoid SQL Injection attacks
        public MainPageModel getMainPageModel(string idKey)
        {
            //idKey = "8704025959080";
            var connString = ConfigurationManager.ConnectionStrings["Authentication"].ToString();
            MainPageModel matchingPerson = new MainPageModel();
            using (SqlConnection myConnection = new SqlConnection(connString))
            {
                string sqlQuery = "SELECT Users.idUser, Info.idUser, id, FirstName, LastName, Password, email, Info.infoId, TelNo, CellNo, AddressLine1, AddressLine2, AddressLine3, AddressCode, PostalAddress1, PostalAddress2, PostalCode FROM Users, Info WHERE Users.idUser = Info.idUser";
                SqlCommand oCmd = new SqlCommand(sqlQuery, myConnection);
                var idKeyParam = new SqlParameter("@idKey", SqlDbType.NVarChar) {Value = idKey };
                oCmd.Parameters.Add(idKeyParam);
                myConnection.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    matchingPerson.idUser = Convert.ToInt32(oReader["idUser"]);
                    matchingPerson.infoId = Convert.ToInt32(oReader["infoId"]);
                    matchingPerson.id = oReader["id"].ToString();
                    matchingPerson.FirstName = oReader["FirstName"].ToString();
                    matchingPerson.LastName = oReader["LastName"].ToString();
                    matchingPerson.Email = oReader["Email"].ToString();
                    matchingPerson.TelNo = oReader["TelNo"].ToString();
                    matchingPerson.CellNo = oReader["CellNo"].ToString();
                    matchingPerson.AddressLine1 = oReader["AddressLine1"].ToString();
                    matchingPerson.AddressLine2 = oReader["AddressLine2"].ToString();
                    matchingPerson.AddressLine3 = oReader["AddressLine3"].ToString();
                    matchingPerson.AddressCode = oReader["AddressCode"].ToString();
                    matchingPerson.PostalAddress1 = oReader["PostalAddress1"].ToString();
                    matchingPerson.PostalAddress2 = oReader["PostalAddress2"].ToString();
                    matchingPerson.PostalCode = oReader["PostalCode"].ToString();
                }
                myConnection.Close();
            }
            return matchingPerson;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(MainPageModel mpm)
        {
            System.Diagnostics.Debug.WriteLine("Before Modification");
            System.Diagnostics.Debug.WriteLine(mpm.idUser);
            System.Diagnostics.Debug.WriteLine(mpm.infoId);
            Info inf = mpm.makeInfo();
            User usr = mpm.makeUser();
            inf.idUser = mpm.idUser;
            if (ModelState.IsValid)
            {
                _db.Entry(inf).State = EntityState.Modified;
                _db.Entry(usr).State = EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch(DbEntityValidationException e) {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(mpm);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Cannot pass the entire model as an argument because then we are posting the whole data set where we are actually only posting the email and password
        public ActionResult Login(string email, string password)
        {
            Console.Write("Login Failed");
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().idUser;
                    string idString = data.FirstOrDefault().id;
                    return RedirectToAction("Index", new { id = idString});
                }
                else
                {
                    ModelState.AddModelError("", "The username and / or password is incorrect");
                    return View();
                }
            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}