using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoRe.Models;

namespace MoRe.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}