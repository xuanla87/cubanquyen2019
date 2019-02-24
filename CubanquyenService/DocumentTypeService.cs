using CucbanquyenData.Infrastructure;
using CucbanquyenData.Repositories;
using CucbanquyenModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucbanquyenService
{
    public interface IDocumentTypeService
    {
        DocumentType Add(DocumentType model);

        void Update(DocumentType model);

        DocumentType Delete(int id);

        IEnumerable<DocumentType> GetAll();

        DocumentType GetById(int id);

        void Save();
    }
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDocumentTypeRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public DocumentTypeService(IDocumentTypeRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public DocumentType Add(DocumentType model)
        {
            return _Repository.Add(model);
        }

        public DocumentType Delete(int id)
        {
            return _Repository.Delete(id);
        }

        public IEnumerable<DocumentType> GetAll()
        {
            return _Repository.GetAll();
        }

        public DocumentType GetById(int id)
        {
            return _Repository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DocumentType model)
        {
            _Repository.Update(model);
        }
    }
}
