using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AircraftPartsLibrary
{
    public class JsonPartRepository : IPartRepository
    {
        private readonly string _filePath;
        private List<Part> _parts;
        private int _nextId;

        public JsonPartRepository(string filePath = "parts.json")
        {
            _filePath = filePath;
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _parts = JsonConvert.DeserializeObject<List<Part>>(json) ?? new List<Part>();
            }
            else
            {
                _parts = new List<Part>();
            }
            _nextId = _parts.Count > 0 ? _parts.Max(p => p.Id) + 1 : 1;
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(_parts, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<Part> GetAll()
        {
            return _parts;
        }

        public Part GetById(int id)
        {
            return _parts.FirstOrDefault(p => p.Id == id);
        }

        public Part GetByPartNumber(string partNumber)
        {
            return _parts.FirstOrDefault(p => p.PartNumber == partNumber);
        }

        public void Add(Part part)
        {
            part.Id = _nextId++;
            _parts.Add(part);
            SaveData();
        }

        public void Update(Part part)
        {
            var existing = GetById(part.Id);
            if (existing != null)
            {
                existing.Name = part.Name;
                existing.PartNumber = part.PartNumber;
                existing.Type = part.Type;
                existing.ManufactureDate = part.ManufactureDate;
                existing.Status = part.Status;
                existing.AircraftId = part.AircraftId;
                existing.Description = part.Description;
                SaveData();
            }
        }

        public void Delete(int id)
        {
            var part = GetById(id);
            if (part != null)
            {
                _parts.Remove(part);
                SaveData();
            }
        }

        public void Save()
        {
            SaveData();
        }
    }
}