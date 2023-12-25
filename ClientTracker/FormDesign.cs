using MaterialSkin.Controls;

namespace ClientTracker
{
    public class FormDesign
    {
        #region
        //Label
        protected static MaterialLabel lblNoteID = new MaterialLabel();
        protected static MaterialLabel lblPatientName = new MaterialLabel();
        protected static MaterialLabel lblPatientDateOfBirth = new MaterialLabel();
        protected static MaterialLabel lblPatientProblem = new MaterialLabel();
        protected static MaterialLabel lblNote = new MaterialLabel();
        protected static MaterialLabel lblProblems = new MaterialLabel();
        protected static MaterialLabel lblBPMeasurements = new MaterialLabel();
        protected static MaterialLabel lblStatus = new MaterialLabel();
        //TextBox
        protected static MaterialTextBox txtNoteID = new MaterialTextBox();
        protected static MaterialTextBox txtPatientName = new MaterialTextBox();
        protected static MaterialTextBox txtPatientProblem = new MaterialTextBox();
        protected static MaterialMultiLineTextBox txtPatientNotes = new MaterialMultiLineTextBox();
        //Button
        protected static MaterialButton btnAdd = new MaterialButton();
        protected static MaterialButton btnRemove = new MaterialButton();
        protected static MaterialButton btnAddNote = new MaterialButton();
        protected static MaterialButton btnUpdateNote = new MaterialButton();
        protected static MaterialButton btnDeleteNote = new MaterialButton();
        protected static MaterialButton btnStartNewNote = new MaterialButton();
        protected static MaterialButton btnUpdateName = new MaterialButton();
        protected static MaterialButton btnDeleteProblem = new MaterialButton();
        //ListBox
        protected static MaterialListBox lstCilent = new MaterialListBox();
        protected static MaterialListBox lstProblems = new MaterialListBox();
        protected static MaterialListBox lstBPMeasuurements = new MaterialListBox();
        // DateTimePicker
        protected static DateTimePicker dtpPatientDateOfBirth = new DateTimePicker();
        //Panel
        protected Panel pnlEncounterNotes = new Panel();
        #endregion

        public Panel PnlEncounterNotesDesign()
        {
            //This checks whether the file exist if not 
            if (!Directory.Exists(Constants.folderDirectory))
            {
                Directory.CreateDirectory(Constants.folderDirectory);
            }
            EventManager newEvent = new EventManager();

            const string font = "GenericSansSerif";
            const int fontSize = 16;

            pnlEncounterNotes.AutoSize = true;
            pnlEncounterNotes.Location = new Point(30, 70);

            InitializeLabels();
            InitializeTextBoxes();
            InitializeDateTimePicker();
            InitializeButtons();
            InitializeListBox();

            void InitializeLabels()
            {
                //Label NoteID
                lblNoteID.Location = new Point(350, 100);
                lblNoteID.AutoSize = true;
                lblNoteID.Font = new Font(font, fontSize);
                lblNoteID.Text = "Note ID:";
                pnlEncounterNotes.Controls.Add(lblNoteID);
                //Label PatientName
                lblPatientName.Location = new Point(350, 170);
                lblPatientName.AutoSize = true;
                lblPatientName.Font = new Font(font, fontSize);
                lblPatientName.Text = "Patient Name:";
                pnlEncounterNotes.Controls.Add(lblPatientName);
                //label PatientDateofBirth
                lblPatientDateOfBirth.Location = new Point(350, 240);
                lblPatientDateOfBirth.AutoSize = true;
                lblPatientDateOfBirth.Font = new Font(font, fontSize);
                lblPatientDateOfBirth.Text = "Date of Birth:";
                pnlEncounterNotes.Controls.Add(lblPatientDateOfBirth);
                //Label patientProblem
                lblPatientProblem.Location = new Point(350, 310);
                lblPatientProblem.AutoSize = true;
                lblPatientProblem.Font = new Font(font, fontSize);
                lblPatientProblem.Text = "New Problem:";
                pnlEncounterNotes.Controls.Add(lblPatientProblem);
                //Label Notes
                lblNote.Location = new Point(350, 425);
                lblNote.AutoSize = true;
                lblNote.Font = new Font(font, fontSize);
                lblNote.Text = "Notes:";
                pnlEncounterNotes.Controls.Add(lblNote);
                //Label patientProblem
                lblProblems.Location = new Point(900, 60);
                lblProblems.AutoSize = true;
                lblProblems.Font = new Font(font, fontSize);
                lblProblems.Text = "Problems:";
                pnlEncounterNotes.Controls.Add(lblProblems);
                //Label BP Measurements
                lblBPMeasurements.Location = new Point(1150, 60);
                lblBPMeasurements.AutoSize = true;
                lblBPMeasurements.Font = new Font(font, fontSize);
                lblBPMeasurements.Text = "BP Measurements:";
                pnlEncounterNotes.Controls.Add(lblBPMeasurements);
                //Label Status
                lblStatus.Location = new Point(5, 10);
                lblStatus.AutoSize = true;
                lblStatus.Font = new Font(font, fontSize);
                lblStatus.Text = "Status:  Awaiting Note";
                pnlEncounterNotes.Controls.Add(lblStatus);
            }
            void InitializeTextBoxes()
            {
                //TextBox NoteID
                txtNoteID.Location = new Point(500, 101);
                txtNoteID.Size = new Size(200, 0);
                txtNoteID.ReadOnly = true;
                pnlEncounterNotes.Controls.Add(txtNoteID);
                //TextBox PatientName
                txtPatientName.Location = new Point(500, 170);
                txtPatientName.Size = new Size(275, 0);
                txtPatientName.ReadOnly = true;
                pnlEncounterNotes.Controls.Add(txtPatientName);
                //TextBox PatientProblem
                txtPatientProblem.Location = new Point(500, 310);
                txtPatientProblem.Size = new Size(250, 0);
                txtPatientProblem.ReadOnly = true;
                pnlEncounterNotes.Controls.Add(txtPatientProblem);
                //TextBox Patient Notes 
                txtPatientNotes.Location = new Point(350, 450);
                txtPatientNotes.Size = new Size(1000, 350);
                txtPatientNotes.Multiline = true;
                txtPatientNotes.WordWrap = true;
                txtPatientNotes.ReadOnly = true;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                txtPatientNotes.TextChanged += newEvent.txtNote_TextChanged;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                pnlEncounterNotes.Controls.Add(txtPatientNotes);
            }
            void InitializeDateTimePicker()
            {
                //DateTimePicker PatientDateOfBirth
                dtpPatientDateOfBirth.Location = new Point(500, 240);
                dtpPatientDateOfBirth.Size = new Size(200, 240);
                dtpPatientDateOfBirth.Enabled = false;
                pnlEncounterNotes.Controls.Add(dtpPatientDateOfBirth);
            }
            void InitializeButtons()
            {
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                //Button NoteID
                btnAdd.Location = new Point(765, 311);
                btnAdd.AutoSize = true;
                btnAdd.Text = "Add";
                btnAdd.Font = new Font(font, fontSize);
                btnAdd.Enabled = false;

                btnAdd.Click += newEvent.btnAdd_Click;

                pnlEncounterNotes.Controls.Add(btnAdd);
                //Button PatientName
                btnAddNote.Location = new Point(350, 815);
                btnAddNote.AutoSize = true;
                btnAddNote.Text = "Add note";
                btnAddNote.Font = new Font(font, fontSize);

                btnAddNote.Click += newEvent.btnAddNote_Click;

                pnlEncounterNotes.Controls.Add(btnAddNote);
                //Button Update Note
                btnUpdateNote.Location = new Point(475, 815);
                btnUpdateNote.AutoSize = true;
                btnUpdateNote.Text = "Update Note";
                btnUpdateNote.Font = new Font(font, fontSize);
                btnUpdateNote.Enabled = false;

                btnUpdateNote.Click += newEvent.btnUpdateNote_Click;

                pnlEncounterNotes.Controls.Add(btnUpdateNote);
                //Button PatientProblem
                btnDeleteNote.Location = new Point(630, 815);
                btnDeleteNote.AutoSize = true;
                btnDeleteNote.Text = "Delete Note";
                btnDeleteNote.Font = new Font(font, fontSize);
                btnDeleteNote.Enabled = false;
                btnDeleteNote.Click += newEvent.btnDeleteNote_Click;
                pnlEncounterNotes.Controls.Add(btnDeleteNote);
                //Button StartNewNote
                btnStartNewNote.Location = new Point(50, 50);
                btnStartNewNote.AutoSize = true;
                btnStartNewNote.Text = "Start New Note";
                btnStartNewNote.Font = new Font(font, fontSize);
                btnStartNewNote.Enabled = true;
                btnStartNewNote.Click += newEvent.btnStartNewNote_Click;
                pnlEncounterNotes.Controls.Add(btnStartNewNote);
                //Button Update Name
                btnUpdateName.Location = new Point(790, 170);
                btnUpdateName.AutoSize = true;
                btnUpdateName.Text = "Update";
                btnUpdateName.Font = new Font(font, fontSize);
                btnUpdateName.Enabled = false;
                btnUpdateName.Click += newEvent.btnUpdateName_Click;
                pnlEncounterNotes.Controls.Add(btnUpdateName);
                //Button Delete Problem
                btnDeleteProblem.Location = new Point(900, 360);
                btnDeleteProblem.AutoSize = true;
                btnDeleteProblem.Text = "Delete Problem";
                btnDeleteProblem.Font = new Font(font, fontSize);
                btnDeleteProblem.Click += newEvent.btnDeleteProblem_Click;
                btnDeleteProblem.Enabled = false;
                pnlEncounterNotes.Controls.Add(btnDeleteProblem);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            }
            void InitializeListBox()
            {
                //ListBox Client
                lstCilent.Location = new Point(50, 100);
                lstCilent.Size = new Size(250, 800);
                lstCilent.SelectedIndexChanged += newEvent.lstCilent_SelectedIndexChanged;
                pnlEncounterNotes.Controls.Add(lstCilent);
                lstClientUpdate();
                //ListBox Problems
                lstProblems.Location = new Point(900, 100);
                lstProblems.Size = new Size(200, 250);
                pnlEncounterNotes.Controls.Add(lstProblems);
                //ListBox BP Measuurements 
                lstBPMeasuurements.Location = new Point(1150, 100);
                lstBPMeasuurements.Size = new Size(200, 250);
                pnlEncounterNotes.Controls.Add(lstBPMeasuurements);
            }
            return pnlEncounterNotes;
        }

        //Loops through the directory folder updating the client listbox
        protected void lstClientUpdate()
        {
            lstCilent.Items.Clear();
            var filePathArray = Directory.GetFiles(Constants.folderDirectory);
            foreach (var fileName in filePathArray)
            {
                lstCilent.AddItem(Path.GetFileName(fileName));
            }
        }

        //Clears the users inputes from the form whenever this fucntion is called
        protected void ClearInputs()
        {
            txtNoteID.Clear();
            txtPatientName.Clear();
            txtPatientNotes.Clear();
            txtPatientProblem.Clear();
            lstProblems.Items.Clear();
            lstBPMeasuurements.Items.Clear();
        }
        protected string AwaitingNoteMode()
        {
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = false;
            btnStartNewNote.Enabled = true;
            txtPatientName.ReadOnly = true;
            dtpPatientDateOfBirth.Enabled = false;
            txtPatientProblem.ReadOnly = true;
            txtPatientNotes.ReadOnly = true;
            lstCilent.Enabled = true;
            btnUpdateName.Enabled = false;
            btnDeleteProblem.Enabled = false;
            lblStatus.Text = "Status: Awaiting Note";
            return "AwaitingNoteMode";
        }
        protected string AddMode()
        {
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            btnAddNote.Enabled = true;
            btnUpdateNote.Enabled = false;
            btnDeleteNote.Enabled = true;
            btnStartNewNote.Enabled = false;
            txtPatientName.ReadOnly = false;
            dtpPatientDateOfBirth.Enabled = true;
            txtPatientProblem.ReadOnly = false;
            txtPatientNotes.ReadOnly = false;
            lstCilent.Enabled = false;
            btnUpdateName.Enabled = false;
            btnDeleteProblem.Enabled = true;
            lblStatus.Text = "Status: Add";
            return "AddMode";
        }
        protected string EditMode()
        {
            btnAdd.Enabled = true;
            btnRemove.Enabled = false;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = true;
            btnDeleteNote.Enabled = true;
            btnStartNewNote.Enabled = true;
            txtPatientName.ReadOnly = true;
            dtpPatientDateOfBirth.Enabled = true;
            txtPatientProblem.ReadOnly = false;
            txtPatientNotes.ReadOnly = false;
            btnUpdateName.Enabled = true;
            btnDeleteProblem.Enabled = true;
            btnUpdateNote.Text = "Update Note";
            lblStatus.Text = "Status: Edit";
            return "EditMode";
        }
        protected string UpdateNameMode()
        {
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
            btnAddNote.Enabled = false;
            btnUpdateNote.Enabled = true;
            btnDeleteNote.Enabled = false;
            btnUpdateName.Enabled = false;
            btnStartNewNote.Enabled = false;
            txtPatientName.ReadOnly = false;
            dtpPatientDateOfBirth.Enabled = false;
            txtPatientProblem.ReadOnly = true;
            txtPatientNotes.ReadOnly = true;
            btnDeleteProblem.Enabled = false;
            btnUpdateNote.Text = "Update Name";
            lblStatus.Text = "Status: Update Name";
            return "UpdateNameMode";
        }
    }
}
