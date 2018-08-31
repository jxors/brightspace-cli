using BrightspaceCli.Models;
using System.Threading.Tasks;

namespace BrightspaceCli.Requests
{
    public class AuthStatusEndpoint
    {
        public static Task<WhoAmIUser> GetWhoAmIUser(Context context) 
            => context.Request<WhoAmIUser>(Resources.Lp("users/whoami"));
    }
}
