using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace Zion.System;
public static class GloableGuidGenerator
{
    static IGuidGenerator _guidGenerator;

    public static void Init(IGuidGenerator guidGen)
    {
        if (_guidGenerator == null)
        {
            _guidGenerator = guidGen;
        }
    }

    public static Guid Create()
    {
        return _guidGenerator.Create();
    }

    public static void InitMySQLGUID()
    {
        if (_guidGenerator == null)
        {
            var op = Options.Create(new AbpSequentialGuidGeneratorOptions() { DefaultSequentialGuidType = SequentialGuidType.SequentialAsString });
            _guidGenerator = new SequentialGuidGenerator(op);
        }
    }
}
