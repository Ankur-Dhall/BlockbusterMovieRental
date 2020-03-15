using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blockbuster.Dto
{
    public class ReturnMoviesDto
    {
        public int customerId { get; set; }
        public List<int> movieIds { get; set; }
    }
}