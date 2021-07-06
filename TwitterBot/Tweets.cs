using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using System.Windows.Forms;
using Tweetinvi.Parameters;
using System.IO;
using System.Threading;

namespace TwitterBot
{
    class Tweets
    {

        public async void AddTweet(string tweet, TwitterClient client)
        {
            try
            {
                await client.Tweets.PublishTweetAsync(tweet);
                MessageBox.Show("You're tweet have been posted", "Tweet Request.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public async void AddTweetWithImg(string tweet, string img, TwitterClient client)
        {
            try
            {
                var imgLocation = File.ReadAllBytes(img);
                var uploadImg = await client.Upload.UploadTweetImageAsync(imgLocation);
                var tweetWithImg = await client.Tweets.PublishTweetAsync(new PublishTweetParameters(tweet)
                {
                    Medias = { uploadImg }
                });
                MessageBox.Show("You're tweet have been posted", "Tweet Request.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
       
        }
        public void FileTweetWithImg(int time,string location ,TwitterClient client)
        {
            try
            {
                var file = File.ReadAllLines(location);
                for(int i = 0; i <= file.Length -1; i++)
                {
                    var tweet = file[i];
                    var image = file[i + 1];
                    AddTweetWithImg(tweet, image, client);
                    Thread.Sleep(time);
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void TweetReadFromFile(int time,string location,TwitterClient client)
        {
            try
            {
                var file = File.ReadAllLines(location);
                for (int i = 0; i <= file.Length - 1; i++)
                {
                    AddTweet(file[i], client);
                    Thread.Sleep(time);
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
       
        
        public async void AddFriend(string name, TwitterClient client)
        {
            try
            {
                await client.Users.FollowUserAsync(name);
                MessageBox.Show("You followed " + name, "Follow Request.");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public async void UserSettings(string ProfileImg, string ProfileBanner, TwitterClient client)
        {
                    
            if (!String.IsNullOrEmpty(ProfileImg)) {
                try
                {
                    var ProfileImgLocation = File.ReadAllBytes(ProfileImg);
                    await  client.AccountSettings.UpdateProfileImageAsync(ProfileImgLocation);
                    MessageBox.Show("Profile Picture have been updated");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                }
            if (!String.IsNullOrEmpty(ProfileBanner)) {
                try
                {
                    var BannerImgLocation = File.ReadAllBytes(ProfileBanner);
                    await  client.AccountSettings.UpdateProfileImageAsync(BannerImgLocation);
                    MessageBox.Show("Profile Banner have been updated");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                }
        }
    }
}
