using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;

public class SpecificationGroupItem : ValueObject
{
    [Key]
    public Guid Id { get; set; }
    public Guid SpecificationGroupId { get; set; }
    public string Title { get; set; }
    public string[] Options { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return new object[] { Title, Options };
    }
}
