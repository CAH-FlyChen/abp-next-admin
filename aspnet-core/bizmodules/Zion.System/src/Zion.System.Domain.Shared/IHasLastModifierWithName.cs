using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.System;

public interface IHasLastModifierWithName
{
    public Guid? LastModifierId { get; }
    public string LastModifierName { get; set; }
}
