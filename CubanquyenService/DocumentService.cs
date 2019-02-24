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
    public interface IDocumentService
    {
        Document Add(Document model);

        void Update(Document model);

        Document Delete(int id);

        IEnumerable<Document> GetAll();

        IEnumerable<Document> GetAllByCategoryId(int categoryId);

        Document GetById(int id);

        Document GetByUrl(string url);

        DocumentView All(string searchKey, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize);

        void Save();
    }
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository _documentRepository;
        private IUnitOfWork _unitOfWork;
        public DocumentService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
        {
            this._documentRepository = documentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Document Add(Document model)
        {
            return _documentRepository.Add(model);
        }

        public Document Delete(int id)
        {
            return _documentRepository.Delete(id);
        }

        public IEnumerable<Document> GetAll()
        {
            return _documentRepository.GetAll();
        }
        public IEnumerable<Document> GetAllByCategoryId(int categoryId)
        {
            return _documentRepository.GetAll().Where(x => x.categoryId == categoryId && x.isTrash == false);
        }

        public Document GetById(int id)
        {
            return _documentRepository.GetSingleById(id);
        }
        public Document GetByUrl(string url)
        {
            return _documentRepository.GetByUrl(url);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Document model)
        {
            _documentRepository.Update(model);
        }

        public DocumentView All(string searchKey, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize)
        {
            var entitys = GetAll();
            if (isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == isTrash);
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                entitys = entitys.Where(x => x.documentName.ToLower().Contains(searchKey.ToLower().Trim()));
            }
            if (fromDate.HasValue)
            {
                entitys = entitys.Where(x => x.issuedTime.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                entitys = entitys.Where(x => x.issuedTime.Date <= toDate.Value.Date);
            }
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
            var result = new DocumentView { Total = totalPage, Documents = entitys };
            return result;
        }
    }
}
