using AppKpi.model;
using AppKpi.repository;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace AppKpi.service
{
    public class UserService
    {
        private readonly SQLiteAsyncConnection _connection;
        public static string PROP_USER_ID_PROPERTY = "UserId";
        public static string PROP_USER_NAME_PROPERTY = "UserName";
        public static string PROP_USER_EMAIL_PROPERTY = "UserEmail";
        public static string PROP_USER_TOKEN_PROPERTY = "UserToken";
        private static User _loggedUser { get; set; }

        public static User LoggedUser
        {
            get
            {
                if (_loggedUser == null)
                {
                    RetrieveUserInfo();
                }
                return _loggedUser;
            }
        }

        public static void InitializeLogin(string username, string password)
        {
            _loggedUser = new User
            {
                Login = username,
                Password = password
            };
        }

        public UserService(SQLiteAsyncConnection connection)
        {
            _connection = connection;
        }

        public async Task PersistLogin(int id, string name, string email, string token)
        {
            _loggedUser.UserId = id;
            _loggedUser.Name = name;
            _loggedUser.Login = email;
            _loggedUser.Token = token;

            Application.Current.Properties[PROP_USER_ID_PROPERTY] = _loggedUser.UserId;
            Application.Current.Properties[PROP_USER_NAME_PROPERTY] = _loggedUser.Name;
            Application.Current.Properties[PROP_USER_TOKEN_PROPERTY] = _loggedUser.Token;
            Application.Current.Properties[PROP_USER_EMAIL_PROPERTY] = _loggedUser.Login;

            await StoreUser(_loggedUser);
        }

        public static void ClearUserInfo()
        {
            _loggedUser = null;

            Application.Current.Properties.Remove(PROP_USER_ID_PROPERTY);
            Application.Current.Properties.Remove(PROP_USER_NAME_PROPERTY);
            Application.Current.Properties.Remove(PROP_USER_TOKEN_PROPERTY);
            Application.Current.Properties.Remove(PROP_USER_EMAIL_PROPERTY);
        }

        public static void RetrieveUserInfo()
        {
            if (!Application.Current.Properties.ContainsKey(PROP_USER_ID_PROPERTY) ||
                !Application.Current.Properties.ContainsKey(PROP_USER_NAME_PROPERTY) ||
                !Application.Current.Properties.ContainsKey(PROP_USER_TOKEN_PROPERTY) ||
                !Application.Current.Properties.ContainsKey(PROP_USER_EMAIL_PROPERTY)) return;

            _loggedUser = new User
            {
                UserId = (int)Application.Current.Properties[PROP_USER_ID_PROPERTY],
                Name = (string)Application.Current.Properties[PROP_USER_NAME_PROPERTY],
                Token = (string)Application.Current.Properties[PROP_USER_TOKEN_PROPERTY],
                Login = (string)Application.Current.Properties[PROP_USER_EMAIL_PROPERTY],
            };
        }

        public async Task<User> GetUserById(int userId)
        {
            var userRepo = new UserRepository(_connection);
            return await userRepo.GetById(userId);
        }

        public async Task StoreUser(User user)
        {
            var userRepo = new UserRepository(_connection);

            var existent = await GetUserById(user.UserId);
            if (existent == null)
            {
                await userRepo.Add(user);
            }
            else
            {
                await userRepo.Update(user);
            }

            if (LoggedUser.UserId == user.UserId)
                _loggedUser = user;
        }
    }
}
