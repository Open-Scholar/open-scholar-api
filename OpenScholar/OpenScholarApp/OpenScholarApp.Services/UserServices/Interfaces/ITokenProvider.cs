using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.UserServices.Interfaces
{
    public interface ITokenProvider<T>
    {
        Task<T?> GetTokenAsync(string key);
        Task SetTokenAsync(string key, T Value);
    }
}
