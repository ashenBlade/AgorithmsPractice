using System;
using System.Collections.Generic;
using NUnit.Framework;
using WorkoutApp;

namespace Model.Tests
{
    public class Tests
    {
        private List<DateTime> _birthdates;

        [SetUp]
        public void Setup()
        {
            _birthdates = new List<DateTime>();
            _birthdates.AddRange(new []
                                {
                                    new DateTime(1997, 12, 23),
                                    new DateTime(2006, 10, 30),
                                    new DateTime(2013, 6, 10),
                                });
        }

        [Test]
        public void CanCreateNewUserWithDifferentParameters()
        {
            var user1 = new User("nickname", "name", "surname", null, null);
            var user2 = new User("kirill");
            var user3 = new User("Alexey", "Mahachkala");
            var user4 = new User("RoadMapTo", "Black", "White", _birthdates[0], Gender.Male);
            var user5 = new User("HomeSweetHome", "Winter", "Summer", _birthdates[1], Gender.Female);
            Assert.Pass();
        }
    }
}