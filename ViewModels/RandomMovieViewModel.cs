using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoRe.Models;

namespace MoRe.ViewModels
{
    public class CustomerFormViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Genres> Genres { get; set; }
        public Movie Movie { get; set; }
        

    }   
}