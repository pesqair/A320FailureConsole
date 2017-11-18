using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A320FailureConsole.Models
{
    public class Failure
    {
        public int FailureID { get; set; }
        [Required()]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ACSystemID { get; set; }
        public virtual ACSystem ParentSystem { get; set; }
        [Required()]
        public string DREF0suffix { get; set; }
        public float FailValue { get; set; }
        public float FixValue { get; set; }
    }
}