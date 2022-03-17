using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Text.RegularExpressions;

namespace RegexApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string regex = "";
        string input = "";
        string output = "";
        public string Regex
        {
            get => regex;
            set
            {
                if (value != null)
                {
                    regex = value;
                }
            }
        }

        public string Output
        {
            get => output;
            set
            {
                if (Regex != "")
                {
                    this.RaiseAndSetIfChanged(ref output, value);
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref output, "Regex not set!");
                }
            }
        }

        public string Input
        {
            get => input;
            set
            {
                Output = "";
                if (Regex != "")
                {
                    Regex rgx = new Regex(Regex);
                    foreach (Match match in rgx.Matches(value))
                    {
                        Output += match.Value + "\n";
                    }
                    if (Output == "")
                    {
                        Output = "No matches!";
                    }
                }
                this.RaiseAndSetIfChanged(ref input, value);
            }
        }
    }
}