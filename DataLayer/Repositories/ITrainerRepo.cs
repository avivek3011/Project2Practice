using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;


namespace DataLayer.Repositories
{
    public interface ITrainerRepo
    {

        void Add(Trainer trainer,TrainerDetails trainerDetails);
        Trainer Login(Trainer trainer);
        Trainer Display(int id);

        
    }
}
