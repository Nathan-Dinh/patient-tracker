using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTracker
{
    class Constants
    {
        //Use the file path to the patients folder within the project for the form to work
        //Formate example: C:\\dummy\\dummy\\dummy\\Patients
        public const string folderDirectory = "";

        //For textDirectiry use the same file path above 
        //Note: For the textDirectiry you need the add "\" at the path
        //Formate example: C:\\dummy\\dummy\\dummy\\Patients\
        public const string textDirectiry = @"";

        public const string regexBP = @"^BP\s\d+\/\d+$";
        public const char semiColenSeperator = ';';
        public const char seperator = '|';
    }
}
