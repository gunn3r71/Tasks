using System;
using Microsoft.AspNetCore.Mvc;
using API.Data.Interfaces;
using API.Models.Tasks.Input;
using AutoMapper;
using API.Domain.Entities;
using API.Models.Tasks.Output;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(CreateTaskInputViewModel createTask)
        {
            try
            {
                var task = _mapper.Map<CreateTaskInputViewModel, Task>(createTask);
                _repository.Save(task);
                _unitOfWork.Commit();

                return Created($"/api/v1/Tasks/{task.Id}",task);
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, UpdateTaskInputViewModel updateTask)
        {
            try
            {
                if (id != updateTask.Id)
                    return BadRequest("Check data consistency");
                var task = _mapper.Map<UpdateTaskInputViewModel, Task>(updateTask);
                _repository.Update(task);
                _unitOfWork.Commit();

                return NoContent();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var task = _repository.GetById(id);
                if (task == null)
                    return NotFound("Task not found");

                _repository.Delete(task);
                _unitOfWork.Commit();

                return NoContent();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_repository.List());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var task = _repository.GetById(id);
                if (task == null)
                    return NotFound("Task not found");
                
                var taskOutput = _mapper.Map<Task, TaskOutputViewModel>(task);

                return Ok(taskOutput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
