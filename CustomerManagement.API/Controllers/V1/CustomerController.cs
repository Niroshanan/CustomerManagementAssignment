using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using CustomerManagement.DAL.Entities;
using CustomerManagement.DAL.Data;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CustomerManagement.BLL.Unitily;
using CustomerManagement.BLL.DTOs;
using System.Collections.Generic;

namespace CustomerManagement.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericServices _services;
        public CustomerController(IGenericServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _services.Customer.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpPut]
        [Route("UpdateCustomer/{Id}")]
        public async Task<IActionResult> UpdateCustomer(Guid Id, CustomerEditDto customer)
        {
            try
            {
                await _services.Customer.UpdateCustomerAsync(Id, customer);
                return Ok("Customer Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDistance/{Id}")]
        public async Task<IActionResult> Get(Guid Id,[FromQuery] CordinateDto cordinateDto)
        {
            try
            {
                double? result = await _services.Customer.GetDistanceAsync(Id, cordinateDto);
                return Ok(result + " km");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery] string searchStr)
        {
            try
            {
                var customers = await _services.Customer.SearchCustomerAsync(searchStr);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GroupByZipCode")]
        public async Task<IActionResult> GroupByZipCode()
        {
            try
            {
                var values = await _services.Customer.GroupByZipCodeAsync();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
