using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZCorp.WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        //[Required] //test for bad request
        public string Name { get; set; }
        public int Points { get; set; }
    }
}