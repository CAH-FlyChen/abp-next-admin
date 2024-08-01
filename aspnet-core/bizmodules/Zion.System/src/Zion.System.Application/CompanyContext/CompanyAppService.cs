using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.System.Permissions;
using Zion.System.CompanyContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.System.CompanyContext;


public class CompanyAppService : CrudAppService<Company, CompanyDto, Guid, CompanyGetListInput, CompanyCreateDto, CompanyUpdateDto>,
    ICompanyAppService
{
    protected override string GetPolicyName { get; set; } = SystemPermissions.Company.Default;
    protected override string GetListPolicyName { get; set; } = SystemPermissions.Company.Default;
    protected override string CreatePolicyName { get; set; } = SystemPermissions.Company.Create;
    protected override string UpdatePolicyName { get; set; } = SystemPermissions.Company.Update;
    protected override string DeletePolicyName { get; set; } = SystemPermissions.Company.Delete;

    private readonly ICompanyRepository _repository;

    public CompanyAppService(ICompanyRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Company>> CreateFilteredQueryAsync(CompanyGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(input.LogoUrl != null, x => x.LogoUrl == input.LogoUrl)
            .WhereIf(!input.ShortName.IsNullOrWhiteSpace(), x => x.ShortName.Contains(input.ShortName))
            .WhereIf(!input.JP.IsNullOrWhiteSpace(), x => x.JP.Contains(input.JP))
            .WhereIf(input.StatusCode != null, x => x.StatusCode == input.StatusCode)
            .WhereIf(input.DeleteUniqueId != null, x => x.DeleteUniqueId == input.DeleteUniqueId)
            ;
    }
}
