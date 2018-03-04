using System.Collections.Generic;
using System.IO;
using System.Linq;
using LodestarHealthDataApi.Models;

namespace LodestarHealthDataApi.Data
{
    public class DataReader
    {
        private readonly LodestarAPIContext _context;
        public DataReader(LodestarAPIContext context) {
            // check if data exists in the database
            // if not ReadFacilityData from the file 
            // add it to the database
            Facility[] facilities = ReadFacilityData("");
            _context.AddRangeAsync(facilities);

        }

        private static Facility FacilityFactory(string data) 
        {
            var commaSeperated = data.Split(',');
            
            // ... all the logic to turn one row of csv data into a facility
            return new Facility();
        }

        public static Facility[] ReadFacilityData(string dataPath)
        {
            
           var data = 
                File.ReadAllLines(dataPath)
                .Skip(1) // skip header
                .Select(FacilityFactory)
                .ToArray();
            
            return data;
        }
    }
}