using Entities;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DL
{
    public interface IRatingDL
    {
        IConfiguration Configuration { get; }

        Task postRating(Rating rating);
    }
}