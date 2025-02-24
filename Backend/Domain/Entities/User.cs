﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;
using SharedKernel.Guards;
using SharedKernel.Interfaces;

namespace Domain.Entities
{
    public class User : EntityBase, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public string HashedPassword { get; private set; }
        public UserVerification UserVerification { get; set; }
        public string Role { get; private set; }
 
        public User(string firstName, string lastName, string email, string password) : this()
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
        }

        public User SetUserInfo(string firstName, string lastName, string email, string mobile)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetMobile(mobile);

            return this;
        }
        public void SetId(Guid id)
        {
            Id = id;
        }
        public User SetPassword(string password)
        {
            Guard.Against.NullOrWhiteSpace(password, nameof(password));

            HashedPassword = PasswordHash(password);

            return this;
        }

        public User ValidateFirstName(string firstName)
        {
            Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));

            return this;
        }

        public User SetFirstName(string firstName)
        {
            FirstName = firstName;

            return this;
        }

        public User ValidateLastName(string lastName)
        {
            Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));

            return this;
        }

        public User SetLastName(string lastName)
        {
            LastName = lastName;

            return this;
        }

        public User ValidateEmail(string email)
        {
            Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Guard.Against.ValidateEmail(email, nameof(email));

            return this;
        }

        public User SetEmail(string email)
        {
            Email = email;

            return this;
        }

        public User ValidateMobile(string mobile)
        {
            Guard.Against.NullOrWhiteSpace(mobile, nameof(mobile));
            Guard.Against.ValidateMobile(mobile, nameof(mobile));

            return this;
        }

        public User SetMobile(string mobile)
        {
            Mobile = mobile;

            return this;
        }

        public User ValidateRegistration(IReadOnlyList<string> mobilesExist)
        {
            ValidateFirstName(FirstName);
            ValidateLastName(LastName);
            ValidateEmail(Email);
            ValidateMobile(Mobile);

            return this;
        }

        public User ValidateLogin(string loginPassword)
        {
            ValidatePassword(loginPassword);
            return this;

        }

        public User ValidatePassword(string loginPassword)
        {
            var hashedLoginPassword = PasswordHash(loginPassword);
            if (hashedLoginPassword == HashedPassword)
                return this;
            throw new BusinessLogicException("Wrong Password");
        }

        public User SetRole(string role)
        {
            Role = role;
            return this;
        }

        private string PasswordHash(string password)
        {
            return Convert.ToBase64String(SHA1.HashData(Encoding.UTF8.GetBytes(password)));
        }

        public User SetUserVerification(UserVerification userVerification)
        {
            UserVerification = userVerification;
            return this;
        }

        public AuthenticationInfo TokenAuthInfo()
        {
            return new AuthenticationInfo
            {
                UserID = Id,
                UserName = this.ToString(),
                Email = Email,
                Mobile = Mobile,
                PRole = Role
            };
        }

        private User() 
        {
            SetId(Guid.Empty);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
