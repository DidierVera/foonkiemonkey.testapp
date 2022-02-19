using Infrastructure.Models;
using Refit;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class RefitService
    {
        private string BASE_URL = "https://reqres.in";

        /// <summary>
        /// Consulta usuarios por página
        /// </summary>
        /// <returns></returns>
        public async Task<RootModel> GetUsersByPage(int page)
        {
            var apiResponse = RestService.For<IUserService>(BASE_URL);
            var values = await apiResponse.GetUsersByPage(page);
            return values;
        }
    }
}
