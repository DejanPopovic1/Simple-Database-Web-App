using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace MyApplication.Models
{
    public class MainPageModel
    {
        public int idUser { get; set; }//included
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //[NotMapped]
        public string ConfirmPassword { get; set; }

        public int infoId { get; set; }//included
        //public int idUser { get; set; }
        public String TelNo { get; set; }
        public String CellNo { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressLine3 { get; set; }
        public String AddressCode { get; set; }
        public String PostalAddress1 { get; set; }
        public String PostalAddress2 { get; set; }
        public String PostalCode { get; set; }

        public User makeUser()
        {
            User u = new User();
            u.idUser = idUser;//Added
            u.id = id;
            u.FirstName = FirstName;
            u.LastName = LastName;
            u.Email = Email;
            u.Password = CreateMD5(Password);
            u.ConfirmPassword = CreateMD5(ConfirmPassword);
            return u;
        }

        public Info makeInfo() {
            Info i = new Info();
            i.infoId = infoId;//Added
            i.TelNo = TelNo;
            i.CellNo = CellNo;
            i.AddressLine1 = AddressLine1;
            i.AddressLine2 = AddressLine2;
            i.AddressLine3 = AddressLine3;
            i.AddressCode = AddressCode;
            i.PostalAddress1 = PostalAddress1;
            i.PostalAddress2 = PostalAddress2;
            i.PostalCode = PostalCode;
            return i;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }









    }
}