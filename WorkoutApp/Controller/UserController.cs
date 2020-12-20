using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorkoutApp.Controller;
using WorkoutApp.Controller.Attributes;
using WorkoutApp.Controller.Attributes.Controller;

namespace WorkoutApp.Controller
{
    public class UserController
    {
        /// <summary>
        /// Current authorized user
        /// </summary>
        private User Current { get; set; }


        #region CurrentUserInterface

        public bool IsUserAuthorized => Current != null;
        public string Nickname => Current?.Nickname;
        public string Name => Current?.Name;
        public double? Weight => Current?.Weight;
        public double? Height => Current?.Height;
        public DateTime? Birthdate => Current?.Birthdate;
        public Gender? Gender => Current?.Gender;


        public bool SetName(string name)
        {
            if (Current == null || name == null ||
                0 < Validate.UserName(name).Count)
                return false;
            Current.Name = name;
            return true;
        }

        public void SetWeight(double weight)
        {
            if (Current != null)
                Current.Weight = weight;
        }

        public void SetHeight(double height)
        {
            if (Current != null)
                Current.Height = height;
        }

        public void SetBirthdate(DateTime birthdate)
        {
            if (Current != null)
                Current.Birthdate = birthdate;
        }


        public void SetGender(Gender gender)
        {
            if (Current != null)
                Current.Gender = gender;
        }

        #endregion

        /// <summary>
        /// Save and load users' data
        /// </summary>
        private IFileDataManager<Dictionary<string, User>> DataManager { get; set; }

        /// <summary>
        /// All registered users on local machine
        /// </summary>
        private Dictionary<string, User> RegisteredUsers { get; set; }

        public UserController()
        {
            DataManager = new DatabaseDataManager<Dictionary<string, User>>();

            // Load from database
            RegisteredUsers = LoadUsers();
            Current = null;
        }

        /// <summary>
        /// Register new user by nickname
        /// </summary>
        /// <param name="nickname"> New user's nickname </param>
        /// <returns> If user registered successfully </returns>
        public bool TryRegisterNewUser(string nickname)
        {
            var user = new User(nickname);
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            var isUserValid = Validator.TryValidateObject(user, context, results, true);
            if (isUserValid &&
                !RegisteredUsers.ContainsKey(nickname))
            {
                RegisteredUsers[nickname] = user;
                return true;
            }
            return false;
        }

        public bool TryAuthorize(string nickname)
        {
            if (RegisteredUsers.ContainsKey(nickname))
            {
                Current = RegisteredUsers[nickname];
                return true;
            }
            return false;
        }


        public void Save() =>
            DataManager.Save(ProjectInfo.UsersData, RegisteredUsers);
        private Dictionary<string, User> LoadUsers() =>
             DataManager.Load(ProjectInfo.UsersData) ?? new Dictionary<string, User>();
    }
}