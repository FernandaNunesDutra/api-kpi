using AppKpi.api.response;
using AppKpi.model;
using SQLite;
using System.Threading.Tasks;

namespace AppKpi.api
{
    public class ApiService
    {
        private static string URL_POST_LOGIN = "";
        private static RequestService _requestService;

        public ApiService(SQLiteAsyncConnection connection)
        {
            _requestService = RequestService.Instance(connection);
        }

        public async Task<Response<User>> ValidateLogin(User user)
        {
            return await _requestService.PostData<User>(user, URL_POST_LOGIN);
        }
    }
}
