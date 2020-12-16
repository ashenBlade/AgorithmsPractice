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

        [TestCase("Vladimir1997", TestName = "With letters and digits")]
        [TestCase("RiderInTheDark", TestName = "Valid nickname")]
        [TestCase("qwertyuiop", TestName = "Only lower case letters")]
        [TestCase("Kirill_2008", TestName = "With special character")]
        public void CanRegisterNewUser(string nickname)
        {
            var uc = new UserController();
            Assert.IsTrue(uc.TryRegisterNewUser(nickname));
        }

        [TestCase("lq", TestName = "Short nickname (2 chars)")]
        [TestCase("      ", TestName = "White spaces")]
        [TestCase(".", TestName = "Only dot")]
        [TestCase(".NetFramework", TestName = "Dot in the first position")]
        [TestCase("", TestName = "Empty string")]
        [TestCase(null, TestName = "Argument is null")]
        [TestCase("nullablevauesareperqwerwerwreqrqerwtfect", TestName = "Long nickname (>20 chars)")]
        [TestCase("Vasiliy Ivanov", TestName = "Contains white spaces")]
        [TestCase("_____", TestName = "Contains only underlines")]
        public void CanNotRegisterNewUserWithInvalidNickname(string nickname)
        {
            var uc = new UserController();
            Assert.IsFalse(uc.TryRegisterNewUser(nickname));
        }

        [TestCase("Vasya Petya", Description = "With whitespace")]
        [TestCase("Vaya200", Description = "With digits")]
        [TestCase("__Vasya__", Description = "With underline characters")]
        [TestCase("Vasya__2008__", Description = "With underline characters and digits")]
        public void CanNotRegisterNewUserWithInvalidName(string name)
        {
            var nickname = "SimpleNickname";
            var uc = new UserController();
            Assert.IsFalse(uc.TryRegisterNewUser(nickname, name));
        }

        [TestCase("ZebraLion")]
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