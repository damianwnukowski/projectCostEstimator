using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCostEstimator.Models
{
    public class Technology
    {
        public int ID { get; set; }
        public virtual TechnologyDefinition TechnologyDefinition { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "{0} musi być większy niż {1}.")]
        [DataType(DataType.Text)]
        [Display(Name = "Cena za wykorzystanie w projekcie w momencie dodania")]
        public decimal UsedBasePrice { get; set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "{0} musi być większy niż {1}.")]
        [DataType(DataType.Text)]
        [Display(Name = "Mnożnik ceny projektu w momencie dodania")]
        public double UsedPriceMultiplier { get; set; }
    }
}