namespace CucbanquyenData.Infrastructure
{
    using System;
    public interface IDbFactory : IDisposable
    {
        CucbanquyenDbContext Init();
    }
}
