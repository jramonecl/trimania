using System;
using System.Runtime.CompilerServices;
using TriMania.Domain.Base;
using TriMania.Domain.Shopping;
using TriMania.Domain.User.Repositories;
using TriMania.Domain.User.Rules;

namespace TriMania.Domain.User
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(string Name, string Login, string Password, string Cpf, string Email, DateTime Birthday,
            string Street, string Neighborhood, int Number,
            string City, string State)
        {
            this.Name = Name;
            this.Login = Login;
            this.Password = Password;
            this.Cpf = Cpf;
            this.Email = Email;
            this.Birthday = Birthday;
            CreationDate = DateTime.Now;
            Address = Address.Create(Street, Neighborhood, Number, City, State);
        }

        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthday { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Address Address { get; private set; }

        public User(string Name, string Login, string Password, string Cpf, string Email,
            DateTime Birthday, Address Address)
        {
            this.Name = Name;
            this.Login = Login;
            this.Password = Password;
            this.Cpf = Cpf;
            this.Email = Email;
            this.Birthday = Birthday;
            CreationDate = DateTime.Now;
            this.Address = Address;
        }
        public static User CreateNew(string Name, string Login, string Password, string Cpf, string Email,
            DateTime Birthday, string Street, string Neighborhood, int Number,
            string City, string State)
        {
            return new(Name, Login, Password, Cpf, Email, Birthday, Street, Neighborhood, Number, City, State);
        }

        public void Update(string requestName, string computeHash, string requestEmail, DateTime requestBirthday)
        {
            this.Name = requestName;
            this.Password = computeHash;
            this.Email = requestEmail;
            this.Birthday = requestBirthday;
        }
    }
}