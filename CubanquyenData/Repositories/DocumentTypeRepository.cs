

namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDocumentTypeRepository : IRepository<DocumentType>
    {
        IEnumerable<DocumentType> GetByName(string name);
    }
    public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<DocumentType> GetByName(string name)
        {
            return this.DbContext.DocumentTypes.Where(x => x.documentTypeName == name);
        }
    }
    
}
