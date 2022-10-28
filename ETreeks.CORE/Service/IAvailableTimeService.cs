using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface IAvailableTimeService
    {
        AvailableTime GetByTrainer(int trainerId);
    }
}
