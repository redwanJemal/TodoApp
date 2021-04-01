using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Services.Dto;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController: Controller
    {
        private readonly IBaseService<TestEntity> _service;
        private readonly IMapper _mapper;

        public TestController(IBaseService<TestEntity> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<TestDto>> Get()
        {
            var tests = await _service.ListAsync();
            var data = _mapper.Map<IReadOnlyList<TestEntity>, IReadOnlyList<TestDto>>(tests);
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TestDto>> GetById(int id)
        {
            var result = await _service.ReadAsync(id);
            var data = _mapper.Map<TestEntity, TestDto>(result);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<TestDto>> CreateTest(TestEntity testEntity)
        {
            await _service.CreateAsync(testEntity);
            return Ok("Created Successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }
}
