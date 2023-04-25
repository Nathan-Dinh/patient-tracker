using MaterialSkin;
using MaterialSkin.Controls;

namespace N.DAssignment3
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Size = new Size(1450, 1000);


            EventManager formDesign = new EventManager();
            this.Controls.Add(formDesign.PnlEncounterNotesDesign());
        }

    }
}