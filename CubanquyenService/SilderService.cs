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
    public interface ISliderService
    {
        Slider Add(Slider model);
        void Update(Slider model);

        Slider Delete(int id);

        IEnumerable<Slider> GetAll();

        Slider GetById(int id);

        SliderView All(string searchKey, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize);

        void Save();
    }

    public class SilderService : ISliderService
    {
        private ISliderRepository _sliderRepository;
        private IUnitOfWork _unitOfWork;
        public SilderService(ISliderRepository sliderRepository, IUnitOfWork unitOfWork)
        {
            this._sliderRepository = sliderRepository;
            this._unitOfWork = unitOfWork;
        }

        public Slider Add(Slider model)
        {
            return _sliderRepository.Add(model);
        }
        public Slider Delete(int id)
        {
            return _sliderRepository.Delete(id);
        }

        public IEnumerable<Slider> GetAll()
        {
            return _sliderRepository.GetAll();
        }

        public Slider GetById(int id)
        {
            return _sliderRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Slider model)
        {
            _sliderRepository.Update(model);
        }

        public SliderView All(string searchKey, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize)
        {
            var entitys = GetAll();
            if (isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == isTrash);
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                entitys = entitys.Where(x => x.sliderName.ToLower().Contains(searchKey.ToLower().Trim()));
            }
            if (fromDate.HasValue)
            {
                entitys = entitys.Where(x => x.createTime.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                entitys = entitys.Where(x => x.createTime.Date <= toDate.Value.Date);
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
            var result = new SliderView { Total = totalPage, Sliders = entitys };
            return result;
        }
    }
}
