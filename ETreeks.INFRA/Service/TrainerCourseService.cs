﻿using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class TrainerCourseService : IService<TrainerCourse>,ITrainerCourseService
    {
        private readonly IRepository<TrainerCourse> _trainerCourseRepository;
        private readonly ITrainerCourseRepository _courseRepository;
        public TrainerCourseService(IRepository<TrainerCourse> trainerCourseRepository, ITrainerCourseRepository courseRepository)
        {
            _trainerCourseRepository = trainerCourseRepository;
            _courseRepository = courseRepository;
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

        public TrainerCourse GetIdTrainerCourse(int c_id, int t_id)
        {
            return _courseRepository.GetIdTrainerCourse(c_id, t_id);    
        }

        public List<TrainerUser> GetTrainerByCourseId(int id)
        {
           return _courseRepository.GetTrainerByCourseId(id);
        }

        public List<Course> GetTrainerCourseByUserId(int id)
        {
           return _courseRepository.GetTrainerCourseByUserId(id);
        }

        public List<TrainerOfEachCourse> GetTrainerOfEachCourse()
        {
            return _courseRepository.GetTrainerOfEachCourse();
        }

        public List<TrainerUser> SearchTrainerByCourseId(int id, string c_name)
        {
            return _courseRepository.SearchTrainerByCourseId(id, c_name);
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
