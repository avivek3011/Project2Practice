using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TrainerRepo : ITrainerRepo
    {
        TrainerContext db;
        public TrainerRepo(TrainerContext _db)
        {
            db = _db;
        }


        public void Add(Trainer trainer, TrainerDetails trainerDetails)
        {
            db.Add(trainer);
            db.SaveChanges();
            trainerDetails.Trainer_Id = db.trainer.OrderByDescending(x =>x.Id).FirstOrDefault().Id;
            
            db.Add(trainerDetails);
            db.SaveChanges();

        }

        public Trainer Display(int id)
        {
                if (id != 0)
                {
                    return db.trainer.Where(s => s.Id == id).FirstOrDefault();
                }
                else
                    return null;
        }

        public void EditTrainer(Trainer trainer, TrainerDetails td)
        {
            throw new NotImplementedException();
        }

        public Trainer Login(Trainer _trainer)
        {
            var data = db.trainer.Where(t => t.Username == _trainer.Username && t.Password == _trainer.Password).FirstOrDefault();
            return data;
        }

        //public void EditTrainer(Trainer trainer, Trainer_Details td)
        //{
        //    if (trainer != null)
        //    {
        //        wtrainer.Entry(trainer).State = EntityState.Modified;
        //        wtrainer.SaveChanges();
        //        wtrainer.Entry(td).State = EntityState.Modified;
        //        wtrainer.SaveChanges();
        //    }

        //}
    }
}
