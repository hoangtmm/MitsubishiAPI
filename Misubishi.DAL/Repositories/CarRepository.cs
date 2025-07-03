using Microsoft.EntityFrameworkCore;
using Misubishi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misubishi.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly MitsubishiDbContext _context;

        public CarRepository(MitsubishiDbContext context)
        {
            _context = context;
        }

        public List<Car> GetAll() => _context.Cars.Include(c => c.Category).ToList();

        public Car? GetById(int id) =>
            _context.Cars.Include(c => c.Category).FirstOrDefault(c => c.Id == id);

        public Car Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public List<Car> Search(string name, int? categoryId)
        {
            var query = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.Contains(name));
            if (categoryId.HasValue)
                query = query.Where(c => c.CategoryId == categoryId);

            return query.Include(c => c.Category).ToList();
        }
    }
}
