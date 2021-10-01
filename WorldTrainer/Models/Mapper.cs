using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTrainer.Models
{
    public class Mapper
    {
        public static DataLayer.Entities.Trainer Map(Models.TrainerModel trainer)
        {
            return new DataLayer.Entities.Trainer()
            {
                Id = trainer.id,
                Name = trainer.name,
                Username = trainer.username,
                Password = trainer.password,
                Age = trainer.age,
                Contact = trainer.contact,
                Email = trainer.email,
                Gender = trainer.gender,
            };
        }

        public static Models.TrainerModel Map(DataLayer.Entities.Trainer trainer)
        {
            return new Models.TrainerModel()
            {
                id = trainer.Id,
                name = trainer.Name,
                username = trainer.Username,
                password = trainer.Password,
                age = trainer.Age,
                contact = trainer.Contact,
                email = trainer.Email,
                gender = trainer.Gender,
            };
        }


        public static DataLayer.Entities.TrainerDetails MapDetails(Models.TrainerModel trainer)
        {
            return new DataLayer.Entities.TrainerDetails()
            {
                Experience = trainer.experience,
                Qualification = trainer.qualification
            };
        }


        public static DataLayer.Entities.Trainer MapLogin(TrainerModel trainer)
        {
            return new DataLayer.Entities.Trainer()
            {
                Username = trainer.username,
                Password = trainer.password
            };
        }

        public static IEnumerable<Models.TrainerModel> Map(IEnumerable<DataLayer.Entities.Trainer> trainer) => trainer.Select(Map);
    }
}
