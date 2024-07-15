using CustomerManagement.BLL.DTOs;
using CustomerManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.Unitily
{
    public static class Helpers
    {
        public static double CalculateDistance(CordinateDto customerDto, CordinateDto userDto)
        {
            double EarthRadiusKm = 6371.0;
            // Convert latitude and longitude from degrees to radians
            double lat1 = ToRadians(customerDto.Latitude);
            double lon1 = ToRadians(customerDto.Longitude);
            double lat2 = ToRadians(userDto.Latitude);
            double lon2 = ToRadians(userDto.Longitude);

            // Calculate differences in coordinates
            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            // Haversine formula
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculate distance
            double distance = EarthRadiusKm * c;

            return distance;
        }

        public static IEnumerable<Customer> FilterCustomers(IEnumerable<Customer> customers, string searchStr)
        {
            var result = customers.Where(c =>
            c.Name.Contains(searchStr) ||
            c.Email.Contains(searchStr) ||
            c.Phone.Contains(searchStr) ||
            c.Company.Contains(searchStr) ||
            c.Tags.Contains(searchStr) ||
            c.About.Contains(searchStr) ||
            c.EyeColor.Contains(searchStr) ||
            c.About.Contains(searchStr) ||
            c.Address.Street.Contains(searchStr) ||
            c.Address.City.Contains(searchStr) ||
            c.Address.State.Contains(searchStr) ||
            c.Address.ZipCode.ToString().Contains(searchStr)
            );
            return result;

        }
        private static double ToRadians(double v)
        {
            double result = (v * (Math.PI / 180));
            return result;
        }
    }
}
