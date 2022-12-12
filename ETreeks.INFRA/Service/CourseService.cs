using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class CourseService : IService<Course>,ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly ICourseRepository _course;
        public CourseService(IRepository<Course> courseRepository, ICourseRepository course)
        {
            _courseRepository = courseRepository;
            _course = course;
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
        public List<Course> GetByCatId(int cat_id)
        {
            return _course.GetByCatId(cat_id);
        }

        public List<CourseWithCategory> GetCourseWithCategory()
        {
            return _course.GetCourseWithCategory(); 
        }

        public List<Course> Search(string c_name)
        {
            return _course.Search(c_name);
        }

        public List<COURSEINCATEGORY> GetCourseinCategory()
        {
            return _course.GetCourseinCategory();
        }
    }
}
