using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTracker
{
    class TextFileManipulator
    {
        //This function basically overwrites the previous content of the file 
        public static void saveFile(Client newClient, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            lines[0] = newClient.clientInformatoinFormat();
            File.WriteAllLines(filePath, lines);
        }

        //This function create a file directory path with the current information from the user inputes
        public static string FilePath(MaterialTextBox txtPatientName, MaterialTextBox txtNoteID)
        {
            return $"{Constants.textDirectiry}{txtNoteID.Text}-{txtPatientName.Text}";
        }
    }
}
