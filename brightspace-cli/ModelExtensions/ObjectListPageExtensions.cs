using BrightspaceCli.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrightspaceCli.ModelExtensions
{
    public static class ObjectListPageExtensions
    {
        public static async Task<IReadOnlyCollection<T>> All<T>(this ObjectListPage<T> objectList, Context context)
        {
            var data = new List<T>();
            while (true)
            {
                data.AddRange(objectList.Objects);

                if(string.IsNullOrWhiteSpace(objectList.Next))
                {
                    break;
                }

                objectList = await context.Request<ObjectListPage<T>>(objectList.Next);
            }

            return data;
        }
    }
}
