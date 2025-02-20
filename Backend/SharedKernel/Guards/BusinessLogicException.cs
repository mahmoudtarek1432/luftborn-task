using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Guards
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException()
        {
            
        }
        public BusinessLogicException(string message) : base(message)
        {

        }
    }
}
