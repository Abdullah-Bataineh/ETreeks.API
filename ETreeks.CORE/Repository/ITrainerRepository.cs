﻿using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface ITrainerRepository
    {
        public List<KeyValuePair<string, int>> CreateTrainer(TrainerLogin trainerlogin);
    }
}