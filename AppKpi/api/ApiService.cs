using System.Collections.Generic;
using AppKpi.api.response;
using AppKpi.model;
using SQLite;
using System.Threading.Tasks;
using AppKpi.api.response.model;

namespace AppKpi.api
{
    public class ApiService
    {
        private static string URL_BASE = "http://indicadoresapi.azurewebsites.net/api/";
        private static string URL_POST_LOGIN = URL_BASE + "acesso/logar";
        private static string URL_GET_DASHBOARD = URL_BASE + "dashboard/lista?type={0}";
        private static string URL_GET_CHART = URL_BASE + "";
        private static RequestService _requestService;

        public ApiService(SQLiteAsyncConnection connection)
        {
            _requestService = RequestService.Instance(connection);
        }

        public async Task<Response<User>> ValidateLogin(User user)
        {
            return await _requestService.PostData<User>(user, URL_POST_LOGIN);
        }

        public async Task<Response<List<Group>>> GetDashboard(int type)
        {
            return await _requestService.GetData<List<Group>>(string.Format(URL_GET_DASHBOARD, type));
        }

        public async Task<Response<List<ChartEntry>>> GetChartData(int type)
        {
            return await _requestService.GetData<List<ChartEntry>>(string.Format(URL_GET_CHART, type));
        }
        
    }
}
