using Api.Errors;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TodosController: BaseApiController
    {
        private readonly IGenericRepository<Todo> _todoRepo;
        private readonly IMapper _mapper;

        public TodosController(IGenericRepository<Todo> todoRepo, IMapper mapper)
        {
            _todoRepo = todoRepo;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<Pagination<TodoListDto>>> GetTodos (
            [FromQuery]TodoSpecParams todoParams)
        {
            var spec = new TodoWithCategorySpecification(todoParams);

            var countSpec = new TodoWithFiltersForCountSpecification(todoParams);
            var totalItems = await _todoRepo.CountAsync(countSpec);

            var products = await _todoRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Todo>, IReadOnlyList<TodoListDto>>(products);

            return Ok(new Pagination<TodoListDto>(todoParams.PageIndex, todoParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoDetailDto>> GetProduct(int id)
        {
            var spec = new TodoWithCategorySpecification(id);

            var todo = await _todoRepo.GetEntityWithSpec(spec);

            if (todo == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Todo, TodoDetailDto>(todo);
        }

    }
}
