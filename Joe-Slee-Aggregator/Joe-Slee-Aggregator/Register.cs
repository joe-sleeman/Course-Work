using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joe_Slee_Aggregator
{
    public partial class Register : Form
    {
        List<Topic> allTopics;
        Form passedForm;
        DBManager dbMan;
        public Register(Form passedForm)
        {
            InitializeComponent();
            this.passedForm = passedForm;
        }
        private void Register_Load(object sender, EventArgs e)
        {
            dbMan = new DBManager();
            allTopics = dbMan.GetAllTopics();

            var items = checkedboxTopics.Items;
            foreach (Topic t in allTopics)
                items.Add(t.TopicName);
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedboxTopics.CheckedIndices)
            {
                checkedboxLikedTopics.Items.Add(checkedboxTopics.Items[i]);
            }

            foreach (var item in checkedboxTopics.CheckedItems.OfType<string>().ToList())
            {
                checkedboxTopics.Items.Remove(item);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedboxLikedTopics.CheckedIndices)
            {
                checkedboxTopics.Items.Add(checkedboxLikedTopics.Items[i]);
            }

            foreach (var item in checkedboxLikedTopics.CheckedItems.OfType<string>().ToList())
            {
                checkedboxLikedTopics.Items.Remove(item);
            }
        }

        private void btnAddNewTopic_Click(object sender, EventArgs e)
        {
            string topicToAdd = txtNewTopic.Text;
            if (topicToAdd.Contains(" "))
                MessageBox.Show("Only one word topics supported.");
            else
            {
                if (topicToAdd.Length > 0)
                {
                    if (dbMan.CheckIfTopicExists(topicToAdd))
                        MessageBox.Show("Topic already exists in database.");
                    else
                    {
                        checkedboxLikedTopics.Items.Add(topicToAdd);
                        txtNewTopic.Clear();
                        dbMan.AddTopic(topicToAdd);
                    }
                }
                else
                    MessageBox.Show("Please enter a topic to add.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            passedForm.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string passwordMatch = txtPasswordMatch.Text;

            if (username.Length < 3)
                MessageBox.Show("Username must be at least 3 characters long.", "Bad Username");
            else
            {
                if (dbMan.CheckIfUserExists(username))
                    MessageBox.Show("Username already taken. \n Please choose a different username.", "Bad Username");
                else
                {
                    if (password == passwordMatch)
                    {
                        dbMan.AddUser(username, password);
                        foreach (var topic in checkedboxLikedTopics.Items.OfType<string>().ToList())
                            dbMan.AddUserTopic(username, topic.ToString(), true);

                        // Notify of successful registration.
                        MessageBox.Show("Thank you for registering. \n Please log in to get started.", "Successful Registration");
                        this.Close();
                        passedForm.Show();
                    }
                    else
                        MessageBox.Show("Passwords do not match.", "Bad Password.");
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "GenerateSeeds")
            {
                AggregatorDBContext aggDb = new AggregatorDBContext();
                dbMan.SeedDatabase(aggDb);
                MessageBox.Show("Seeds Generated - Please only run this once.", "Seeds Generated");
            }
            else
            {
                MessageBox.Show("1) Select a username and password\n" +
                                "2) Select some topics from the list, or create your own using the text box\n" +
                                "3) Make sure your passwords are matching and click \"Register\"\n" +
                                "4) Log in to the system", "Help");
            }
        }
    }
}
