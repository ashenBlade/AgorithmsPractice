using NUnit.Framework;
using NUnit.Framework.Constraints;
using WorkoutApp.Controller;

namespace Controller.Tests
{
    public class FoodControllerTests
    {
        [SetUp]
        public void StartUp()
        {

        }

        [Test]
        public void CanCreateFoodController()
        {
            var fc = new FoodController();
            Assert.Pass();
        }

        [TestCase("Oatmeal")]
        [TestCase("Buckwheat")]
        [TestCase("Chicken breast")]
        public void CanAddNewSingleFood(string name)
        {
            var fc = new FoodController();
            Assert.IsTrue(fc.AddNewFood(name));
        }

        [TestCase("Oatmeal", 100, 100, 100, 100)]
        [TestCase("Buckwheat", 200, 12, 8, 70)]
        [TestCase("Barley", 330, 8, 3, 23)]
        [TestCase("Carrot", 40, 0, 0, 20)]
        [TestCase("Meat", 300, 21.32, 13.002, 4.12, Description = "With floating point values")]
        public void CanAddNewSingleFoodWithProperties(string name, double calories, double proteins, double fats, double carbs)
        {
            var fc = new FoodController();
            Assert.IsTrue(fc.AddNewFood(name, calories, carbs, fats, proteins));
        }

        [TestCase(null, Description = "Name is \"null\"")]
        [TestCase("", Description = "Name is empty")]
        [TestCase("N", Description = "Name is too short (1 character)")]
        [TestCase("ASfagjhaguhasdsdfweberbvjahsrg", Description = "Name is too long")]
        [TestCase("Oatmeal", -1, Description = "Calorie content is negative")]
        [TestCase("Oatmeal", 100, 123, Description = "Proteins content is bigger than 100")]
        [TestCase("Oatmeal", -100, -1231, -1, -12323, Description = "All food properties negative")]
        [TestCase("Buckwheat", 0.01, 0.2, -0.1, Description = "With negative floating point values")]
        [TestCase("Buckwheat", 0.01, 0.2, -0.00000001, Description = "With negative value near to 0 (-0.000000001)")]
        [TestCase("Buckwheat", 0.01, 0.2, 100.00000001, Description = "With value near 100 (100.00000001)")]
        [TestCase("White bread___", Description = "Food name with underline character")]
        [TestCase("   ", Description = "Food name contains only white spaces")]
        [TestCase("Hello123", Description = "Food name contains digits")]
        public void CanNotAddNewFood(string name, double calories = 0, double proteins = 0, double fats = 0, double carbs = 0)
        {
            var fc = new FoodController();
            Assert.IsFalse(fc.AddNewFood(name, calories, carbs, fats, proteins));
        }
    }
}