using AppKpi.api.response;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppKpi.api
{
    public class RequestService
    {
        private SQLiteAsyncConnection _connection;
        private static RequestService _requestService;
        private HttpClient _client;

        private RequestService(SQLiteAsyncConnection connection)
        {
            _connection = connection;
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                Timeout = new TimeSpan(0, 0, 10)
            };

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static RequestService Instance(SQLiteAsyncConnection connection)
        {
            return _requestService ?? (_requestService = new RequestService(connection));
        }

        public async Task<Response<T>> PostData<T>(object objectSend, string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return BuildOfflineResponse<T>();
            }

            var uri = new Uri(url);
            var json = JsonConvert.SerializeObject(objectSend, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response;
                response = await _client.PostAsync(uri, requestContent);
                return await BuildResponse<T>(response);
            }
            catch (Exception e)
            {
                return new Response<T>
                {
                    Success = false,
                    ErrorDescription = "Erro"
                };
            }
        }

        public async Task<Response<T>> PutData<T>(object objectSend, string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return BuildOfflineResponse<T>();
            }

            var uri = new Uri(url);
            var json = JsonConvert.SerializeObject(objectSend, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {
                HttpResponseMessage response;
                response = await _client.PutAsync(uri, requestContent);
                return await BuildResponse<T>(response);
            }
            catch (Exception e)
            {
                return new Response<T>
                {
                    Success = false,
                    ErrorDescription = "Erro"
                };
            }
        }

        public async Task<Response<T>> DeleteData<T>(object objectSend, string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return BuildOfflineResponse<T>();
            }

            var json = JsonConvert.SerializeObject(objectSend, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            });

            var request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url)
            };

            try
            {
                HttpResponseMessage response;
                response = await _client.SendAsync(request);
                return await BuildResponse<T>(response);
            }
            catch (Exception)
            {
                return new Response<T>
                {
                    Success = false,
                    ErrorDescription = "Erro desconhecido"
                };
            }
        }

        public async Task<Response<T>> BuildResponse<T>(HttpResponseMessage response)
        {
            var apiResponse = new Response<T> { Success = response.IsSuccessStatusCode };

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                apiResponse.Data = JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var info = JsonConvert.DeserializeObject<GenericResponse>(content);
                    apiResponse.ErrorDescription = info.Message ?? info.Error ?? "Erro na requisição";
                    apiResponse.LoginAgain = (response.StatusCode == HttpStatusCode.Unauthorized);
                }
                catch (Exception)
                {
                    apiResponse.ErrorDescription = "Erro desconhecido";
                }
            }

            return apiResponse;
        }

        public Response<T> BuildOfflineResponse<T>()
        {
            return new Response<T>
            {
                Success = false,
                ErrorDescription = "Aplicativo Offline"
            };
        }
    }
}
