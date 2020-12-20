using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WorkoutApp.Controller.Attributes;

namespace WorkoutApp.Controller
{
    [Serializable]
    public class Meal
    {
        /// <summary>
        /// Id of meal in database
        /// </summary>
        public int MealId { get; set; }

        /// <summary>
        /// Name of meal
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Foods and its' weight in meal
        /// </summary>
        public List<Tuple<Food, double>> Foods { get; set; }

        /// <summary>
        /// Time of food consumption
        /// </summary>
        public DateTime Time { get; set; }
    }
}