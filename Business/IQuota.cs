using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCredit.API.Model;
namespace MyCredit.API.Business
{
    public interface IQuota
    {
        public Quota Insert();
    }
}
