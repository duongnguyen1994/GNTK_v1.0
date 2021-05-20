using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.BAL.Interface
{
    public interface IAuthService
    {
        public Task<string> Authenticate(string username, string password);
    }
}
