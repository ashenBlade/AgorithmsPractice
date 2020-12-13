using System;
using NUnit.Framework;
using WorkoutApp;
using WorkoutApp.Controller;

namespace Controller.Tests
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreateNewUserController()
        {
            var uc = new UserController();
            Assert.Pass();
        }

        [TestCase("Vasya", TestName = "Valid nickname")]
        [TestCase("RiderInTheDark", TestName = "Valid nickname")]
        [TestCase("qwertyuiop", TestName = "Valid nickname")]
        public void CanRegisterNewUser(string nickname)
        {
            var uc = new UserController();
            if (uc.TryRegisterNewUser(nickname))
            {
                Assert.Pass();
                return;
            }
            Assert.Fail();
        }

        [TestCase("Zebra")]
        public void CanAuthorizeRegisteredUser(string nickname)
        {
            var uc = new UserController();
            uc.TryRegisterNewUser(nickname);
            Assert.IsTrue(uc.TryAuthorize(nickname));
        }

        [TestCase("AlexeyKirill")]
        public void CanNotAuthorizeUnregisteredUser(string nickname)
        {
            var uc = new UserController();
            Assert.IsFalse(uc.TryAuthorize(nickname));
        }

        [TestCase("Vasylyi", "Ivanov", "26/02/2002" ,Gender.Male, 100, 100)]
        public void CanGetAuthorizedUserData(string nickname,
                                             string name,
                                             string birthdate,
                                             Gender gender,
                                             double weight,
                                             double height)
        {
            var uc = new UserController();
            uc.TryRegisterNewUser(nickname);
            uc.TryAuthorize(nickname);
            var dateOfBirth = DateTime.Parse(birthdate);
            uc.SetBirthdate(dateOfBirth);
            uc.SetName(name);
            uc.SetHeight(height);
            uc.SetWeight(weight);
            uc.SetGender(gender);
            Assert.AreEqual(nickname, uc.GetNickname);
            Assert.AreEqual(name, uc.GetName);
            Assert.AreEqual(dateOfBirth, uc.GetBirthdate);
            Assert.AreEqual(gender, uc.GetGender);
            Assert.AreEqual(weight, uc.GetWeight);
            Assert.AreEqual(height, uc.GetHeight);
        }
    }
}