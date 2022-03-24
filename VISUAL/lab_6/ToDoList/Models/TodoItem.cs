using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class TodoItem : ICloneable
    {
        private string title = "";
        private string description = "";
        private DateTimeOffset? date;
        public TodoItem(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.date = DateTime.Now;
        }
        public string Title {
            get => title;
            set
            {
                if(value != null)
                {
                    title = value;
                }
            } 
        }
        public string Description
        {
            get => description;
            set
            {
                if (value != null)
                {
                    description = value;
                }
            }
        }
        public DateTimeOffset? Date
        {
            get => date;
            set
            {
                date = value;
            }
        }
        public object Clone()
        {
            return new TodoItem(title, description);
        }
    }
    
}
