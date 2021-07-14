using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CatagoryBL : ICatagoryBL
    {
        ICatagoryDL _catagoryDL;
        public CatagoryBL(ICatagoryDL catagory)
        {
            _catagoryDL = catagory;
        }

        public async Task<List<Catagory>> getCatagory()
        {
            return await _catagoryDL.getCatagory();
        }
        public async Task<List<Catagory>> getCatagory(int id)
        {
            return await _catagoryDL.getCatagory();
        }
    }
}
