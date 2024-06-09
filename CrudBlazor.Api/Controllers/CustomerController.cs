﻿using CrudBlazor.Api.ORM.DAO;
using CrudBlazor.Core.CRUD;
using CrudBlazor.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerDAO dao;
        public CustomerController(CustomerDAO dao) => this.dao = dao;

        [HttpGet("{id:long}")]
        public ActionResult FindById(ulong id)
        {
            try
            {
                var result = dao.FindByID(id);
                if (result != null)
                    return Ok(dao.FindByID(id));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("filter")]
        public ActionResult FindAll([FromBody] PaginateRequest<string> filter)
        {
            try
            {
                return Ok(dao.FindAll(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SaveOrUpdate(Customer obj)
        {
            try
            {
                return Ok(dao.SaveOrUpdate(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public ActionResult Delete(ulong id)
        {
            try
            {
                return Ok(dao.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
