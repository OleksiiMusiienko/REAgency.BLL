using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Object
{
    public class StorageDTO : EstateObjectDTO
    {
        public int Id { get; set; }
        public int estateObjectId { get; set; }
    }
}
