using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCostEstimator.Models
{
    public class AddTechnologyViewModel
    {
        [Required]
        public int ProjectID { get; set; }
        [Required]
        [Display(Name ="Technologia")]
        public int TechnologyDefinitionID { get; set; }
        public ICollection<TechnologyDefinition> Definitions { get; set; }
    }
}