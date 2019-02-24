
namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVideoRepository : IRepository<Video>
    {
        IEnumerable<Video> GetByTitle(string title);
    }
    public class VideoRepository: RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Video> GetByTitle(string title)
        {
            return this.DbContext.Videos.Where(x => x.videoTitle == title && x.isTrash == false);
        }
    }

    //public interface IVisiterRepository : IRepository<Visiter>
    //{
       
    //}
    //public class VisiterRepository : RepositoryBase<Visiter>, IVisiterRepository
    //{
    //    public VisiterRepository(IDbFactory dbFactory)
    //        : base(dbFactory)
    //    {
    //    }
    //}
}
