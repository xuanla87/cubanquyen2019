

namespace CucbanquyenData.Repositories
{
    using CucbanquyenData.Infrastructure;
    using CucbanquyenModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDocumentRepository : IRepository<Document>
    {
        IEnumerable<Document> GetByTypeId(int typeId);
        Document GetByUrl(string url);
    }
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Document> GetByTypeId(int typeId)
        {
            return this.DbContext.Documents.Where(x => x.documentTypeId == typeId);
        }
        public Document GetByUrl(string url)
        {
            return this.DbContext.Documents.FirstOrDefault(x => x.documentUrl.Replace("/van-ban/", "") == url && x.isTrash == false);
        }
    }
}
