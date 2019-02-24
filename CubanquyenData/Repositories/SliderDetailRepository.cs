namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ISliderDetailRepository : IRepository<SliderDetail>
    {
        SliderDetail GetById(int id);
    }
    public class SliderDetailRepository : RepositoryBase<SliderDetail>, ISliderDetailRepository
    {
        public SliderDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public SliderDetail GetById(int id)
        {
            return this.DbContext.SliderDetails.FirstOrDefault(x => x.detailId == id );
        }
    }
}
