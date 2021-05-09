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
                MainPageModel mpm = getMainPageModel("8704025959080");
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
            idKey = "8704025959080";
            //Environment.Exit((int)Convert.ToInt64(idKey));
            var connString = ConfigurationManager.ConnectionStrings["Authentication"].ToString();
            MainPageModel matchingPerson = new MainPageModel();
            using (SqlConnection myConnection = new SqlConnection(connString))
            {
                string sqlQuery = @"Select id, FirstName, TelNo, CellNo, AddressLine1, AddressLine2, AddressLine3, AddressCode, PostalAddress1, PostalAddress2, PostalCode" +
                                  " from Users u inner join Info i " +
                                  "on u.id = '8704025959080'";
SqlCommand oCmd = new SqlCommand(sqlQuery, myConnection);
                var idKeyParam = new SqlParameter("@idKey", SqlDbType.NVarChar) {Value = "8704025959080" };
                oCmd.Parameters.Add(idKeyParam);
                //if (idKey == null)
                //{
                //    idKeyParam.Value = DBNull.Value;
                //}
                //oCmd.Parameters.AddWithValue("@idKey", idKey);
                myConnection.Open();



                SqlDataReader oReader = oCmd.ExecuteReader();

                while (oReader.Read())
                {
                    matchingPerson.id = oReader["id"].ToString();
                    matchingPerson.FirstName = oReader["FirstName"].ToString();
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


                //matchingPerson.FirstName = oReader["FirstName"].ToString();
                //matchingPerson.LastName = oReader["LastName"].ToString();
                //matchingPerson.Email = oReader["Email"].ToString();
                //matchingPerson.Password = oReader["Password"].ToString();
                //matchingPerson.TelNo = oReader["TelNo"].ToString();
                //matchingPerson.CellNo = oReader["CellNo"].ToString();
                //matchingPerson.AddressLine1 = oReader["AddressLine1"].ToString();
                //matchingPerson.AddressLine2 = oReader["AddressLine2"].ToString();
                //matchingPerson.AddressLine3 = oReader["AddressLine3"].ToString();
                //matchingPerson.AddressCode = oReader["AddressCode"].ToString();
                //matchingPerson.PostalAddress1 = oReader["PostalAddress1"].ToString();
                //matchingPerson.PostalAddress2 = oReader["PostalAddress2"].ToString();
                //matchingPerson.PostalCode = oReader["PostalCode"].ToString();

                //oCmd.ExecuteNonQuery();
                //using (SqlDataReader oReader = oCmd.ExecuteReader())
                //{
                // oReader.Read();
                // matchingPerson.FirstName = oReader["FirstName"].ToString();
                //while (oReader.Read())
                //{
                //matchingPerson.id = oReader["id"].ToString();
                //matchingPerson.FirstName = oReader["FirstName"].ToString();
                //matchingPerson.LastName = oReader["LastName"].ToString();
                //matchingPerson.Email = oReader["Email"].ToString();
                //matchingPerson.Password = oReader["Password"].ToString();
                //matchingPerson.TelNo = oReader["TelNo"].ToString();
                //matchingPerson.CellNo = oReader["CellNo"].ToString();
                //matchingPerson.AddressLine1 = oReader["AddressLine1"].ToString();
                //matchingPerson.AddressLine2 = oReader["AddressLine2"].ToString();
                //matchingPerson.AddressLine3 = oReader["AddressLine3"].ToString();
                //matchingPerson.AddressCode = oReader["AddressCode"].ToString();
                //matchingPerson.PostalAddress1 = oReader["PostalAddress1"].ToString();
                //matchingPerson.PostalAddress2 = oReader["PostalAddress2"].ToString();
                //matchingPerson.PostalCode = oReader["PostalCode"].ToString();
                //}
                myConnection.Close();
                //}
            }
            return matchingPerson;
        }
















        //public MainPageModel getMainPageModel(string idKey)
        //{
        //    //string connString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Authentication;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\Authentication.mdf";

        //    //string connString = ConfigurationManager.ConnectionStrings["Test"].ToString();
            
        //    var con = ConfigurationManager.ConnectionStrings["Authentication"].ToString();

        //    MainPageModel matchingPerson = new MainPageModel();
        //    using (SqlConnection myConnection = new SqlConnection(con))
        //    {
        //        string oString = "Select * from Users where id=@idKey";
        //        string infoQuery = @"Select id, TelNo, CellNo, AddressLine1, AddressLine2, AddressLine3, AddressCode, PostalAddress1, PostalAddress2, PostalCode
        //                            from Users u
        //                            inner join Info i
        //                            on u.idUser = i.idUser";
        //        SqlCommand oCmd = new SqlCommand(oString, myConnection);
        //        oCmd.Parameters.AddWithValue("@idKey", idKey);
        //        myConnection.Open();
        //        using (SqlDataReader oReader = oCmd.ExecuteReader())
        //        {
        //            while (oReader.Read())
        //            {
        //                matchingPerson.id = oReader["id"].ToString();
        //                //matchingPerson.FirstName = oReader["FirstName"].ToString();
        //                //matchingPerson.LastName = oReader["LastName"].ToString();
        //                //matchingPerson.Email = oReader["Email"].ToString();
        //                matchingPerson.Password = oReader["Password"].ToString();
        //                //matchingPerson.TelNo = oReader["TelNo"].ToString();
        //                //matchingPerson.CellNo = oReader["CellNo"].ToString();
        //                //matchingPerson.AddressLine1 = oReader["AddressLine1"].ToString();
        //                //matchingPerson.AddressLine2 = oReader["AddressLine2"].ToString();
        //                //matchingPerson.AddressLine3 = oReader["AddressLine3"].ToString();
        //                //matchingPerson.AddressCode = oReader["AddressCode"].ToString();
        //                //matchingPerson.PostalAddress1 = oReader["PostalAddress1"].ToString();
        //                //matchingPerson.PostalAddress2 = oReader["PostalAddress2"].ToString();
        //                //matchingPerson.PostalCode = oReader["PostalCode"].ToString();
        //            }
        //            myConnection.Close();
        //        }
        //    }
        //    return matchingPerson;
        //}


























        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(MainPageModel mpm)
        {
            Info inf = mpm.makeInfo();
            User usr = mpm.makeUser();

            usr.FirstName = "Dean";
            usr.LastName = "Popovic";
            usr.idUser = 1;
            inf.infoId = 1;
            inf.idUser = 1;

            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == usr.Email);
                if (check == null)
                {
                    usr.Password = GetMD5(usr.Password);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(usr);
                    _db.Infos.Add(inf);
                    //_db.Entry(_user).State = System.Data.Entity.EntityState.Modified;//Add in Later
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();




            //if (mpm.Model1.id == "123") {
            //    Environment.Exit(-1);
            //}
            return base.Content("<div>Hello</div>", "text/html");
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    //_db.Entry(_user).State = System.Data.Entity.EntityState.Modified;//Add in Later
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        //We cannot pass the entire model as an argument because then we are posting the whole data set where we are actually only posting the email and password
        public ActionResult Login(string email, string password)
        {
            
            Console.Write("Login Failed");
            //String email = usr.Email;
            //String password = usr.Password;

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


                    //get info from database store it in object A calls a cotnroller
                    //MainPageModel mpm = getMainPageModel("8704025959080");

                    //ViewData["mpm"] = mpm;

                    return RedirectToAction("Index", new { id = "8704025959080"});//Pass in A as paramater
                }
                else
                {
                    ModelState.AddModelError("", "The username and / or password is incorrect");//ADDED
                    //ViewBag.ErrorMessage = "Invalid Credentials Supplied";

                    return View();
                    //return RedirectToAction("Login");
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





//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MyApplication.Controllers
//{
//    public class HomeController : Controller
//    {
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }
//    }
//}