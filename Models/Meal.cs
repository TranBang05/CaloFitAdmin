using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Meal
    {
        public int MealId { get; set; }
        public int PlanId { get; set; }
        public string MealType { get; set; } = null!;
        public DateTime MealDate { get; set; }
        public int MealRecipesId { get; set; }

        public virtual Recipe MealRecipes { get; set; } = null!;
        public virtual MealPlan Plan { get; set; } = null!;
    }
}
