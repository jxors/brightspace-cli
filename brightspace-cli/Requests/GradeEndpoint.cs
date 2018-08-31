using BrightspaceCli.Models.Api;
using BrightspaceCli.Models.Grades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrightspaceCli.Requests
{
    public class GradeEndpoint
    {
        public static Task<List<GradeObject>> GetAllForCourse(Context context, long courseId)
            => context.Request<List<GradeObject>>(Resources.Le($"{courseId}/grades/"));

        public static Task<GradeObject> Get(Context context, long courseId, long gradeObjId)
            => context.Request<GradeObject>(Resources.Le($"{courseId}/grades/{gradeObjId}"));

        public static Task<ObjectListPage<UserGradeValue>> GetValues(Context context, long courseId, long gradeObjId) 
            => context.Request<ObjectListPage<UserGradeValue>>(Resources.Le($"{courseId}/grades/{gradeObjId}/values/"));

        public static Task<GradeValue> GetValue(Context context, long courseId, long gradeObjId, long userId)
            => context.Request<GradeValue>(Resources.Le($"{courseId}/grades/{gradeObjId}/values/{userId}"));

        public static Task UpdateGrade(Context context, long courseId, long gradeObjectId, long userId, IncomingGradeValue value)
        {
            return context.Put(Resources.Le($"{courseId}/grades/{gradeObjectId}/values/{userId}"), value);
        }
    }
}
