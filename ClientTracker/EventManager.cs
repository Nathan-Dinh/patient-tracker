using MaterialSkin;

namespace ClientTracker
{
    public class EventManager : FormDesign
    {
        Client? newClient;
        //This tracks the current mode of the form
        string state = string.Empty;
        //This saves the old file path for when the user is in the process of updating the name
        string oldFilePath = string.Empty;
        IdGenerater newID = new IdGenerater();

        //Add problem from Text Box Problem to List Box Porblem
        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPatientProblem.Text))
            {
                lstProblems.AddItem(txtPatientProblem.Text);
                txtPatientProblem.Clear();
            }
            else
            {
                MessageBox.Show("No problem to add");
            }
        }
        public void btnStartNewNote_Click(object sender, EventArgs e)
        {
            AddMode();
            ClearInputs();
            //Generates the new note ID from the 
            txtNoteID.Text = newID.IDGenerator(lstCilent).ToString();
        }
        public void btnAddNote_Click(object sender, EventArgs e)
        {
            var listOfProblems = ControlInfoReaders.ListBoxContentReader(lstProblems);
            var patientBP = ControlInfoReaders.TextBoxBPFilter(txtPatientNotes);
            var patientNotes = ControlInfoReaders.TextBoxNoteFilter(txtPatientNotes);
            try
            {
                newClient = new Client(txtNoteID.Text, txtPatientName.Text, dtpPatientDateOfBirth.Value, listOfProblems, patientBP, patientNotes);
                //Creates the filePath of the note
                var filePath = TextFileManipulator.FilePath(txtPatientName, txtNoteID);

                if (!File.Exists(filePath))
                {
                    state = AwaitingNoteMode();
                    using StreamWriter streamWriter = File.AppendText(filePath);
                    streamWriter.WriteLine(newClient.clientInformatoinFormat());
                    ClearInputs();
                    lstClientUpdate();
                }
                else MessageBox.Show("File already exist");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void btnUpdateNote_Click(object sender, EventArgs e)
        {
            var listOfProblems = ControlInfoReaders.ListBoxContentReader(lstProblems);
            var patientBP = ControlInfoReaders.TextBoxBPFilter(txtPatientNotes);
            var patientNotes = ControlInfoReaders.TextBoxNoteFilter(txtPatientNotes);
            try
            {
                newClient = new Client(txtNoteID.Text, txtPatientName.Text, dtpPatientDateOfBirth.Value, listOfProblems, patientBP, patientNotes);
                var filePath = TextFileManipulator.FilePath(txtPatientName, txtNoteID);
                //This checks what the state of the form is in
                if (state == "UpdateNameMode")
                {
                    state = EditMode();
                    //This moves the current path of the file to the new one hence the use of the old file path
                    File.Move(oldFilePath, filePath);
                    //Saves the client infomration to the file that was just moved
                    TextFileManipulator.saveFile(newClient, filePath);
                    lstClientUpdate();
                    MessageBox.Show("Name Succsefully Update");
                }
                else
                {
                    state = EditMode();
                    TextFileManipulator.saveFile(newClient, filePath);
                    MessageBox.Show("Note Succsefully Update");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void btnDeleteNote_Click(object sender, EventArgs e)
        {
            var filePath = TextFileManipulator.FilePath(txtPatientName, txtNoteID);

            if (File.Exists(filePath))
            {
                //Deletes the file by using the file directory 
                File.Delete(filePath);
                ClearInputs();
                lstClientUpdate();
                AwaitingNoteMode();
            }
            else //If the user is in the process of creating a client note but chooses not to this would trigger
            {
                ClearInputs();
                AwaitingNoteMode();
            }
        }
        public void btnUpdateName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPatientName.Text))
            {
                oldFilePath = $"{Constants.textDirectiry}{txtNoteID.Text}-{txtPatientName.Text}";
                state = UpdateNameMode();
            }
            else MessageBox.Show("There is no name to update");
        }
        public void btnDeleteProblem_Click(object sender, EventArgs e)
        {
            try
            {
                lstProblems.Items.RemoveAt(lstProblems.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No problem was selected");
            }
        }
        public void txtNote_TextChanged(object sender, EventArgs e)
        {
            lstBPMeasuurements.Items.Clear();
            var bpText = ControlInfoReaders.TextBoxBPFilter(txtPatientNotes);
            //This just splits the string up even more 
            string[] bpValue = bpText.Split(Constants.semiColenSeperator);
            lstBPMeasuurements.AddItems(bpValue);
        }
        public void lstCilent_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            state = EditMode();
            ClearInputs();
            var count = 0;
            var filePath = Constants.textDirectiry + selectedItem.Text;
            //Read the text file that found using the file path that was created
            var fileTextInformation = File.ReadAllText(filePath);
            //Splites the text file up by | storing it in a string array
            string[] outerStringArray = fileTextInformation.Split(Constants.seperator);
            foreach (string str in outerStringArray)
            {
                //Sees if there is any ; 
                int colenCount = str.Count(c => c == Constants.semiColenSeperator);
                //This just splits the string up even more 
                string[] innerStringArray = str.Split(Constants.semiColenSeperator);

                //This is where we check if there was any ; in the string
                if (colenCount == 0)
                {
                    switch (count)
                    {

                        case 0://Text Box Note ID
                            txtNoteID.Text = str;
                            break;
                        case 1://Text Box Patient Name
                            txtPatientName.Text = str;
                            break;
                        case 2://Text Box Patient Date of Birth
                            dtpPatientDateOfBirth.Text = str;
                            break;
                    }
                    count++;
                }
                else
                {
                    //If there was any ; loop through the inner array
                    foreach (string str2 in innerStringArray)
                    {
                        var newString = str2.Replace(Constants.semiColenSeperator, ' ').Trim();
                        switch (count)
                        {
                            case 3://List Box Patient Problems
                                if (!string.IsNullOrEmpty(str2))
                                {
                                    lstProblems.AddItem(str2);
                                }
                                break;
                            case 4://List Box BP 
                                if (!string.IsNullOrEmpty(str2))
                                {
                                    lstBPMeasuurements.AddItem(newString);
                                }
                                break;
                            case 5:// Multi Line Text Box Patient Note
                                txtPatientNotes.AppendText(newString + Environment.NewLine);
                                break;
                        }
                    }
                    count++;
                }
            }
        }
    }
}
