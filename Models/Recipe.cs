using System;
using System.Collections.Generic;

namespace AdminApi.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            Meals = new HashSet<Meal>();
            RecipeAllergies = new HashSet<RecipeAllergy>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
            RecipeRatings = new HashSet<RecipeRating>();
            Steps = new HashSet<Step>();
            UserPreferences = new HashSet<UserPreference>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!;
        public int Servings { get; set; }
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public string? Description { get; set; }
        public int? ImageId { get; set; }
        public int MenuId { get; set; }

        public virtual Image? Image { get; set; }
        public virtual Menu Menu { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<RecipeAllergy> RecipeAllergies { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeRating> RecipeRatings { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
    }
}
