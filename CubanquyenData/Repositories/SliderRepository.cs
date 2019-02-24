
namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ISliderRepository : IRepository<Slider>
    {
        Slider GetById(int id);
    }
    public class SliderRepository : RepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Slider GetById(int id)
        {
            return this.DbContext.Sliders.FirstOrDefault(x => x.sliderId == id && x.isTrash == false);
        }
    }

}
