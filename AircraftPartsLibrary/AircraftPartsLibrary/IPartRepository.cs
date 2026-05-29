using System.Collections.Generic;

namespace AircraftPartsLibrary
{
    public interface IPartRepository
    {
        IEnumerable<Part> GetAll();
        Part GetById(int id);
        Part GetByPartNumber(string partNumber);
        void Add(Part part);
        void Update(Part part);
        void Delete(int id);
        void Save();
    }
}