using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace WorkoutApp.Controller
{
    public class UserController : BaseController
    {
        /// <summary>
        /// Current authorized user
        /// </summary>
        private User Current { get; set; }

        #region CurrentUserInterface

        public string GetNickname => Current?.Nickname;
        public string GetName => Current?.Name;
        public double? GetWeight => Current?.Weight;
        public double? GetHeight => Current?.Height;
        public DateTime? GetBirthdate => Current?.Birthdate;
        public Gender GetGender => Current.Gender;

        public void SetNickname(string nickname)
        {
            if (Current != null)
                Current.Nickname = nickname;
        }

        public void SetName(string name)
        {
            if (Current != null)
                Current.Name = name;
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
        /// All registered users
        /// </summary>
        /// <remarks>
        /// Only in console version
        /// </remarks>
        private List<User> RegisteredUsers { get; set; }

        public UserController()
        {
            // Load from database
            RegisteredUsers = LoadUsers();
            Current = null;
        }

        /// <summary>
        /// Registers new user by nickname
        /// </summary>
        /// <param name="nickname"> Nickname </param>
        /// <returns> If user registered successfully </returns>
        // TODO: check nickname for correctness
        public bool TryRegisterNewUser(string nickname)
        {
            if (RegisteredUsers.FirstOrDefault(i => i.Nickname == nickname) == null)
            {
                var user = new User(nickname);
                RegisteredUsers.Add(user);
                return true;
            }
            return false;
        }

        public bool TryAuthorize(string nickname)
        {
            var user = RegisteredUsers.FirstOrDefault(i => i.Nickname == nickname);
            Current = user ?? Current;
            return Current != null;
        }


        private void Save() => Save(UserInfo.DataFile, RegisteredUsers);
        private List<User> LoadUsers() => Load<List<User>>(UserInfo.DataFile) ?? new List<User>();
    }
}