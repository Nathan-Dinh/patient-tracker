using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace N.DAssignment3
{
    class Client
    {
        public string NoteID { get;  set; }
        private string PatientName { get; set; }
        private string PatientDate { get; set; }
        private string PatientProblem { get; set; }
        private string PatientBP { get; set; }
        private string PatientNotes { get; set; }
        public Client(string ID, string patientName, DateTime dateofbirth, string problem, string patientBP,string patientNotes) 
        {
            var output = string.Empty;

            if (string.IsNullOrEmpty(ID) || !int.TryParse(ID, out int result))
            {
                output += "ID Is note valid\n";
            }

            if (!ValidationUtilities.IsNameValid(patientName))
            {
                output += "Patient Name is in the wrong formate\n";
            }

            if (dateofbirth >= DateTime.Now)
            {
                output += "Patient date of birth is not valid\n";
            }

            if (string.IsNullOrEmpty(patientNotes)) 
            {
                output += "Note is required\n";
            }

            if(string.IsNullOrEmpty(output)) 
            {
                NoteID= ID;
                PatientName= patientName;
                PatientDate = dateofbirth.ToString("yyyy-MM-dd");
                PatientProblem = problem;
                PatientBP = patientBP;
                PatientNotes = patientNotes;
            }
            else
            {
                throw new ArgumentException(output);
            }
        }

        public string clientInformatoinFormat()
        {
            return $"{NoteID}|{PatientName}|{PatientDate}|{PatientProblem}|{PatientBP}|{PatientNotes}";
        }
    }
}
