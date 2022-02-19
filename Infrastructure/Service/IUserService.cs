using Refit;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IUserService
    {
        [Get("/api/users?page={page}")]
        Task<Models.RootModel> GetUsersByPage(int page);
    }
}
