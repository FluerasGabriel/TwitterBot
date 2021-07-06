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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tweet = textBox1.Text.ToString();
            var location = textBox2.Text.ToString();
            Tweets obj = new Tweets();
            var key = new Tweeter();
            var client = new TwitterClient(key.Oauth_consumer_key, key.Oauth_consumer_secret, key.Oauth_token, key.Oauth_token_secret);
            obj.AddTweetWithImg(tweet, location, client);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form3 form3 = new Form3();
            form1.Show();
            form3.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            var file = @"D:\TwitterBot\" + textBox3.Text.ToString() + ".txt";
            Tweets obj = new Tweets();
            var key = new Tweeter();
            var client = new TwitterClient(key.Oauth_consumer_key, key.Oauth_consumer_secret, key.Oauth_token, key.Oauth_token_secret);
            if (checkBox1.Checked)
            {
                obj.FileTweetWithImg(5000, file, client);
            }
            else if (checkBox2.Checked)
            {
                obj.FileTweetWithImg(10000, file, client);
            }
            else if (checkBox3.Checked)
            {
                obj.FileTweetWithImg(15000, file, client);
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

        private void Form3_Load(object sender, EventArgs e)
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
