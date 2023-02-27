using Microsoft.EntityFrameworkCore;
using WebApplicationNet6.Class;
using WebApplicationNet6.Interface;
using WebApplicationNet6.Model;

namespace WebApplicationNet6.Service
{
    public class SampleService : ISampleService
    {
        private readonly IScoped _iScoped;
        private readonly ISingleton _iSingleton;
        private readonly ITransient _iTransient;
        private readonly BlogContext _blogContext;

        public SampleService(IScoped _iscoped, ISingleton iSingleton, ITransient iTransient, BlogContext blogContext)
        {
            _iScoped = _iscoped;
            _iSingleton = iSingleton;
            _iTransient = iTransient;
            _blogContext = blogContext;
        }


        public SampleClass GetSampleServiceHashCode()
        {
            return new SampleClass()
            {
                SampleScoped = _iScoped.GetHashCode(),
                SampleSingleton = _iSingleton.GetHashCode(),
                SampleTransient = _iTransient.GetHashCode(),
            };
        }

        public List<User> GetUserInfoAndData()
        {
            var result = _blogContext.Users.FromSqlRaw("SELECT * FROM dbo.Users").ToList();
            // 也可以用來執行預存程序
            //var result = _blogContext.Users.FromSqlRaw("EXECUTE dbo.sp_GetUser").ToList();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<User> GetUserInfoAndDataByInterpolated(Guid Id)
        {
            // FromSqlInterpolated會將字串轉為參數的形式，以避免SQL injection
            var result = _blogContext.Users.FromSqlInterpolated($"SELECT * FROM dbo.Users WHERE Id = {Id}").ToList();
            return result;
        }

        /// <summary>
        /// 查詢效能相關演示
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserTest()
        {
            // 純查詢就AsNoTracking()不追蹤
            var result = _blogContext.Users.FromSqlRaw("SELECT * FROM dbo.Users").AsNoTracking().ToList();
            // 或是直接在DbContext執行個體的層級直接變更預設的追蹤行為
            _blogContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var userDefaultNoTracking = _blogContext.Users.ToList();
            return result;
        }
    }
}
