﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [JsonPropertyName("_id")]
        public string _Id { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("eyeColor")]
        public string EyeColor { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("gender")]
        public string Gender{ get; set; }
        [JsonPropertyName("company")]
        public string Company { get; set; }
        [JsonPropertyName("email")]
        [EmailAddress]
        public string Email { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("address")]
        [ValidateNever]
        public virtual Address Address { get; set; }
        [JsonPropertyName("about")]
        public string About { get; set; }
        [JsonPropertyName("registered")]
        public string Registered { get; set; }
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
