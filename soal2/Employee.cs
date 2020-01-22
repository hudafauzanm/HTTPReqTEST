using System;
using System.Collections.Generic;

namespace Employess
{
    public class Employee
    {
      public int id;
      public string avatar_url;
      public string first_name;
      public string last_name;
      public string email;
      public string username;
      public DateTime birthday;
      public List<Addresses> Addresses = new List<Addresses>();
      public List<Phone> Phone = new List<Phone>();
      public string [] presence_list ;
      public int salary;
      public Department Department;
      public Position Position;

    }

    public class Addresses
    {
        public string name;
        public string address;
        public string city;
    }

    public class Phone
    {
        public string label;
        public string phone;
    }

    public class Department
    {
        public string name;
    }
    public class Position
    {
        public string name;
    }
}
