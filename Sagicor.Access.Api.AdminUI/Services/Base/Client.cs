namespace Sagicor.Access.Api.AdminUI.Services.Base
{
    public partial class Client:IClient
    {
        public HttpClient HttpClient 
        {
            get
            {
                return _httpClient;
            } 
        }
    }
}
