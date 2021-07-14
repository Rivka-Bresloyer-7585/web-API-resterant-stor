using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CatagoryDL:ICatagoryDL
    {

        ApiDBContext _db;
        public CatagoryDL(ApiDBContext api_DataBaseContext)
        {
            _db = api_DataBaseContext;
        }

        public async Task<List<Catagory>> getCatagory()
        {
            List<Catagory> catagories= await _db.Catagory.ToListAsync();
            return catagories;
        }

        public async Task<List<Catagory>> getCatagory(int id)
        {
            List<Catagory> catagories = await _db.Catagory.Where(c=>c.CategoryId==id).ToListAsync();
            return catagories;
        }

    }
}
