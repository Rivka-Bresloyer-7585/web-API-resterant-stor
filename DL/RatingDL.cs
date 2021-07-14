using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL : IRatingDL
    {
        ApiDBContext _db;
        public IConfiguration Configuration { get; }

        public RatingDL(ApiDBContext api_DataBaseContext, IConfiguration configuration)
        {
            _db = api_DataBaseContext;
            Configuration = configuration;
        }
        public async Task postRating(Rating rating)
        {
            string query = "INSERT INTO RATING(HOST, METHOD, PATH, REFERER, USER_AGENT, Record_Date)" +
                "VALUES (@HOST, @METHOD, @PATH, @REFERER, @USER_AGENT, @Record_Date)";

            using (SqlConnection cn = new SqlConnection("Server=ריקי; Database=ApiDB;Trusted_Connection=True;"))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = rating.Host;
                cmd.Parameters.Add("@METHOD", SqlDbType.NVarChar, 10).Value = rating.Method;
                cmd.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = rating.Path;
                cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 100).Value = rating.Referer;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, 500).Value = rating.UserAgent;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
