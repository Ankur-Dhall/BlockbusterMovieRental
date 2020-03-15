using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blockbuster.Models;

namespace blockbuster.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }


    }
}