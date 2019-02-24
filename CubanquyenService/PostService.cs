using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CucbanquyenData.Infrastructure;
using CucbanquyenData.Repositories;
using CucbanquyenModel.Models;

namespace CucbanquyenService
{
    public interface IPostService
    {
        Post Add(Post model);

        void Update(Post model);

        Post Delete(int id);

        IEnumerable<Post> GetAll();

        Post GetById(int id);

        Post GetByUrl(string url);

        PostView All(string searchKey, int? categoryId, bool? isTrash, DateTime? formDate, DateTime? toDate, int? pageIndex, int? pageSize, int? languageId);

        void Save();
    }
    public class PostService : IPostService
    {
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        public PostService(ICategoryRepository categoryRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public Post Add(Post model)
        {
            return _postRepository.Add(model);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }


        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public Post GetByUrl(string url)
        {
            return _postRepository.GetByUrl(url);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post model)
        {
            _postRepository.Update(model);
        }

        public PostView All(string searchKey, int? categoryId, bool? isTrash, DateTime? formDate, DateTime? toDate, int? pageIndex, int? pageSize, int? languageId)
        {
            var entitys = GetAll();
            if (!string.IsNullOrEmpty(searchKey))
            {
                entitys = entitys.Where(x => x.postName.ToLower().Contains(searchKey.ToLower().Trim()));
            }
            if (isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == isTrash);
            }
            if (categoryId.HasValue)
            {
                entitys = entitys.Where(x => x.categoryId == categoryId.Value);
            }
            if (formDate.HasValue)
            {
                entitys = entitys.Where(x => x.createTime.Date >= formDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                entitys = entitys.Where(x => x.createTime.Date <= toDate.Value.Date);
            }
            if (languageId.HasValue)
            {
                entitys = entitys.Where(x => x.languageId == languageId.Value);
            }
            entitys = entitys.OrderByDescending(x => x.createTime);
            var totalRecord = entitys.Count();
            if (pageIndex != null && pageSize != null)
            {
                entitys = entitys.Skip(((int)pageIndex - 1) * (int)pageSize);
            }
            var totalPage = 0;
            if (pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / pageSize.Value);
                entitys = entitys.Take((int)pageSize);
            }
            return new PostView { Posts = entitys, Total = totalPage };
        }
    }
}
