using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class MealPlan
    {
        public MealPlan()
        {
            Meals = new HashSet<Meal>();
        }

        public int PlanId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlanType { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
