using System;
using NUnit.Framework;
using WorkoutApp;
using WorkoutApp.Controller;

namespace WorkoutApp.Controller.Tests
{
    public class UserControllerTests
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
        [TestCase("nullablevasdfghjklkjhgfdfghjkjhgfdfghjjhgfdfghjkjhgfdfghjkjhgfdfghjkuesareperqwerwerwreqrqerwtfect", TestName = "Long nickname (>50 chars)")]
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
        [TestCase(null, Description = "NULL")]
        [TestCase("", Description = "Empty string")]
        [TestCase("       ", Description = "Only whitespaces")]
        [TestCase("Try", Description = "Only 3 characters")]
        [TestCase("ahawetpvawufhbapiufyabpfwefwegwefwefawcefaweestrjydttrthnesrabWNGARGAEAEvawawfvnf", Description = "Too long name")]
        public void CanNotSetInvalidUserName(string name)
        {
            var nickname = "SimpleNickname";
            var uc = new UserController();
            uc.TryRegisterNewUser(nickname);
            uc.TryAuthorize(nickname);
            Assert.IsFalse(uc.SetName(name));
        }

        [TestCase("ZebraLion")]
        [TestCase("qwrtyuiop")]
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
            Assert.AreEqual(nickname, uc.Nickname);
            Assert.AreEqual(name, uc.Name);
            Assert.AreEqual(dateOfBirth, uc.Birthdate);
            Assert.AreEqual(gender, uc.Gender);
            Assert.AreEqual(weight, uc.Weight);
            Assert.AreEqual(height, uc.Height);
        }
    }
}