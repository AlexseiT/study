using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            this.FindControl<DatePicker>("DataPicker").SelectedDateChanged += delegate
            {
                DateTimeOffset? selectedDate = this.FindControl<DatePicker>("DataPicker").SelectedDate;
                var context = this.DataContext as MainViewModel;
                if (context != null)
                    context.CurrentDate = selectedDate;
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
