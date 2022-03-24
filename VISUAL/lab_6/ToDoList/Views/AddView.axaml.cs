using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class AddView : UserControl
    {
        public AddView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
