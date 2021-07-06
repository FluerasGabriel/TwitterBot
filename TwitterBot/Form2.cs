using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tweetinvi;

namespace TwitterBot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tweet = textBox1.Text.ToString();
            Tweets obj = new Tweets();
            var key = new Tweeter();
            var client = new TwitterClient(key.Oauth_consumer_key, key.Oauth_consumer_secret, key.Oauth_token, key.Oauth_token_secret);
            obj.AddTweet(tweet, client);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            form1.Show();
            form2.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var file = @"D:\TwitterBot\" + textBox3.Text.ToString() + ".txt";
            Tweets obj = new Tweets();
            var key = new Tweeter();
            var client = new TwitterClient(key.Oauth_consumer_key, key.Oauth_consumer_secret, key.Oauth_token, key.Oauth_token_secret);
            if (checkBox1.Checked)
            {
                obj.TweetReadFromFile(5000, file, client);
            }
           else if (checkBox2.Checked)
            {
                obj.TweetReadFromFile(10000, file, client);
            }
            else if(checkBox3.Checked){
                obj.TweetReadFromFile(15000, file, client);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
               
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }
    }
}
