using System;
using System.Collections.Specialized;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace VKAudio
{
    public partial class MainForm : Form
    {
        int uid;
        List<object> arr;
        List<Song> songs;
        string response;
        Queue<string> artistQueue = new Queue<string>(),
                      titleQueue = new Queue<string>(),
                      urlQueue = new Queue<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку Retrieve audio
        /// </summary>
        private void Get_Click(object sender, EventArgs e)
        {
            Data.Rows.Clear();

            if (UserId.Text == "")
            {
                MessageBox.Show("No user ID provided", "Error");
                return;
            }

            try
            {
                response = int.TryParse(UserId.Text, out uid) ? Api.AudioGet(uid) : Api.AudioGet(UserId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect user ID", "Error");
                return;
            }

            Download.Enabled = DownloadAll.Enabled = false;
            songs = new List<Song>();

            JObject obj = JObject.Parse(response);
            string firstKey = obj.Properties().Select(p => p.Name).FirstOrDefault();
            if (firstKey == "error")
            {
                MessageBox.Show("Unable to retrieve audio due to privacy settings", "Error");
                return;
            }

            arr = obj["response"].ToObject<List<object>>();
            arr.RemoveAt(0);
            label2.Visible = true;
            Count.Visible = true;
            int count = 0;

            foreach (dynamic json in arr)
            {
                Dictionary<dynamic, dynamic> song = JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(json.ToString());
                string artist = song["artist"],
                       title = song["title"];
                if (!song.ContainsKey("url")) { richTextBox1.Text += song["artist"]; continue; }
                string url = song["url"];
                long duration = song["duration"];
                songs.Add(new Song(artist, title, duration, url));
                Data.Rows.Add(artist, title, DurationConvert(duration));
                count++;
            }
            Count.Text = count.ToString();
            Status.Text = "Audio retrieved";
            Download.Enabled = DownloadAll.Enabled = true;
        }

        /// <summary>
        /// Нажатие на Enter в текстбоксе User ID
        /// </summary>
        /// <param name="e">Нажатая клавиша</param>
        private void UserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Get_Click(sender, e);
            }
        }

        /// <summary>
        /// Конвертер из секунд в минуты и секунды
        /// </summary>
        /// <param name="duration">Секунды из объека audio</param>
        /// <returns>Строчка mm:ss</returns>
        string DurationConvert(long duration)
        {
            string mins, secs;
            mins = (duration / 60).ToString();
            secs = (duration % 60).ToString("D2");
            return mins + ":" + secs;
        }

        /// <summary>
        /// Нажатие на кнопку Browse...
        /// </summary>
        private void Browse_Click(object sender, EventArgs e)
        {
            if (browser.ShowDialog() == DialogResult.OK)
            {
                Directory.Text = browser.SelectedPath + @"\";
            }
        }

        /// <summary>
        /// Нажатие на кнопку Download selected
        /// </summary>
        private void Download_Click(object sender, EventArgs e)
        {
            artistQueue = new Queue<string>();
            titleQueue = new Queue<string>();
            urlQueue = new Queue<string>();
            if (Data.Rows.Count == 0 || Data.SelectedRows == null)
            {
                MessageBox.Show("No audio selected", "Error");
                return;
            }
            if (Directory.Text == null || !System.IO.Directory.Exists(Directory.Text))
            {
                MessageBox.Show("Download directory is not specified or is invalid", "Error");
                Browse_Click(sender, e);
                if (Directory.Text == null || Directory.Text == @"\" || !System.IO.Directory.Exists(Directory.Text)) return;
            }
            if (!Directory.Text.EndsWith(@"\"))
            {
                Directory.Text += @"\";
            }
            List<int> indices = new List<int>();
            foreach (DataGridViewRow row in Data.SelectedRows)
            {
                indices.Add(row.Index);
            }

            foreach(int i in indices)
            {
                artistQueue.Enqueue(songs[i].Artist);
                titleQueue.Enqueue(songs[i].Title);
                urlQueue.Enqueue(songs[i].Url);
            }

            Download.Enabled = DownloadAll.Enabled = false;
            while (urlQueue.Count != 0)
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                string url = urlQueue.Dequeue(),
                       artist = artistQueue.Dequeue(),
                       title = titleQueue.Dequeue(),
                       filename = Directory.Text + artist + " - " + title + ".mp3";
                Status.Text = string.Format("Downloading {0} - {1}", artist, title);
                client.DownloadFileAsync(new Uri(url), filename);
                return;
            }
        }

        /// <summary>
        /// нажатие на Download All
        /// </summary>
        private void DownloadAll_Click(object sender, EventArgs e)
        {
            artistQueue = new Queue<string>();
            titleQueue = new Queue<string>();
            urlQueue = new Queue<string>();
            if (Data.Rows.Count == 0)
            {
                MessageBox.Show("No audio available", "Error");
                return;
            }
            if (Directory.Text == null || !System.IO.Directory.Exists(Directory.Text))
            {
                MessageBox.Show("Download directory is not specified or is invalid", "Error");
                Browse_Click(sender, e);
                if (Directory.Text == null || Directory.Text == @"\" || !System.IO.Directory.Exists(Directory.Text)) return;
            }
            if (!Directory.Text.EndsWith(@"\"))
            {
                Directory.Text += @"\";
            }
            for(int i = 0; i < Data.Rows.Count; i++)
            {
                artistQueue.Enqueue(songs[i].Artist);
                titleQueue.Enqueue(songs[i].Title);
                urlQueue.Enqueue(songs[i].Url);
            }
            Download.Enabled = DownloadAll.Enabled = false;
            while (urlQueue.Count != 0)
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                string url = urlQueue.Dequeue(),
                       artist = artistQueue.Dequeue(),
                       title = titleQueue.Dequeue(),
                       filename = Directory.Text + artist + " - " + title + ".mp3";
                Status.Text = string.Format("Downloading {0} - {1}", artist, title);
                client.DownloadFileAsync(new Uri(url), filename);
                return;
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percents = bytesIn / totalBytes * 100;
            Progress.Value = int.Parse(Math.Truncate(percents).ToString());
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (urlQueue.Count != 0)
            {
                string url = urlQueue.Dequeue(),
                       artist = artistQueue.Dequeue(),
                       title = titleQueue.Dequeue(),
                       filename = Directory.Text + artist + " - " + title + ".mp3";
                Status.Text = string.Format("Downloading {0} - {1}", artist, title);
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), filename);
                return;
            }
            else
            {
                Status.Text = "Download completed";
                Download.Enabled = DownloadAll.Enabled = true;
                Progress.Value = 0;
            }
        }
    }

    struct Song
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public string Url { get; set; }
        public Song(string artist, string title, long duration, string url)
        {
            Artist = artist;
            Title = title;
            Duration = duration;
            Url = url;
        }
    }

    static class Http
    {
        public static string Post(string uri, NameValueCollection pairs)
        {
            byte[] response = null;
            using (WebClient client = new WebClient())
            {
                response = client.UploadValues(uri, pairs);
            }
            return System.Text.Encoding.UTF8.GetString(response);
        }

        public static void Download()
        {

        }
    }

    static class Api
    {
        static string accessToken = "70299a93b47684f8a7f14c700d59e372dc7964c65897761805043c0c5e4da5c3560c472505e1b00af676f";
        public static string AudioGet(int userId)
        {
            string response = Http.Post("https://api.vk.com/method/audio.get",
                new NameValueCollection() { { "owner_id", userId.ToString() },
                    { "access_token", accessToken } });
            return response;
        }
        public static string AudioGet(string userId)
        {
            string response = Http.Post("https://api.vk.com/method/audio.get",
                new NameValueCollection() { { "owner_id", UsersGet(userId).ToString() },
                    { "access_token", accessToken } });
            return response;
        }
        static long UsersGet(string userId)
        {
            string response = Http.Post("https://api.vk.com/method/users.get",
                new NameValueCollection() { { "user_ids", userId },
                    { "access_token", accessToken } });
            Dictionary<dynamic, dynamic> us = JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(response);
            return us["response"][0]["uid"];
        }
    }
}
