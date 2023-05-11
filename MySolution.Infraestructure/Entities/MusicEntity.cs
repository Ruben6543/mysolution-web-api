using MySolution.Infraestructure.Entities.GenericEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Infraestructure.Entities
{
    public class MusicEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Genre{ get; set; }
    }
}
