using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICatagoryDL
    {
        Task<List<Catagory>> getCatagory();
        Task<List<Catagory>> getCatagory(int id);
    }
}