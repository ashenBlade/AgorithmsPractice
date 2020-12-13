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

        public string GetNickname => Current.Nickname;
        public string GetName => Current.Name;
        public double? GetWeight => Current.Weight;
        public double? GetHeight => Current.Height;
        public DateTime? GetBirthdate => Current.Birthdate;
        public Gender GetGender => Current.Gender;

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

        public void RegisterNewUser(string nickname)
        {
            var user = new User(nickname);
            RegisteredUsers.Add(user);
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