using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Locations
{
    public class LocalityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public string? districtName { get; set; }
        public string? regionName { get; set; }

    }
}
