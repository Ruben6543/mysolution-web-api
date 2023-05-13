using MySolution.Domain.DataTransferObject;
using MySolution.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Domain.Infraestructure
{
    public interface IService
    {
        Task<ServiceResult> List();

        Task<ServiceResult> Get(int id);

        Task<ServiceResult> Save(object data);

        Task<ServiceResult> Update(object data);

        Task<ServiceResult> Delete(int id);
    }
}
