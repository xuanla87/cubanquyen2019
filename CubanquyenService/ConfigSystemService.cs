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
    public interface IConfigSystemService
    {
        ConfigSystem Add(ConfigSystem model);

        void Update(ConfigSystem model);

        ConfigSystem Delete(int id);

        IEnumerable<ConfigSystem> GetAll();

        ConfigSystem GetByName(string name);

        void Save();
    }
    public class ConfigSystemService : IConfigSystemService
    {
        private IConfigSystemRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public ConfigSystemService(IConfigSystemRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;

        }
        public ConfigSystem Add(ConfigSystem model)
        {
            return _Repository.Add(model);
        }

        public ConfigSystem Delete(int id)
        {
            return _Repository.Delete(id);
        }

        public IEnumerable<ConfigSystem> GetAll()
        {
            return _Repository.GetAll();
        }

        public ConfigSystem GetByName(string name)
        {
            return _Repository.GetByName(name);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ConfigSystem model)
        {
            _Repository.Update(model);
        }
    }
}
