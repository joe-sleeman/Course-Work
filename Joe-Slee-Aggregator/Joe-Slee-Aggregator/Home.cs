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
    public partial class Home : Form
    {
        DBManager dbMan;
        BingItemGenerator generator;
        User currUser;
        Random random;
        int skip;
        const int skipIncrement = 10;
        string currTopic;
        string currSearchParam;
        public Home(string username)
        {
            InitializeComponent();
            dbMan = new DBManager();
            generator = new BingItemGenerator();
            currUser = dbMan.GetUserFromUsername(username);

        }
        private void Home_Load(object sender, EventArgs e)
        {
            populateComboBoxes();
            populateCheckedBoxes();
            random = new Random();
            webBrowser1.ScriptErrorsSuppressed = true;
            picboxSpinner.Hide();
            picboxTick.Hide();
        }
        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (currUser.TopicList.Any())
            {
                skip = 0;
                currSearchParam = cbSearchType.SelectedItem.ToString();
                currTopic = dbMan.GetRandomTopic(currUser, random);
                generator.PerformSearch(currTopic, currSearchParam, rtArticles, currUser.DislikedTopicList, skip);
                lblCurrTopic.Text = currTopic;
            }
            else
                MessageBox.Show("No likes for current user. Impossible to get a random topic.");
        }

        private void btnNextTen_Click(object sender, EventArgs e)
        {
            skip += skipIncrement;
            generator.PerformSearch(currTopic, currSearchParam, rtArticles, currUser.DislikedTopicList, skip);
        }

        private void populateComboBoxes()
        {
            List<String> searchValues = new List<String>();
            searchValues.Add("News");
            searchValues.Add("Web");
            cbSearchType.DataSource = searchValues;
        }

        private void rtArticles_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            picboxSpinner.Show();
            picboxTick.Hide();
            webBrowser1.Navigate(e.LinkText);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            picboxSpinner.Hide();
            picboxTick.Show();
        }

        private void populateCheckedBoxes()
        {
            var likedTopicItems = checkedListLikes.Items;
            var dislikedTopicItems = checkedListDislikes.Items;
            var allTopicItems = checkedListAllTopics.Items;

            foreach (Topic t in currUser.TopicList)
                likedTopicItems.Add(t.TopicName);

            foreach (Topic t in currUser.DislikedTopicList)
                dislikedTopicItems.Add(t.TopicName);

            var allTopics = dbMan.GetAllTopics();

            foreach (Topic t in allTopics)
            {
                if (!currUser.TopicList.Contains(t) && !currUser.DislikedTopicList.Contains(t))
                    allTopicItems.Add(t.TopicName);
            }
        }

        private void btnNewTopic_Click(object sender, EventArgs e)
        {
            string topicToAdd = txtNewTopic.Text;
            if (topicToAdd.Contains(" "))
                MessageBox.Show("Ony one word topics supported.", "Topic not supported");
            else
            {
                if (topicToAdd.Length > 0)
                {
                    if (dbMan.CheckIfTopicExists(topicToAdd))
                        MessageBox.Show("Topic already exists in database.");
                    else
                    {
                        checkedListAllTopics.Items.Add(topicToAdd);
                        txtNewTopic.Clear();
                        dbMan.AddTopic(topicToAdd);
                    }
                }
                else
                    MessageBox.Show("Please enter a topic to add.");
            }

        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListAllTopics.CheckedIndices)
                checkedListLikes.Items.Add(checkedListAllTopics.Items[i]);

            foreach (var item in checkedListAllTopics.CheckedItems.OfType<string>().ToList())
            {
                checkedListAllTopics.Items.Remove(item);
                currUser.TopicList.Add(new Topic { TopicName = item }); // Hacky last minute fix
                dbMan.AddUserTopic(currUser.Username, item, true);
            }
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListAllTopics.CheckedIndices)
                checkedListDislikes.Items.Add(checkedListAllTopics.Items[i]);

            foreach (var item in checkedListAllTopics.CheckedItems.OfType<string>().ToList())
            {
                checkedListAllTopics.Items.Remove(item);
                currUser.DislikedTopicList.Add(new Topic { TopicName = item });
                dbMan.AddUserTopic(currUser.Username, item, false);
            }
        }

        private void btnRemoveDislikes_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListDislikes.CheckedIndices)
                checkedListAllTopics.Items.Add(checkedListDislikes.Items[i]);

            foreach (var item in checkedListDislikes.CheckedItems.OfType<string>().ToList())
            {
                checkedListDislikes.Items.Remove(item);
                currUser.DislikedTopicList.Remove(new Topic { TopicName = item });  // DOesn't work
                dbMan.RemoveUserTopic(currUser, item);
            }
        }

        private void btnRemoveLikes_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListLikes.CheckedIndices)
                checkedListAllTopics.Items.Add(checkedListLikes.Items[i]);

            foreach (var item in checkedListLikes.CheckedItems.OfType<string>().ToList())
            {
                checkedListLikes.Items.Remove(item);
                currUser.TopicList.Remove(new Topic { TopicName = item });  // Doesn't work should have followed spec
                dbMan.RemoveUserTopic(currUser, item);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
