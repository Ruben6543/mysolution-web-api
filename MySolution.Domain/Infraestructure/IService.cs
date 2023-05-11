using MySolution.Domain.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Domain.Infraestructure
{
    public interface IService
    {
        Task<object> List();

        Task<object> Save(object data);

        Task<object> Update(object data);

        Task<object> Delete(Guid id);
    }
}
