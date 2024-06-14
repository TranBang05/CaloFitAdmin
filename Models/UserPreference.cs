using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class UserPreference
    {
        public int UserPreferenceId { get; set; }
        public int UserId { get; set; }
        public int DietId { get; set; }
        public int? FavoriteRecipesId { get; set; }

        public virtual Diet Diet { get; set; } = null!;
        public virtual Recipe? FavoriteRecipes { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
