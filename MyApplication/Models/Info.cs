using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//This is added in so that the "Required" annotations below work
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApplication.Models
{
    public class Info
    {
        [Key, Column(Order = 1)]//Added
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]//Added
        //[Required(ErrorMessage = "Required field")]
        public int infoId { get; set; }
        //[Required(ErrorMessage ="Required field")]
        public int idUser { get; set; }
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