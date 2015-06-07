using System;

namespace Model
{
    public class User
    {
        private int userId;
        private string userName;
        private string userPassword;
        private DateTime addTime;
        private bool isAdmin;

        public int UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return userPassword;
            }

            set
            {
                userPassword = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }

            set
            {
                isAdmin = value;
            }
        }

        public DateTime AddTime
        {
            get
            {
                return addTime;
            }

            set
            {
                addTime = value;
            }
        }
    }
}
