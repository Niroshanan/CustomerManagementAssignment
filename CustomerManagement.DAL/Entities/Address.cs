using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("zipcode")]
        public int ZipCode { get; set; }
        [ValidateNever]
        public Guid CustomerId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
