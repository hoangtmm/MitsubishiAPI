using Misubishi.DAL.DTO;
using Misubishi.DAL.Entities;
using Misubishi.DAL.Repositories;

namespace Misubishi.BLL.Services
{
    public class CarService
    {
        private readonly ICarRepository _repo;

        public CarService(ICarRepository repo)
        {
            _repo = repo;
        }

        public List<Car> GetAll() => _repo.GetAll();

        public Car? GetById(int id) => _repo.GetById(id);

        public Car Create(CreateCarDto dto)
        {
            var car = new Car
            {
                Name = dto.Name,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                Description = dto.Description
            };
            return _repo.Create(car);
        }

        public void Update(int id, CreateCarDto dto)
        {
            var existing = _repo.GetById(id);
            if (existing != null)
            {
                existing.Name = dto.Name;
                existing.Price = dto.Price;
                existing.ImageUrl = dto.ImageUrl;
                existing.CategoryId = dto.CategoryId;
                existing.Description = dto.Description;
                _repo.Update(existing);
            }
        }

        public void Delete(int id) => _repo.Delete(id);

        public List<Car> Search(string name, int? categoryId) =>
            _repo.Search(name, categoryId);
    }
}
