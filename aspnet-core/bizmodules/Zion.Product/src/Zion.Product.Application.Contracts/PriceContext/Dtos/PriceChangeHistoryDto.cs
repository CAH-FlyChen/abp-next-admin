using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.PriceContext.Dtos;
public class PriceChangeHistoryDto:EntityDto<Guid>
{
    public Guid PriceId { get; set; }

    public string PriceName { get; set; }

    public decimal OldPrice { get; set; }

    public decimal NewPrice { get; set; }
    /// <summary>
    /// 业务名称
    /// </summary>
    [MaxLength(50)]
    public string BizName { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string Description { get; set; }

    public DateTime CreationTime { get; set; }
}
