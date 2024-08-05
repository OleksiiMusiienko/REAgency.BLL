using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Locations
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CountryId { get; set; }
    }
}
