using System;

namespace Users
{
    public class User
    {
        public int id;
        public string name;
        public string username;
        public string email;
        public Address Address;
        public string phone;
        public string webseite;
        public Company Company;
    }

    public class Address
    {
        public string name;
        public string suite;
        public string city;
        public string zipcode;
        public Geo Geo;
    }

    public class Geo
    {
        public string lat;
        public string lng;
    }

    public class Company
    {
        public string name;
        public string catchPhrase;
        public string bs;
    }
}