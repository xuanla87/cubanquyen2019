namespace CucbanquyenData.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CucbanquyenDbContext dbContext;

        public CucbanquyenDbContext Init()
        {
            return dbContext ?? (dbContext = new CucbanquyenDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
