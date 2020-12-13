using System;

namespace WorkoutApp
{
    public class User
    {
        /// <remarks>
        /// Serves as identifier
        /// Must be unique
        /// </remarks>
        public string Nickname { get; set; }

        /// <summary>
        /// Real user's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Real user's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User's birthdate
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// User's gender
        /// </summary>
        public Gender Gender { get; set; }


        /// <summary>
        /// Unified constructor
        /// </summary>
        /// <param name="nickname"> Only necessary field</param>
        /// <param name="name"> Real name </param>
        /// <param name="surname"> Real surname </param>
        /// <param name="birthdate"> Birthdate </param>
        /// <param name="gender"> Gender </param>
        public User(string nickname,
                    string name = null,
                    string surname = null,
                    DateTime? birthdate = null,
                    Gender gender = Gender.None)
        {
            Nickname = nickname;
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Gender = gender;
        }
    }
}