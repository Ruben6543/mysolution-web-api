using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Domain
{
    public enum ServiceMessageCode
    {
        Success,
        Failure,
        Exception
    }

    public enum ServiceErrorCode
    {
        NotFound,
        AlreadyExists,
        InvalidData,
        Conflict,
        Unknow
    }
}
