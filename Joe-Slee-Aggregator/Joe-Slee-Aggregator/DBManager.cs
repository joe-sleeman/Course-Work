using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joe_Slee_Aggregator
{
    // DBManager will manage all DB related things - Any time we interact with our database,
    // we will have to go through an instance of DBManager.
    public class DBManager
    {
        private SqlConnection bitdevConnection; // Connection to bitdev - not used currently we are using localhost.
        private AggregatorDBContext aggDB = new AggregatorDBContext();  // The DBContext we will be interacting with.
        public DBManager()
        {

        }

        // This method will pull back all topics available from the database.
        public List<Topic> GetAllTopics()
        {
            List<Topic> allTopics = new List<Topic>();
            var topics = from t in aggDB.Topics
                            select t;
            foreach (Topic t in topics)
                allTopics.Add(t);

            return allTopics;
        }

        // This method will get all disliked topics for a passed in User instance.
        // It will then populate the User instances Disliked Topic List with said topics.
        public void GetAllDisLikedTopicsForUser(User user)
        {
            var userTopics = from t in aggDB.Topics
                             join ut in aggDB.UserTopics on t.TopicID equals ut.TopicID         // Join the intermediate linking table
                             where ut.UserID == user.UserID && ut.Liked == false                // Where the user ID is that of the passed in user
                             select t;                                                          // and the "Liked" field is false.

            // Instantiate our list.
            user.DislikedTopicList = new List<Topic>();

            // Populate DislikedTopicList
            foreach (Topic t in userTopics)
                user.DislikedTopicList.Add(t);
        }

        // This method is the same as the above method, but it will instead populate the LikedTopicList.
        public void GetAllLikedTopicsForUser(User user)
        {
            var userTopics = from t in aggDB.Topics
                             join ut in aggDB.UserTopics on t.TopicID equals ut.TopicID
                             where ut.UserID == user.UserID && ut.Liked == true             // True this time.
                             select t;

            user.TopicList = new List<Topic>();

            foreach (Topic t in userTopics)
                user.TopicList.Add(t);
        }

        public void RemoveUserTopic(User user, string topicname)
        {
            int topicID = GetTopicIDFromTopicName(topicname);
            int userID = GetUserIDFromUsername(user.Username);

            var userTopic = from ut in aggDB.UserTopics
                            where ut.TopicID == topicID && ut.UserID == userID
                            select ut;

            aggDB.UserTopics.Remove(userTopic.FirstOrDefault());
            aggDB.SaveChanges();
        }


        // This method will return a string which is the topic name of a random topic within the passed
        // in user's TopicList.
        public string GetRandomTopic(User user, Random random)
        {
            int max = user.TopicList.Count();   // Max value is the length of our TopicList.
            int min = 0;                        // Min value will be 0.
            int rNum = random.Next(min, max);   // Get random value between min & max.

            string returnString = user.TopicList[rNum].TopicName;   // Instantiate & populate returnString
            return returnString;                                    // Return the string.
        }

        // This method will check if a user exists based on a passed in username.
        // Helpful when trying to add a new user to the application - we want to first checkif a user with the 
        // requested username exists, and if it does, we will not allow another user with the same name to be
        // created. This helps ensure that all usernames are unique within the application.
        public bool CheckIfUserExists(string username)
        {
            bool userExists = false;                        // Instantiate & start as false.
            var user = from u in aggDB.Users
                       where u.Username.Equals(username)    // Where the username = passed in username
                       select u;

            if (user.Any())                                 // If any users exist in the user collection
                userExists = true;                          // The user already exists.

            return userExists;                              // Return user.
        }

        // This method will return a user based on a username.
        // This is helpful when we know the user's username, but we don't have a corresponding object 
        // instantiated that represents the user.
        public User GetUserFromUsername(string username)
        {
            User returnUser = new User();                   // Instantiate a new user object.
            var user = from u in aggDB.Users
                        where u.Username.Equals(username)   // Use LINQ to grab the user from our DB Context.
                        select u;

            // Now let's populate the user's fields.
            foreach (User u in user)
            {
                returnUser.Username = u.Username;
                returnUser.Password = u.Password;       // Dunno if need to put this here as already logged in?
                returnUser.UserID = u.UserID;
            }
            GetAllLikedTopicsForUser(returnUser);       // Populate the user's LikedTopics list.
            GetAllDisLikedTopicsForUser(returnUser);    // Populate the user's DislikedTopics list.
            return returnUser;                          // Now return our fully instantiated user object.
        }

        // Check if a user already likes a topic
        public bool CheckIfUserAlreadyLikesTopic(string username, string topicname)
        {
            bool exists = false;
            User user = GetUserFromUsername(username);
            var topic = from t in user.TopicList
                        where t.TopicName.Equals(topicname)
                        select t;

            if (topic.Any())
                exists = true;

            return exists;
        }

        // Check if a user already dislikes a topic
        public bool CheckIfUserAlreadyDislikesTopic(string username, string topicname)
        {
            bool exists = false;
            User user = GetUserFromUsername(username);
            var topic = from t in user.DislikedTopicList
                        where t.TopicName.Equals(topicname)
                        select t;

            if (topic.Any())
                exists = true;

            return exists;
        }


        // This method will return a boolean based on whether or not there is a topic in the database
        // with the same TopicName as the passed in string. This is helpful because we want to try and
        // avoid adding duplicate records to our Topics table.
        public bool CheckIfTopicExists(string topicname)
        {
            bool topicExists = false;
            var topic = from t in aggDB.Topics
                        where t.TopicName.Equals(topicname)
                        select t;

            if (topic.Any())
                topicExists = true;

            return topicExists;
        }

        // This method will return a boolean based on whether or not a user has succeeded at providing
        // correct credentials. This is helpful because we need to be able to authenticate users when
        // they log in to the application.
        public bool CheckUsernameAndPassword(string username, string password)
        {
            bool correct = false;
            var user = from u in aggDB.Users
                       // Username & password must both match in our DB Context.
                       where u.Username.Equals(username) && u.Password.Equals(password) 
                       select u;
            if (user.Any())         // If we have any results.
                correct = true;     // The user must have gotten their credentials right.

            return correct;
        }


        // DO I EVEN NEED THESE??????
        public int GetUserIDFromUsername(string username)
        {
            var userID = from u in aggDB.Users
                         where u.Username.Equals(username)
                         select u.UserID;

            return userID.FirstOrDefault();
        }

        public int GetTopicIDFromTopicName(string topicName)
        {
            var topicID = from t in aggDB.Topics
                          where t.TopicName.Equals(topicName)
                          select t.TopicID;

            return topicID.FirstOrDefault();
        }


        // Seed the database.

        public void SeedDatabase(AggregatorDBContext aggregatorDB)
        {
            aggregatorDB = new AggregatorDBContext();

            var Users = new List<User>
            {
                new User { Username = "Joe", Password = "password" },
                new User { Username = "Whitney", Password = "password" },
                new User { Username = "Yolanda", Password = "password" },
                new User { Username = "Zachary", Password = "password" }
            };

            foreach (User u in Users)
                aggregatorDB.Users.Add(u);
            aggregatorDB.SaveChanges();

            var Topics = new List<Topic>
            {
                new Topic { TopicName = "Skateboarding" },
                new Topic { TopicName = "Programming" },
                new Topic { TopicName = "Surfing" },
                new Topic { TopicName = "Memes" },
                new Topic { TopicName = "History" },
                new Topic { TopicName = "Politics" },
                new Topic { TopicName = "Environment" },
                new Topic { TopicName = "Books" },
                new Topic { TopicName = "Dairy" },
                new Topic { TopicName = "Agriculture" },
                new Topic { TopicName = "Cricket" },
                new Topic { TopicName = "Sport" },
                new Topic { TopicName = "Extreme-Sports" },
                new Topic { TopicName = "Homework" },
                new Topic { TopicName = "Ebooks" },
                new Topic { TopicName = "Authors"},
                new Topic { TopicName = "Arguements" },
                new Topic { TopicName = "Dairy" },
                new Topic { TopicName = "Farming"}
            };

            foreach (Topic t in Topics)
                aggregatorDB.Topics.Add(t);
            aggregatorDB.SaveChanges();

            var UserTopics = new List<UserTopic>
            {
                AddTopicToUser("Joe", "Skateboarding", true),
                AddTopicToUser("Joe", "Programming", true),
                AddTopicToUser("Whitney", "Surfing", true),
                AddTopicToUser("Whitney", "Skateboarding", true),
                AddTopicToUser("Whitney", "Extreme-Sports", true),
                AddTopicToUser("Whitney", "Memes", true),
                AddTopicToUser("Whitney", "Homework", true),
                AddTopicToUser("Whitney", "Arguements", false),
                AddTopicToUser("Yolanda", "Politics", true),
                AddTopicToUser("Yolanda", "Environment", true),
                AddTopicToUser("Yolanda", "Books", true),
                AddTopicToUser("Yolanda", "Ebooks", false),
                AddTopicToUser("Yolanda", "Authors", true),
                AddTopicToUser("Zachary", "Dairy", true),
                AddTopicToUser("Zachary", "Farming", true),
                AddTopicToUser("Zachary", "Agriculture", true),
                AddTopicToUser("Zachary", "Cricket", false)
            };

            foreach (UserTopic ut in UserTopics)
                aggregatorDB.UserTopics.Add(ut);
            aggregatorDB.SaveChanges();
        }

        // This method will return an instance of UserTopic that will be used when a user has
        // liked or disliked a topic. We pass in username and topicname because that is easier
        // and more intuitive than trying to figure out the ID of these objects.
        public UserTopic AddTopicToUser(string username, string topicname, bool liked)
        {
            int userID = GetUserIDFromUsername(username);       // Get the user's ID
            int topicID = GetTopicIDFromTopicName(topicname);   // Get the topic's ID

            // Generate a new instance of UserTopic class, with the values passed in & worked out above.
            UserTopic userTopic = new UserTopic { UserID = userID, TopicID = topicID, Liked = liked };
            return userTopic;   // return the fully instantiated object.
        }

        // This method will use the above created instance of UserTopic, and actually save it to our
        // database.
        public void AddUserTopic(string username, string topicname, bool liked)
        {
            UserTopic userTopic = AddTopicToUser(username, topicname, liked);   // Generate User Topic.
            aggDB.UserTopics.Add(userTopic);                                    // Add to DB.
            aggDB.SaveChanges();                                                // Save.
        }

        // This method will add a topic to our database.
        public void AddTopic(string topicname)
        {
            aggDB.Topics.Add(new Topic { TopicName = topicname });  // Generate Topic & add to DB.
            aggDB.SaveChanges();                                    // Save changes.
        }

        // This method will add a used to the database based on passed in username & password.
        public void AddUser(string username, string password)
        {
            aggDB.Users.Add(new User { Username = username, Password = password }); // Generate & add user.
            aggDB.SaveChanges();                                                    // Save.
        }

    }

}
