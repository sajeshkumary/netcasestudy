using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBookingLibrary.Models
{
    public class UserNotFound : ApplicationException
    {
        public UserNotFound(string message) : base(message)
        {

        }
    }

    public class ProductNotFound : ApplicationException
    {
        public ProductNotFound(string message) : base(message)
        {

        }
    }

    public class NoProductsException : ApplicationException
    {
        public NoProductsException(string message) : base(message)
        {

        }
    }

    public class NoUsersException : ApplicationException
    {
        public NoUsersException(string message) : base(message)
        {

        }
    }

    public class InvalidUser : ApplicationException
    {
        public InvalidUser(string message) : base(message)
        {

        }
    }
    public class InvalidRequest : ApplicationException
    {
        public InvalidRequest(string message) : base(message)
        {

        }
    }

    public class NoRequestsException : ApplicationException
    {
        public NoRequestsException(string message) : base(message)
        {

        }
    }
    public class NoReportsException : ApplicationException
    {
        public NoReportsException(string message) : base(message)
        {

        }
    }


}
