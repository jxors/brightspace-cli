using BrightspaceCli.ModelExtensions;
using BrightspaceCli.Models.Api;
using BrightspaceCli.Models.Enrollment;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BrightspaceCli.Requests
{
    public class CourseEndpoint
    {
        public static Task<PagedResultSet<MyOrgUnitInfo>> GetAll(Context context) 
            => context.Request<PagedResultSet<MyOrgUnitInfo>>(Resources.Lp("enrollments/myenrollments/"));

        public static async Task<IReadOnlyCollection<ClasslistUser>> GetClasslist(Context context, long courseId, string searchTerm = null)
        {
            var route = Resources.Le($"{courseId}/classlist/paged/");
            if(searchTerm != null)
            {
                route += $"?searchTerm={WebUtility.UrlEncode(searchTerm)}";
            }

            var page = await context.Request<ObjectListPage<ClasslistUser>>(route);
            return await page.All(context);
        }

        public static async Task<ClasslistUser> FindUserByUsername(Context context, long courseId, string username)
        {
            var data = await GetClasslist(context, courseId, searchTerm: username);
            foreach(var item in data)
            {
                if (item.Username == username)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
