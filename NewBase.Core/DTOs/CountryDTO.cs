using System.Collections.Generic;

namespace NewBase.Core.DTOs
{
    public class CountryDTO
    {
        public long Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public List<CityDTO> Cities { get; set; }
    }
}
