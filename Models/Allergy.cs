using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Allergy
    {
        public Allergy()
        {
            RecipeAllergies = new HashSet<RecipeAllergy>();
        }

        public int AllergyId { get; set; }
        public int UserId { get; set; }
        public string Allergen { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<RecipeAllergy> RecipeAllergies { get; set; }
    }
}
