using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebMotorsDesafio.Repositories
{
    public class BaseRepository
    {
        public string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["wMotorsConnectionString"].ConnectionString;
    }
}