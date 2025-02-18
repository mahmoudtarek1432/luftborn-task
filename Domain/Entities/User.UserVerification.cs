using SharedKernel.Guards;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserVerification : IValueObject
    {
        public string VerifyCode { get; private set; }
        public int VerifyTries { get; private set; }
        public DateTime VerifyTime { get; private set; }

        private int CodeExpiryTime = 10; //in minutes
        public bool IsActive {get; set;}

        public UserVerification SetVerifyCode(string verifyCode)
        {
            VerifyCode = verifyCode;
            VerifyTime = DateTime.UtcNow;
            VerifyTries++;

            return this;
        }

        public UserVerification SetIsActive(bool isActive)
        {
            IsActive = isActive;

            return this;
        }

        public UserVerification ValidateOTP(string otp)
        {
            if (VerifyCode != otp)
                throw new BusinessLogicException("The Verification Code is not correct");
            if (VerifyTime.AddMinutes(CodeExpiryTime) < DateTime.UtcNow)
                throw new BusinessLogicException("Verification code has expired");

            IsActive = true;

            return this;
        }

        public UserVerification ValidateUserIsActive()
        {
            if (IsActive)
                return this;
            throw new BusinessLogicException("User is not active!");
        }
    }
}
