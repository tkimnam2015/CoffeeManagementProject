﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Role { get; set; }
        public bool? Active { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
