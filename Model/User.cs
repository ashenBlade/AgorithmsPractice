using System;
using System.ComponentModel.DataAnnotations;
using WorkoutApp.Attributes;

namespace WorkoutApp
{
    public class User
    {
        /// <remarks>
        /// Serves as identifier
        /// Must be unique
        /// </remarks>
        [Required(ErrorMessage = "Nickname is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Nickname length must be in range (6...20)")]
        [Nickname]
        public string Nickname { get; set; }

        /// <summary>
        /// Real user's name
        /// </summary>
        [UserName]
        public string Name { get; set; }


        /// <summary>
        /// User's birthdate
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// User's gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// User's height
        /// </summary>
        /// <remarks> Centimeters </remarks>
        [Range(0, 400)]
        public double? Height { get; set; }

        /// <summary>
        /// User's weight in kg
        /// </summary>
        /// <remarks> Kilograms </remarks>
        [Range(0, 400)]
        public double? Weight { get; set; }

        /// <summary>
        /// Unified constructor
        /// </summary>
        /// <param name="nickname"> Only necessary field</param>
        /// <param name="name"> Real name </param>
        /// <param name="birthdate"> Birthdate </param>
        /// <param name="height"> Height </param>
        /// <param name="weight"> Weight </param>
        /// <param name="gender"> Gender </param>
        public User(string nickname,
                    string name = null,
                    double? weight = null,
                    double? height = null,
                    DateTime? birthdate = null,
                    Gender? gender = Gender.None)
        {
            Nickname = nickname;
            Height = height;
            Weight = weight;
            Name = name;
            Birthdate = birthdate;
            Gender = gender ?? Gender.None;
        }
    }
}