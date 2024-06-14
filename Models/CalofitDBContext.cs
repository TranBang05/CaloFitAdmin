using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminApi.Models
{
    public partial class CalofitDBContext : DbContext
    {
        public CalofitDBContext()
        {
        }

        public CalofitDBContext(DbContextOptions<CalofitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergy> Allergies { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Diet> Diets { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<IngredientServingSize> IngredientServingSizes { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<MealPlan> MealPlans { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Nutrition> Nutritions { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeAllergy> RecipeAllergies { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public virtual DbSet<RecipeRating> RecipeRatings { get; set; } = null!;
        public virtual DbSet<Step> Steps { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGoal> UserGoals { get; set; } = null!;
        public virtual DbSet<UserPreference> UserPreferences { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=calofitdb.database.windows.net; database=CalofitDB;user=TXB;password=bang0501@b; TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.ToTable("Allergy");

                entity.Property(e => e.AllergyId).HasColumnName("allergy_id");

                entity.Property(e => e.Allergen)
                    .HasMaxLength(50)
                    .HasColumnName("allergen");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Allergy__user_id__4F7CD00D");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Users");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("comment_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CommentText).HasColumnName("comment_text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__recipe__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__user_i__534D60F1");
            });

            modelBuilder.Entity<Diet>(entity =>
            {
                entity.ToTable("Diet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DietName)
                    .HasMaxLength(50)
                    .HasColumnName("diet_name");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.ImageFilename)
                    .HasMaxLength(255)
                    .HasColumnName("image_filename");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ingredien__image__5535A963");
            });

            modelBuilder.Entity<IngredientServingSize>(entity =>
            {
                entity.HasKey(e => e.ServingSizeId)
                    .HasName("PK__Ingredie__0A1ADB4F1368D9A0");

                entity.ToTable("Ingredient_Serving_Sizes");

                entity.Property(e => e.ServingSizeId).HasColumnName("serving_size_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Grams).HasColumnName("grams");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.Units)
                    .HasMaxLength(50)
                    .HasColumnName("units");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientServingSizes)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ingredien__ingre__5441852A");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("Meal");

                entity.Property(e => e.MealId).HasColumnName("meal_id");

                entity.Property(e => e.MealDate)
                    .HasColumnType("date")
                    .HasColumnName("meal_date");

                entity.Property(e => e.MealRecipesId).HasColumnName("meal_recipes_id");

                entity.Property(e => e.MealType)
                    .HasMaxLength(50)
                    .HasColumnName("meal_type");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.HasOne(d => d.MealRecipes)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealRecipesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meal__meal_recip__5629CD9C");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meal__plan_id__571DF1D5");
            });

            modelBuilder.Entity<MealPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__MealPlan__BE9F8F1D50877388");

                entity.ToTable("MealPlan");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.PlanType)
                    .HasMaxLength(10)
                    .HasColumnName("plan_type");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MealPlans)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MealPlan__user_i__5812160E");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DietId).HasColumnName("diet_id");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(50)
                    .HasColumnName("menu_name");

                entity.HasOne(d => d.Diet)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.DietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Menu__diet_id__59063A47");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("PK__Nutritio__B0E453CFC01A7C55");

                entity.Property(e => e.IngredientId)
                    .ValueGeneratedNever()
                    .HasColumnName("ingredient_id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");

                entity.Property(e => e.Fat).HasColumnName("fat");

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.Sugar).HasColumnName("sugar");

                entity.HasOne(d => d.Ingredient)
                    .WithOne(p => p.Nutrition)
                    .HasForeignKey<Nutrition>(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nutrition__ingre__59FA5E80");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Users");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Ingredients");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.CookTime).HasColumnName("cook_time");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.PrepTime).HasColumnName("prep_time");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(255)
                    .HasColumnName("recipe_name");

                entity.Property(e => e.Servings).HasColumnName("servings");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK__Recipes__image_i__6477ECF3");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipes__menu_id__656C112C");
            });

            modelBuilder.Entity<RecipeAllergy>(entity =>
            {
                entity.ToTable("Recipe_Allergies");

                entity.Property(e => e.RecipeAllergyId).HasColumnName("recipe_allergy_id");

                entity.Property(e => e.AllergyId).HasColumnName("allergy_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Allergy)
                    .WithMany(p => p.RecipeAllergies)
                    .HasForeignKey(d => d.AllergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_Al__aller__5DCAEF64");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeAllergies)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_Al__recip__5EBF139D");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("Recipe_Ingredients");

                entity.Property(e => e.RecipeIngredientId).HasColumnName("recipe_ingredient_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.ServingSizeId).HasColumnName("serving_size_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_In__ingre__5FB337D6");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_In__recip__60A75C0F");

                entity.HasOne(d => d.ServingSize)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.ServingSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_In__servi__619B8048");
            });

            modelBuilder.Entity<RecipeRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__Recipe_R__D35B278BB6685897");

                entity.ToTable("Recipe_Ratings");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("rating_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRatings)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_Ra__recip__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RecipeRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipe_Ra__user___6383C8BA");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("Step");

                entity.Property(e => e.StepId).HasColumnName("step_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.StepNumber).HasColumnName("step_number");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK__Step__image_id__66603565");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Step__recipe_id__6754599E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61644D0A1651")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572A4A765FE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserGoal>(entity =>
            {
                entity.ToTable("User_Goals");

                entity.Property(e => e.UserGoalId).HasColumnName("user_goal_id");

                entity.Property(e => e.GoalDetails)
                    .HasMaxLength(255)
                    .HasColumnName("goal_details");

                entity.Property(e => e.GoalType)
                    .HasMaxLength(50)
                    .HasColumnName("goal_type");

                entity.Property(e => e.TargetDate)
                    .HasColumnType("date")
                    .HasColumnName("target_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGoals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Goal__user___68487DD7");
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.ToTable("User_Preferences");

                entity.Property(e => e.UserPreferenceId).HasColumnName("user_preference_id");

                entity.Property(e => e.DietId).HasColumnName("diet_id");

                entity.Property(e => e.FavoriteRecipesId).HasColumnName("favorite_recipes_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Diet)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.DietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Pref__diet___693CA210");

                entity.HasOne(d => d.FavoriteRecipes)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.FavoriteRecipesId)
                    .HasConstraintName("FK__User_Pref__favor__6A30C649");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Pref__user___6B24EA82");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
