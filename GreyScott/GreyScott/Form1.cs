using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyScott
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Manager manager;
        Enums.Laplacian eLaplacian;
        Enums.ColourScheme eColourScheme;
        SimulationParameters simulationParameters;
        bool on;
        int count;
        public Form1()
        {
            InitializeComponent();
        }

        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            populateComboBoxes();
            simulationParameters = new SimulationParameters();
            graphics = CreateGraphics();
            on = false;
            timer1.Enabled = on;
        }

        // Button clicks
        private void btnBegin_Click(object sender, EventArgs e)
        {
            on = !on;
            if (on)
                setUpSimulation();
            timer1.Enabled = on;
            count = 0;
            
        }

        private void btnSkipOneThousand_Click(object sender, EventArgs e)
        {
            setUpSimulation();
            manager.OneThousandCycle(eLaplacian);
        }

        private void btnFiveThousand_Click(object sender, EventArgs e)
        {
            setUpSimulation();
            manager.FiveThousandCycle(eLaplacian);
        }

        private void btnRunBatch_Click(object sender, EventArgs e)
        {
            setUpBatchSimulation();
            if (manager != null)
            {
                manager.BatchCycle(eLaplacian);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (manager != null)
            {
                if (setSaveDirectory())
                {
                    string imageName = manager.CreateImageName();
                    manager.SaveImage(imageName);
                }
                else
                {
                    MessageBox.Show("No directory specified for images to save to.\n\n Please select a directory next time.");
                }
            }
            else
                MessageBox.Show("Please begin a simulation before trying to save an image.");
        }
        // Timer tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            manager.ManagerCycle(eLaplacian);
            count++;
            lblTick.Text = count.ToString();
        }
        
        // Private methods used to do common tasks in order to reduce code duplication

        // Get values from user input and store in SimulationParameters object
        void getValues()
        {
            try
            {
                simulationParameters.FeedA = double.Parse(txtFeedA.Text);
                simulationParameters.KillB = double.Parse(txtKillB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Only numerical values supported.");
            }

            // Pull enums from our combo box
            eLaplacian = (Enums.Laplacian)cbLaplacian.SelectedValue;
            eColourScheme = (Enums.ColourScheme)cbColourScheme.SelectedValue;
            // Set the Diff A & B values
            setDiffValues(eLaplacian);
        }

        // Used to get all of the values for the batch cycle
        void getValuesForBatch()
        {
            try
            {
                simulationParameters.FeedA = double.Parse(txtStartA.Text);
                simulationParameters.KillB = double.Parse(txtStartB.Text);
                simulationParameters.EndFeedA = double.Parse(txtEndA.Text);
                simulationParameters.EndKillB = double.Parse(txtEndB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Only numerical values supported");
            }

            eLaplacian = (Enums.Laplacian)cbBatchLaplacian.SelectedValue;
            eColourScheme = (Enums.ColourScheme)cbBatchColourScheme.SelectedValue;
            setDiffValues(eLaplacian);
        }

        // Because we are using enums in combination with a factory pattern, we can simply
        // populate our combo boxes based on all of the values in our Enums class. This is
        // handy because we don't need to modify form code when adding more colour schemes
        // or laplacian functions
        void populateComboBoxes()
        {
            cbColourScheme.DataSource = Enum.GetValues(typeof(Enums.ColourScheme));
            cbLaplacian.DataSource = Enum.GetValues(typeof(Enums.Laplacian));

            cbBatchColourScheme.DataSource = Enum.GetValues(typeof(Enums.ColourScheme));
            cbBatchLaplacian.DataSource = Enum.GetValues(typeof(Enums.Laplacian));
        }

        // Pop a FolderBrowserDialog and select the directory to save the images to & store
        // in our Simulation Parameters object. Return true if user selects a folder,
        // false if not. This will help so that the program won't crash if the user doesn't
        // select a folder.
        bool setSaveDirectory()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                simulationParameters.SaveDirectory = fbd.SelectedPath + "\\";
                return true;
            }
            else
                return false;
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            graphics.Clear(SystemColors.Control);
            txtFeedA.Text = "0.025";
            txtKillB.Text = "0.056";
        }

        void setUpSimulation()
        {
            getValues();
            manager = new Manager(graphics, simulationParameters, eColourScheme);
        }

        void setUpBatchSimulation()
        {
            if (setSaveDirectory())
            {
                getValuesForBatch();
                manager = new Manager(graphics, simulationParameters, eColourScheme);
            }
            else
                MessageBox.Show("No directory selected to save to. Closing.");
        }

        void setDiffValues(Enums.Laplacian eLaplacian)
        {
            // Not very elegant way of setting the Diff A & B values...
            if (eLaplacian == Enums.Laplacian.Perpendicular)
            {
                simulationParameters.DiffA = 0.00002;
                simulationParameters.DiffB = 0.00001;
            }
            else
            {
                simulationParameters.DiffA = 1;
                simulationParameters.DiffB = 0.5;
            }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To run a batch:" + "\n"
                            + "\t 1) Select starting values for Feed A and Kill B" + "\n"
                            + "\t 2) Select ending values for Feed A and Kill B" + "\n"
                            + "\t 3) Click the 'Run Batch' button" + "\n"
                            + "\t 4) Select a directory to save your batch of images" + "\n"
                            + "\t 5) Your batch will now run until completion");
        }


    }


}
