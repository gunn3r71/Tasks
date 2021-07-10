using System;

namespace API.Models.Tasks.Input
{
    public class UpdateTaskInputViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}