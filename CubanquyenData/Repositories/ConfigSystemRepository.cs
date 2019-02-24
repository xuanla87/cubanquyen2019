namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IConfigSystemRepository : IRepository<ConfigSystem>
    {
        ConfigSystem GetByName(string name);
    }
    public class ConfigSystemRepository : RepositoryBase<ConfigSystem>, IConfigSystemRepository
    {
        public ConfigSystemRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public ConfigSystem GetByName(string name)
        {
            return this.DbContext.ConfigSystems.FirstOrDefault(x => x.configName == name);
        }
    }

}
