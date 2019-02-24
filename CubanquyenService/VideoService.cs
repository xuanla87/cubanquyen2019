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
    public interface IVideoService
    {
        Video Add(Video model);

        void Update(Video model);

        Video Delete(int id);

        IEnumerable<Video> GetAll();

        Video GetById(int id);

        VideoView All(string searchKey, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize);

        void Save();
    }
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;
        private IUnitOfWork _unitOfWork;
        public VideoService(IVideoRepository videoRepository, IUnitOfWork unitOfWork)
        {
            this._videoRepository = videoRepository;
            this._unitOfWork = unitOfWork;
        }

        public Video Add(Video model)
        {
            return _videoRepository.Add(model);
        }

        public Video Delete(int id)
        {
            return _videoRepository.Delete(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _videoRepository.GetAll().OrderByDescending(x => x.updateTime);
        }

        public Video GetById(int id)
        {
            return _videoRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Video model)
        {
            _videoRepository.Update(model);
        }

        public VideoView All(string searchKey, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize)
        {
            var entitys = GetAll();
            if (isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == isTrash);
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                entitys = entitys.Where(x => x.videoTitle.ToLower().Contains(searchKey.ToLower().Trim()));
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
            var result = new VideoView { Total = totalPage, Videos = entitys };
            return result;
        }
    }

    //public interface IVisiterService
    //{
    //    Visiter Add(Visiter model);

    //    void Update(Visiter model);

    //    Visiter Delete(int id);

    //    IEnumerable<Visiter> GetAll();

    //    Visiter GetById(int id);

    //    VisiterView All(string searchKey, DateTime? fromDate, DateTime? toDate, int? pageIndex, int? pageSize);

    //    void Save();
    //}
    //public class VisiterService : IVisiterService
    //{
    //    private IVisiterRepository _visiterRepository;
    //    private IUnitOfWork _unitOfWork;
    //    public VisiterService(IVisiterRepository visiterRepository, IUnitOfWork unitOfWork)
    //    {
    //        this._visiterRepository = visiterRepository;
    //        this._unitOfWork = unitOfWork;
    //    }
    //    public Visiter Add(Visiter model)
    //    {
    //        return _visiterRepository.Add(model);
    //    }

    //    public Visiter Delete(int id)
    //    {
    //        return _visiterRepository.Delete(id);
    //    }

    //    public IEnumerable<Visiter> GetAll()
    //    {
    //        return _visiterRepository.GetAll();
    //    }

    //    public Visiter GetById(int id)
    //    {
    //        return _visiterRepository.GetSingleById(id);
    //    }

    //    public void Save()
    //    {
    //        _unitOfWork.Commit();
    //    }

    //    public void Update(Visiter model)
    //    {
    //        _visiterRepository.Update(model);
    //    }

    //    public VisiterView All(string searchKey, DateTime? fromDate, DateTime? toDate, int? pageIndex, int? pageSize)
    //    {
    //        var entitys = GetAll();
    //        if (!string.IsNullOrEmpty(searchKey))
    //        {
    //            entitys = entitys.Where(x => x.visiterIP.ToLower().Contains(searchKey.ToLower().Trim()));
    //        }
    //        if (fromDate.HasValue)
    //        {
    //            entitys = entitys.Where(x => x.createTime.Date >= fromDate.Value.Date);
    //        }
    //        if (toDate.HasValue)
    //        {
    //            entitys = entitys.Where(x => x.createTime.Date <= toDate.Value.Date);
    //        }
    //        var totalRecord = entitys.Count();
    //        if (pageIndex != null && pageSize != null)
    //        {
    //            entitys = entitys.Skip(((int)pageIndex - 1) * (int)pageSize);
    //        }
    //        var totalPage = 0;
    //        if (pageSize != null)
    //        {
    //            totalPage = (int)Math.Ceiling(1.0 * totalRecord / pageSize.Value);
    //            entitys = entitys.Take((int)pageSize);
    //        }
    //        var result = new VisiterView { Total = totalPage, Visiters = entitys };
    //        return result;
    //    }
    //}
}
