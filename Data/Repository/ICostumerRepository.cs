using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCredit.API.Model;

namespace MyCredit.API.Data.Repository
{
    public interface ICostumerRepository
    {
        public List<KeyValuePair<int, string>> Load();
        public string Get(int id);


    }
}
