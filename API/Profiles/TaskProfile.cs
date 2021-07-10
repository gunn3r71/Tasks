using API.Domain.Entities;
using API.Models.Tasks.Input;
using API.Models.Tasks.Output;
using AutoMapper;

namespace API.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskOutputViewModel>();
            CreateMap<CreateTaskInputViewModel, Task>();
            CreateMap<UpdateTaskInputViewModel, Task>();
        }
    }
}