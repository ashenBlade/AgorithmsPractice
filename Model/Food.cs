using System.Collections.Generic;

namespace WorkoutApp
{
    public class Food
    {
        /// <summary>
        /// Name of food
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Calories per gram
        /// </summary>
        public double CaloriesPerGram { get; set; }
        /// <summary>
        /// What food does it include
        /// </summary>
        public List<Food> Composition { get; set; }
        /// <summary>
        /// Protein per gram
        /// </summary>
        public double ProteinPerGram { get; set; }

        /// <summary>
        /// Carbohydrates per gram
        /// </summary>
        public double CarbohydratesPerGram { get; set; }

        /// <summary>
        /// Fats per gram
        /// </summary>
        public double FatsPerGram { get; set; }
    }
}