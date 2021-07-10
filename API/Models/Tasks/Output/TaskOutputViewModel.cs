using System;

namespace API.Models.Tasks.Output
{
    public class TaskOutputViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}