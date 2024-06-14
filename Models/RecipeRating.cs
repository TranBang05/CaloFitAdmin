using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class RecipeRating
    {
        public int RatingId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime RatingDate { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
