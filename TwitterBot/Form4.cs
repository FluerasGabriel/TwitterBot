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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var friend = textBox1.Text.ToString();
            Tweets obj = new Tweets();
            Tweeter key = new Tweeter();
            var client = new TwitterClient(key.Oauth_consumer_key, key.Oauth_consumer_secret, key.Oauth_token, key.Oauth_token_secret);
            obj.AddFriend(friend,client);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Form4 form4 = new Form4();
            form1.Show();
            form4.Close();
        }
    }
}
