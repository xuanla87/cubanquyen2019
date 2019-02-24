namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPostRepository : IRepository<Post>
    {
        Post GetByUrl(string url);
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Post GetByUrl(string url)
        {
            return this.DbContext.Posts.FirstOrDefault(x => x.postUrl.Replace("/tin-tuc/","") == url && x.isTrash == false);
        }
    }
}
