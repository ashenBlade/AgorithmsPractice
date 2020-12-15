using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Controller
{
    public class FoodController : BaseController
    {
        private List<Food> _foods;

        public IReadOnlyList<Food> Foods => _foods;

        /// <summary>
        /// Add new food to database
        /// </summary>
        /// <param name="name"> Food name </param>
        /// <param name="calories"> Calories per gram </param>
        /// <param name="carbs"> Carbohydrates per gram </param>
        /// <param name="fats"> Fats per gram </param>
        /// <param name="proteins"> Protein per gram </param>
        /// <returns> If food added successfully </returns>
        public bool AddNewFood(string name, double calories, double carbs, double fats, double proteins)
        {
            var food = new Food(name, calories, carbs, fats, proteins);
            var context = new ValidationContext(food);
            var result = new List<ValidationResult>();
            var isFoodValid = Validator.TryValidateObject(food, context, result, true);
            if (isFoodValid)
                _foods.Add(food);

            return isFoodValid;
        }

        /// <summary>
        /// Remove food from database
        /// </summary>
        /// <param name="name"> Food name </param>
        public void RemoveFood(string name)
        {
            if (name != null)
            {
                for (int i = 0; i < _foods.Count; i++)
                    if (_foods[i].Name == name)
                        _foods.RemoveAt(i);
            }
        }

        public FoodController()
        {
            _foods = LoadFoods() ?? new List<Food>();
        }

        private List<Food> LoadFoods() => Load<List<Food>>(ProjectInfo.FoodsData);

        /// <summary>
        /// Save current food list to file
        /// </summary>
        public void Save() => Save(ProjectInfo.FoodsData, _foods);
    }
}