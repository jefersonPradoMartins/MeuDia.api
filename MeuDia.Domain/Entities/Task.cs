using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Domain.Entities
{
    public class TaskTag
    {
        public int TagId { get; set; }
        public int TaskId { get; set; }
    }

    public class Task
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<Tag> Tags { get; set; }

        public Task() { }
        public Task(string Description)
        {
            this.Description = Description;
        }


        public static TaskBuilder Create(string Description)
            => new TaskBuilder(Description);
        public class TaskBuilder
        {
            protected Task task;

            public TaskBuilder(string Description)
            {
                task = new Task(Description);
            }

            public TaskBuilder StartAt(DateTime StartAt)
            {
                task.StartAt = StartAt;
                return this;
            }
            public TaskBuilder EndAt(DateTime EndAt)
            {
                task.EndAt = EndAt;
                return this;
            }
            public TaskBuilder CreatedAt(DateTime CreatedAt)
            {
                task.CreatedAt = CreatedAt;
                return this;
            }
            public TaskBuilder WithTags(List<Tag> Tags)
            {
                task.Tags = Tags;
                return this;
            }

            public static implicit operator Task(TaskBuilder builder) => builder.task;


        }
    }
}
