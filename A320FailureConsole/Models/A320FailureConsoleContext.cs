using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace A320FailureConsole.Models
{
    public class A320FailureConsoleContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public A320FailureConsoleContext() : base("name=A320FailureConsoleContext")
        {
        }

        public System.Data.Entity.DbSet<A320FailureConsole.Models.ACSystem> ACSystems { get; set; }

        public System.Data.Entity.DbSet<A320FailureConsole.Models.Failure> Failures { get; set; }
    }
}
