namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByUrl(string url);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Category GetByUrl(string url)
        {
            return this.DbContext.Categories.FirstOrDefault(x => x.categoryUrl.Replace("/chuyen-muc/", "") == url && x.isTrash == false);
        }
    }

    public interface IQuestionRepository : IRepository<Question>
    {
    }

    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IAnswerRepository : IRepository<Answer>
    {
        Category GetByUrl(string url);
    }

    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Category GetByUrl(string url)
        {
            return this.DbContext.Categories.FirstOrDefault(x => x.categoryUrl.Replace("/chuyen-muc/", "") == url && x.isTrash == false);
        }
    }
}
