﻿using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface IAvailableTimeService
    {
        List<AvailableTime> GetByTrainer(int trainerId);
        public void updateStatusbyID(int id, int st);
        public List<AvailableTime> GetByTrainerid(int trainerId);
    }
}
