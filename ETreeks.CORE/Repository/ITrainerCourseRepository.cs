﻿using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface ITrainerCourseRepository
    {
        public List<Course> GetTrainerCourseByUserId(int id);
        public List<TrainerUser> GetTrainerByCourseId(int id);
        public TrainerCourse GetIdTrainerCourse(int c_id, int t_id);
        public List<TrainerUser> SearchTrainerByCourseId(int id, string c_name);
        public List<TrainerOfEachCourse> GetTrainerOfEachCourse();
    }
}
