using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;
using SharedKernel.Guards;
using SharedKernel.Interfaces;

namespace Domain.Entities
{
    public class User : EntityBase<Guid>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public string HashedPassword { get; private set; }
        public string? ResetPasswordCode { get; private set; }
        public DateTime? ResetPasswordExpriy { get; private set; }
        public UserVerification UserVerification { get; set; }
        public Guid Role { get; private set; }
 
        public User(string firstName, string lastName, string email, string password, bool isAdmin) : this()
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
            throw new ArgumentException("Wrong Password");
        }

        public User CreatePasswordResetHash()
        {
            Random random = new Random();
            var hash = Convert.ToBase64String(SHA1.HashData(Encoding.UTF8.GetBytes(random.Next(1000000, 9999999).ToString())));
            ResetPasswordCode = hash;
            ResetPasswordExpriy = DateTime.UtcNow.AddHours(1);
            return this;
        }

        public User ValidateResetToken(string token)
        {
            if (ResetPasswordCode == token && ResetPasswordExpriy > DateTime.UtcNow)
                return this;
            throw new ArgumentException("Invalid Token");
        }

        public User SetRole(Guid role)
        {
            Role = role;
            return this;
        }

        private string PasswordHash(string password)
        {
            return Convert.ToBase64String(SHA1.HashData(Encoding.UTF8.GetBytes(password)));
        }

        private User() 
        {
            SetId(Guid.Empty);
        }
    }
}
