﻿using employeeRecord.DTOs;
using employeeRecord.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employeeRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;  //injects or bring in Service
        public AccountController(IAccountService accountService)  //Using constuctor ctor

        {
            _accountService = accountService;  //Register AccountService
        }
        [HttpPost("CreateAccount")]   //creates the Post record End point.

        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDTO payload)  //Declaring Fucmtion with two Parameters
        {
            var response = await _accountService.CreateAccountAsync(payload);  //access the create Account Method, using await because the method is Async.

            return Ok(response);


        }

        [HttpGet("GetAllRecords")]  //Creates the Get Record End point
        public async Task<IActionResult> GetAllRecords()
        {
            var response = await _accountService.GetAllRecords();  //Access the Get record Method

            return Ok(response);


        }
        //to Implement GetRecordById
        [HttpGet("GetRecordByID/EmployeeID")]  //Creates the GetRecordByID End point
        public async Task<IActionResult> GetRecordById(string EmployeeId)
        {
            var response = await _accountService.GetRecordById(EmployeeId);  //Access the Get record Method

            return Ok(response);


        }
        // implementing update record in the Account Controller
        [HttpPut("UpdateAccount")]   //creates the Put record End point.

        public async Task<IActionResult> updateAccountAsync([FromBody] CreateAccountDTO payload)  //Declaring Fucmtion with two Parameters
        {
            var response = await _accountService.UpdateAccountAsync(payload);  //access the Put Record Method, using await because the method is Async.

            return Ok(response);


        }

        [HttpDelete("DeleteRecordById/EmployeeID")]  //Creates the DeleteRecordByID End point
        public async Task<IActionResult> DeleteRecordById(String EmployeeId)
        {
            var response = await _accountService.DeleteRecordById(EmployeeId);  //Access the DeleteRecordBYID  Method

            return Ok(response);
        }
    }
}

