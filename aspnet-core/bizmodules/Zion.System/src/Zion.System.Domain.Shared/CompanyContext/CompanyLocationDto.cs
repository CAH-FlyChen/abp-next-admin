using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.System.CompanyContext;
public class CompanyLocationDto
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
}
