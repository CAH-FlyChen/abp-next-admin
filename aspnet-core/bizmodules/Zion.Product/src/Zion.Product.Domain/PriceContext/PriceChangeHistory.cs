//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.Auditing;
//using Volo.Abp.Domain.Entities;

//namespace Zion.Product.PriceContext;

//public class PriceChangeHistory:Entity<Guid>,IHasCreationTime
//{
//    public Guid PriceId { get; set; }

//    [MaxLength(50)]
//    public string PriceName { get; set; }

//    public decimal OldPrice { get; set; }

//    public decimal NewPrice { get; set; }
//    /// <summary>
//    /// 业务名称
//    /// </summary>
//    [MaxLength(50)]
//    public string BizName { get; set; }
//    /// <summary>
//    /// 描述
//    /// </summary>
//    [MaxLength(500)]
//    public string Description { get; set; }

//    public DateTime CreationTime { get; set; }

//    public PriceChangeHistory(Guid priceId, string priceName, decimal oldPrice, decimal newPrice, string bizName, string description)
//    {
//        PriceId = priceId;
//        PriceName = priceName;
//        OldPrice = oldPrice;
//        NewPrice = newPrice;
//        BizName = bizName;
//        Description = description;
//    }
//}


