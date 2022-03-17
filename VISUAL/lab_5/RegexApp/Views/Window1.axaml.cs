using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegexApp.ViewModels;

namespace RegexApp.Views
{
    public partial class Window1 : Window
    {
        public Window1(string regexStr) : this()
        {
            this.FindControl<TextBox>("regexTextBox").Text = regexStr;
        }
        public Window1()
        {
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("okButton").Click += delegate
            {
                var regexStr = this.FindControl<TextBox>("regexTextBox").Text;
                if (regexStr != null)
                {
                    Close(regexStr);
                }
                else
                {
                    Close("");
                }
            };

            this.FindControl<Button>("cancelButton").Click += delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
