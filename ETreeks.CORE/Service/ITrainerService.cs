using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface ITrainerService
    {
        public List<KeyValuePair<string, int>> CreateTrainer(TrainerLogin trainerlogin);
        public List<TrainerUser> GetTrainerUser();
        public trainerEmail getTrainerEmailbyId(int id);
    }
}
