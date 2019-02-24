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
    public interface IDetailSilderService
    {
        SliderDetail Add(SliderDetail model);
        void Update(SliderDetail model);

        SliderDetail Delete(int id);

        IEnumerable<SliderDetail> GetAll();
        IEnumerable<SliderDetail> GetAllBySliderId(int id);
        SliderDetail GetById(int id);
        void Save();
    }
    public class DetailSilderService: IDetailSilderService
    {
        private ISliderDetailRepository _sliderDetailRepository;
        private IUnitOfWork _unitOfWork;
        public DetailSilderService(ISliderDetailRepository sliderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._sliderDetailRepository = sliderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public SliderDetail Add(SliderDetail model)
        {
            return _sliderDetailRepository.Add(model);
        }
        public SliderDetail Delete(int id)
        {
            return _sliderDetailRepository.Delete(id);
        }

        public IEnumerable<SliderDetail> GetAll()
        {
            return _sliderDetailRepository.GetAll();
        }
        public IEnumerable<SliderDetail> GetAllBySliderId(int id)
        {
            return _sliderDetailRepository.GetAll().Where(x => x.sliderId == id);
        }

        public SliderDetail GetById(int id)
        {
            return _sliderDetailRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SliderDetail model)
        {
            _sliderDetailRepository.Update(model);
        }
    }
}
