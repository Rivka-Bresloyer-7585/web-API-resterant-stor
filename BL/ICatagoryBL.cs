using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICatagoryBL
    {
        Task<List<Catagory>> getCatagory();
        Task<List<Catagory>> getCatagory(int id);
    }
}