
namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IMenuRepository : IRepository<Menu>
    {
        Menu GetById(int id);
    }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Menu GetById(int id)
        {
            return this.DbContext.Menus.FirstOrDefault(x => x.menuId == id && x.isTrash == false);
        }
    }
}
