using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Api.Common.Exceptions
{
    public class ContactException : Exception
    {
        public ContactException(string message):base(message)
        {
                
        }
    }
}
