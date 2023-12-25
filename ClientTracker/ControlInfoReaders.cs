using MaterialSkin.Controls;
using System.Text;
using System.Text.RegularExpressions;
using Validation;

namespace ClientTracker
{
    class ControlInfoReaders
    {
        //This loops through the note Textbox looking specifically for BP of the patient
        public static string TextBoxBPFilter(MaterialMultiLineTextBox content)
        {
            var bpLine = new StringBuilder();
            var lineArray = content.Lines;
            var bpLineArray = Array.FindAll(lineArray, x => Regex.IsMatch(x, Constants.regexBP, RegexOptions.IgnoreCase));
            foreach (var bp in bpLineArray)
            {
                bpLine.Append(bp.Trim().ToUpper()).Append(";");
            }
            return bpLine.ToString();
        }
        //This loops through the lines of note Textbox
        public static string TextBoxNoteFilter(MaterialMultiLineTextBox content)
        {
            var notes = new StringBuilder();
            foreach (var line in content.Lines)
            {
                notes.Append(line.Trim()).Append(";");
            }
            return notes.ToString();
        }
        //This loops through the problem Listbox
        public static string ListBoxContentReader(MaterialListBox content)
        {
            var problems = new StringBuilder();

            foreach (var item in content.Items)
            {
                problems.Append(item.Text).Append(";");
            }
            return problems.ToString();
        }
    }
}
