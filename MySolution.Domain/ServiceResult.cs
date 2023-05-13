using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Domain
{
    public class ServiceResult
    {
        public ServiceMessageCode Type { get; }

        private object _result;

        public ServiceResult(object result) : this(ServiceMessageCode.Success, result) { }
        public ServiceResult(ServiceMessageCode type, object result)
        {
            Type = type;
            _result = result;
        }

        public TResult GetResult<TResult>()
        {
            return (TResult)_result;
        }
    }
}
