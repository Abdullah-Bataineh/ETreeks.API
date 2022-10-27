using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class TrainerCourseService : IService<TrainerCourse>
    {
        private readonly IRepository<TrainerCourse> _trainerCourseRepository;
        public TrainerCourseService(IRepository<TrainerCourse> trainerCourseRepository)
        {
            _trainerCourseRepository = trainerCourseRepository;
        }
        public bool Create(TrainerCourse trainerCourse)
        {
            int result;
            result = _trainerCourseRepository.Create(trainerCourse);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _trainerCourseRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<TrainerCourse> GetAll()
        {
            return _trainerCourseRepository.GetAll();
        }

        public TrainerCourse GetById(int id)
        {
            return _trainerCourseRepository.GetById(id);
        }

        public bool Update(TrainerCourse trainerCourse)
        {

            int result;
            result = _trainerCourseRepository.Update(trainerCourse);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
