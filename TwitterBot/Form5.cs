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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var profile = textBox1.Text.ToString();
            var banner = textBox2.Text.ToString();
            Tweets obj = new Tweets();
            Tweeter key = new Tweeter();
            var client = new TwitterClient(key.Oauth_consumer_key, key.Oauth_consumer_secret, key.Oauth_token, key.Oauth_token_secret);
            obj.UserSettings(profile, banner, client);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form5 form5 = new Form5();
            form1.Show();
            form5.Close();
        }
    }
}
