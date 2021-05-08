using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//This is added in so that the "Required" annotations below work

namespace MyApplication.Models
{
    public class Info
    {
        //[Required(ErrorMessage = "Required field")]
        public String infoId { get; set; }
        //[Required(ErrorMessage ="Required field")]
        public String idUser { get; set; }
       // [Required(ErrorMessage = "Required field")]
        public String TelNo { get; set; }
       // [Required(ErrorMessage = "Required field")]
        public String CellNo { get; set; }
      //  [Required(ErrorMessage = "Required field")]
        public String AddressLine1 { get; set; }
      //  [Required(ErrorMessage = "Required field")]
        public String AddressLine2 { get; set; }
     //   [Required(ErrorMessage = "Required field")]
        public String AddressLine3 { get; set; }
      //  [Required(ErrorMessage = "Required field")]
        public String AddressCode { get; set; }
      //  [Required(ErrorMessage = "Required field")]
        public String PostalAddress1 { get; set; }
      //  [Required(ErrorMessage = "Required field")]
        public String PostalAddress2 { get; set; }
    //    [Required(ErrorMessage = "Required field")]
        public String PostalCode { get; set; }
    }
}