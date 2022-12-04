using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface ITrainerCourseService
    {
        public List<Course> GetTrainerCourseByUserId(int id);
        public List<Trainer> GetTrainerByCourseId(int id)
    }
}
