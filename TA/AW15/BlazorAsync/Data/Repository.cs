using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace BlazorAsync.Data
{
    class Repository
    {
       public async Task<List<string>> GetBooks()
       {
       await Task.Run(() => Thread.Sleep(3000));
        return new string[]{"Book1", "Book2", "Book3"}.ToList();
       }
    }
}