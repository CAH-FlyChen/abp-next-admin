using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Http;
using Volo.Abp.Validation;

namespace Zion.System;
internal class BizExceptionToErrorInfoConverter : IExceptionToErrorInfoConverter, ITransientDependency
{
    public RemoteServiceErrorInfo Convert(Exception exception, bool includeSensitiveDetails)
    {
        throw new NotImplementedException();
    }

    public RemoteServiceErrorInfo Convert(Exception exception, Action<AbpExceptionHandlingOptions>? options = null)
    {

        return FindMyException(exception); // 如果不是自定义异常，则返回null
    }

    private RemoteServiceErrorInfo FindMyException(Exception exception)
    {
        if (exception is BizException customException)
        {
            return new RemoteServiceErrorInfo
            {
                Code = "CustomError",
                Message = customException.Message
                // 可以添加更多的自定义属性
            };
        }
        if (exception is AbpValidationException ee)
        {
            return new RemoteServiceErrorInfo
            {
                Code = "CustomError",
                ValidationErrors = ee.ValidationErrors.Select(t => new RemoteServiceValidationErrorInfo(t.ErrorMessage == null ? "" : t.ErrorMessage, t.MemberNames.ToList().ToArray<string>())).ToArray()
                // 可以添加更多的自定义属性
            };
        }


        if (exception.InnerException != null)
            return FindMyException(exception.InnerException);
        else
            return new RemoteServiceErrorInfo();
    }
}
