using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    internal class CourseService : IService<Course>
    {
        private readonly IRepository<Course> _courseRepository;
        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool Create(Course course)
        {
            int result;
            result = _courseRepository.Create(course);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _courseRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public bool Update(Course course)
        {

            int result;
            result = _courseRepository.Update(course);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
