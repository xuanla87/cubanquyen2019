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
    public interface IMenuService
    {
        Menu Add(Menu model);

        void Update(Menu model);

        Menu Delete(int id);

        IEnumerable<Menu> GetAll();

        Menu GetById(int id);

        void Save();
    }
    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IUnitOfWork _unitOfWork;
        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;

        }
        public Menu Add(Menu model)
        {
            return _menuRepository.Add(model);
        }

        public Menu Delete(int id)
        {
            return _menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Menu model)
        {
            _menuRepository.Update(model);
        }
    }
}
