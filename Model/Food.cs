using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutApp
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Name of food
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Food length must be in range (4...20)")]
        public string Name { get; set; }
        /// <summary>
        /// Calories per gram
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Calorie content can't be negative")]
        public double CaloriesPerGram { get; set; }
        /// <summary>
        /// Protein per gram
        /// </summary>
        [Range(0, 100, ErrorMessage = "Proteins content must be longer than 0 and less than 100")]
        public double ProteinPerGram { get; set; }

        /// <summary>
        /// Carbohydrates per gram
        /// </summary>
        [Range(0, 100, ErrorMessage = "Carbohydrates content must be longer than 0 and less than 100")]
        public double CarbohydratesPerGram { get; set; }

        /// <summary>
        /// Fats per gram
        /// </summary>
        [Range(0, 100, ErrorMessage = "Fats content must be longer than 0 and less than 100")]
        public double FatsPerGram { get; set; }

        /// <summary>
        /// What other food does it include
        /// </summary>
        public List<Food> Composition { get; set; }

        /// <summary>
        /// Does food consist of other foods
        /// </summary>
        public bool IsComposite => Composition.Count != 0;

        public Food(string name, double caloriesPerGram = 0, double proteinPerGram = 0, double carbohydratesPerGram = 0, double fatsPerGram = 0, List<Food> composition = null)
        {
            Name = name;
            CaloriesPerGram = caloriesPerGram;
            ProteinPerGram = proteinPerGram;
            CarbohydratesPerGram = carbohydratesPerGram;
            FatsPerGram = fatsPerGram;
            Composition = composition ?? new List<Food>();
        }
    }
}