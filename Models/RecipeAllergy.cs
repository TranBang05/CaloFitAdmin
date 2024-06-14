using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class RecipeAllergy
    {
        public int RecipeAllergyId { get; set; }
        public int RecipeId { get; set; }
        public int AllergyId { get; set; }

        public virtual Allergy Allergy { get; set; } = null!;
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
