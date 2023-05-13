using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Domain.DataTransferObject
{
    public class Music
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool IsDeleted{ get; set; }
    }
}
