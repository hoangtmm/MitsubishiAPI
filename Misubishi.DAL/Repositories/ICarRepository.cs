using Misubishi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misubishi.DAL.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car? GetById(int id);
        Car Create(Car car);
        void Update(Car car);
        void Delete(int id);
        List<Car> Search(string name, int? categoryId);
    }
}
