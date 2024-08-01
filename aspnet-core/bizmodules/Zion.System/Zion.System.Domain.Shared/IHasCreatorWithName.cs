using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.System;
public interface IHasCreatorWithName
{
    public Guid? CreatorId { get; }
    public string CreatorName { get; set; }
}
