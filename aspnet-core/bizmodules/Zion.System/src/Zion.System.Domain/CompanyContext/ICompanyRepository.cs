using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.System.CompanyContext;

public interface ICompanyRepository : IRepository<Company, Guid>
{
}
