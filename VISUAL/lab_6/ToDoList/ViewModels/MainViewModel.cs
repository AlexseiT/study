using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ReactiveUI;

namespace ToDoList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private TodoItem newTitle;
        private DateTimeOffset? currentDate = DateTime.Today;
        private List<TodoItem> allItems = new List<TodoItem>();
        private List<TodoItem> currentItems = new List<TodoItem>();
        private ObservableCollection<TodoItem> items;
        public MainViewModel()
        {
            Items = new ObservableCollection<TodoItem>(allItems);
        }
        public ObservableCollection<TodoItem> Items {
            get => items;
            set
            {
                this.RaiseAndSetIfChanged(ref items, value);
            }
        }
        public TodoItem NewItem
        {
            get { return newTitle; }
            set
            {
                value.Date = currentDate;
                allItems.Add(value);
            }
        }
        public TodoItem DeleteItem
        {
            set
            {
                Items.Remove(value);
            }
        }
        public DateTimeOffset? CurrentDate
        {
            get { return currentDate; }
            set { 
                currentDate = value;
                currentItems.Clear();
                foreach (var item in allItems)
                {
                    if(item.Date == currentDate)
                    {
                        currentItems.Add(item);
                    }
                }
                this.RaiseAndSetIfChanged(ref currentDate, value);
                Items = new ObservableCollection<TodoItem>(currentItems);
            }
        }
        private TodoItem[] BuildArray()
        {
            return new TodoItem[]
            {
                new TodoItem("1", "2"),
                new TodoItem("2", "2")
            };
        }
    }
}
