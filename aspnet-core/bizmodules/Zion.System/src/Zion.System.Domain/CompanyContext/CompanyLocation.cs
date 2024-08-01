using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.System.CompanyContext;

public class CompanyLocation : ValueObject
{
    [MaxLength(10)]
    public string CountryCode { get; set; }
    [MaxLength(10)]
    public string ProvinceCode { get; set; }
    [MaxLength(10)]
    public string CityCode { get; set; }
    [MaxLength(10)]
    public string DistrictCode { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    protected CompanyLocation() { }

    public CompanyLocation(string countryCode, string provinceCode, string cityCode, string districtCode, double? latitude, double? longitude)
    {
        CountryCode = countryCode;
        ProvinceCode = provinceCode;
        CityCode = cityCode;
        DistrictCode = districtCode;
        Latitude = latitude;
        Longitude = longitude;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CountryCode;
        yield return ProvinceCode;
        yield return CityCode;
        yield return DistrictCode;
    }
}
