using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blockbuster.Models;

namespace blockbuster.Dto
{
    public class NewRentalsDto
    {
        public int CustomerId{ get; set; }
        public List<int> MovieIds { get; set; }
    }
}