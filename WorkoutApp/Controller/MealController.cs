using System;
using System.Collections.Generic;
using WorkoutApp.Controller;
using WorkoutApp.Controller.Attributes.Controller;

namespace WorkoutApp.Controller
{
    public class MealController : BaseController
    {
        private User CurrentUser { get; set; }

        /// <summary>
        /// All registered meals for current user
        /// </summary>
        private Dictionary<User, List<Meal>> Meals { get; set; }

        public MealController(User user)
        {
            CurrentUser = user;
            Meals = LoadMealsFromFile();
        }

        /// <summary>
        /// Add new meal to current user
        /// </summary>
        /// <param name="name"> Name of new meal </param>
        /// <param name="consumptionTime"> Time, when food was eaten </param>
        /// <param name="foods"> Foods and weight, that meal contains </param>
        /// <remarks> First argument in "foods" - Id of food, second - weight of it </remarks>
        public void AddNewMeal(string name, DateTime consumptionTime, List<Tuple<int, double>> foods)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile() => Save(ProjectInfo.MealsData, Meals);
        private Dictionary<User, List<Meal>> LoadMealsFromFile() =>
            Load<Dictionary<User, List<Meal>>>(ProjectInfo.MealsData) ?? new Dictionary<User, List<Meal>>();
    }
}