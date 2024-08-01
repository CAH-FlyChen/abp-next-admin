using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Zion.System;
public class BizException : AbpException
{
    public string Msg { get; set; }
    public object DataExt { get; set; }
    public BizException(string msg) : base(msg)
    {
        Msg = msg;
    }
    public BizException(string msg, object data) : base(msg)
    {
        Msg = msg;
        DataExt = data;
    }

}
