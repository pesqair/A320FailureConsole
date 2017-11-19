using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A320FailureConsole.Models
{
    public class ACSystem
    {
        public int ACSystemID { get; set; }
        [Required()]
        [Display(Name = "System Name")]
        public string ACSystemIDName { get; set; }
        public string Description { get; set; }
        [Required()]
        public string DREF0prefix { get; set; }
        [Display(Name = "Failures")]
        public List<int> FailureID { get; set; }
        public virtual List<Failure> Failures { get; set; }
    }
}