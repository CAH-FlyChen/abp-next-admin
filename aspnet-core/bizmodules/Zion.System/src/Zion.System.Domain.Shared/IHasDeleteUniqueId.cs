using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.System;
public interface IHasDeleteUniqueId
{
    public Guid DeleteUniqueId { get; set; }
}
