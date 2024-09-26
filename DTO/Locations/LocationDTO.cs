using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Locations
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? RegionId { get; set; }
        public int DistrictId { get; set; }
        public int LocalityId { get; set; }
    }
}
