using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class AddViewModel : ViewModelBase
    {
        private string title;
        private string description;
        private TodoItem lastItem = new TodoItem("", "");
        public TodoItem Item = new TodoItem("", "");
        public AddViewModel(TodoItem item) : this()
        {
            Item = item;
            lastItem = (TodoItem)item.Clone();
            Title = Item.Title;
            Description = Item.Description;
        }
        public AddViewModel()
        {
            var msgEnabled = this.WhenAnyValue(
                msg => msg.Title,
                msg => !string.IsNullOrWhiteSpace(msg)
            );

            Send = ReactiveCommand.Create(() => new TodoItem(Title, Description), msgEnabled);
            Cancel = ReactiveCommand.Create(() => {
                Item.Title = lastItem.Title;
                Item.Description = lastItem.Description;
            });
        }
        public ReactiveCommand<Unit, TodoItem> Send { get; set; }
        public ReactiveCommand<Unit, Unit> Cancel { get; set; }

        public string Title
        {
            get => title;
            set{
                Item.Title = value;
                this.RaiseAndSetIfChanged(ref title, value);
            }
        }
        public string Description
        {
            get => description;
            set{
                Item.Description = value;
                this.RaiseAndSetIfChanged(ref description, value);
            }
        }

    }
}
