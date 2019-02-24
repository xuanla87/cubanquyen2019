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
    public interface ICategoryService
    {
        Category Add(Category model);

        void Update(Category model);

        Category Delete(int id);

        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetAllByParentId(int parentId);

        Category GetById(int id);

        Category GetByUrl(string url);

        void Save();
    }
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Category Add(Category model)
        {
            return _categoryRepository.Add(model);
        }

        public Category Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllByParentId(int parentId)
        {
            return _categoryRepository.GetMulti(x => x.isTrash == false && x.parentId == parentId);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetSingleById(id);
        }

        public Category GetByUrl(string url)
        {
            return _categoryRepository.GetByUrl(url);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Category model)
        {
            _categoryRepository.Update(model);
        }
    }

    public interface IQuestionService
    {
        Question Add(Question model);

        void Update(Question model);

        Question Delete(int id);

        IEnumerable<Question> GetAll();

        Question GetById(int id);

        QuestionView All(string searchKey, bool? isTrash, DateTime? formDate, DateTime? toDate, int? pageIndex, int? pageSize, int? languageId);

        void Save();
    }
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionRepository;
        private IUnitOfWork _unitOfWork;
        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this._questionRepository = questionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Question Add(Question model)
        {
            return _questionRepository.Add(model);
        }

        public Question Delete(int id)
        {
            return _questionRepository.Delete(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public Question GetById(int id)
        {
            return _questionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Question model)
        {
            _questionRepository.Update(model);
        }

        public QuestionView All(string searchKey, bool? isTrash, DateTime? formDate, DateTime? toDate, int? pageIndex, int? pageSize, int? languageId)
        {
            var entitys = GetAll();
            if (!string.IsNullOrEmpty(searchKey))
            {
                entitys = entitys.Where(x => x.questionTitle.ToLower().Contains(searchKey.ToLower().Trim()));
            }
            if (isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == isTrash);
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
            return new QuestionView { Questions = entitys, Total = totalPage };
        }
    }

    public interface IAnswerService
    {
        Answer Add(Answer model);

        void Update(Answer model);

        Answer Delete(int id);

        IEnumerable<Answer> GetAll();

        IEnumerable<Answer> GetByQuestionId(int questionId);

        Answer GetById(int id);

        void Save();

        AnswerView All(bool? isTrash, DateTime? formDate, DateTime? toDate, int? pageIndex, int? pageSize, int? languageId);
    }
    public class AnswerService : IAnswerService
    {
        private IAnswerRepository _answerRepository;
        private IUnitOfWork _unitOfWork;
        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this._answerRepository = answerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Answer Add(Answer model)
        {
            return _answerRepository.Add(model);
        }

        public Answer Delete(int id)
        {
            return _answerRepository.Delete(id);
        }

        public IEnumerable<Answer> GetAll()
        {
            return _answerRepository.GetAll();
        }

        public IEnumerable<Answer> GetByQuestionId(int questionId)
        {
            return _answerRepository.GetMulti(x => x.questionId == questionId);
        }

        public Answer GetById(int id)
        {
            return _answerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Answer model)
        {
            _answerRepository.Update(model);
        }
        public AnswerView All(bool? isTrash, DateTime? formDate, DateTime? toDate, int? pageIndex, int? pageSize, int? languageId)
        {
            var entitys = GetAll();

            if (isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == isTrash);
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
            return new AnswerView { Answers = entitys, Total = totalPage };
        }

    }
}
