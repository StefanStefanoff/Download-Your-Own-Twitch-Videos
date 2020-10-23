using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.IO;

namespace TwitchDownload
{
    public partial class download : Form
    {
        string channelId;
        string authorization;
        string dlLocation;
        string maxLength;
        string type;
        string clientId = "DL";

        int videosCount = 0;

        private BackgroundWorker _worker = null;

        public download(string channelId, string authorization, string dlLocation, string maxLength, string type)
        {
            InitializeComponent();
            this.channelId = channelId;
            this.authorization = authorization;
            this.dlLocation = dlLocation;
            this.maxLength = maxLength;
            this.type = type;
            richTextBox1.Text = "Click start to start the download!\nHere you will see the progress.\nGenerating a download link sometimes takes a bout 2 minutes, so you will see multiple messages for download link waiting per video.";
        }

        private void dlFinishButton_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();
            this.Close();
        }

        delegate void SetTextCallback(string text);

        private void outputText(string text)
        {
                richTextBox1.Text += text + "\n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            startButton.Enabled = false;
            richTextBox1.Text = "";
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;

            int limit = 1;
            int offset = 0;
            string status = "recorded%2Crecording";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-Id", clientId);
            client.DefaultRequestHeaders.Add("authorization", authorization);


            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                while (true)
                {
                    string baseListUrl = "https://api.twitch.tv/v5/channels/" + channelId + "/video_manager" + "?limit=" + limit + "&offset=" + offset + "&status=" + status + (type == "Highlights" ? "&broadcast_type=highlight" : "");
                    var request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(baseListUrl),
                        Method = HttpMethod.Get,
                    };

                    var response = client.SendAsync(request);
                    var responseObject = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
                    var videos = responseObject["videos"];
                    
                    if (videos.Count() == 0) {
                        break;
                    }

                    offset += limit;
                    foreach (var video in videos) {
                        if (maxLength.Trim().Length > 0) {
                            if (Int32.Parse(video["length"].ToString()) > Int32.Parse(maxLength)) {
                                continue;
                            }
                        }

                        var videoId = video["_id"];
                        downloadVideoFile(video["_id"].ToString().Remove(0, 1), video["title"].ToString());
                        videosCount++;
                    }
                }
            });

            _worker.WorkerReportsProgress = true;
            _worker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            _worker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            _worker.RunWorkerAsync();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            outputText(e.UserState.ToString());
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            outputText("All done! " + videosCount + " videos downloaded!");
            timer1.Stop();
        }

        private string downloadVideoFile(string id, string title) 
        {
            string[] invalidCharacters = { "\\", "/", ":", "*", "?", "\"", "<", ">", "|", " " };
            foreach (string character in invalidCharacters)
            {
                title = title.Replace(character, "_");
            }

            _worker.ReportProgress(0, "Starting download process for " + title);
            string dlUrl = getDownloadUrl(id);
            title = title + dlUrl.Substring(dlUrl.LastIndexOf('.'));
            _worker.ReportProgress(0, "Downloading " + title);
            return DownloadFile(dlUrl, Path.Combine(dlLocation, title)).Result;
        }

        private string getDownloadUrl(string id)
        {
            _worker.ReportProgress(0, "Requesting download link...");
            requestDownloadUrl(id);
            var dlUrl = "https://api.twitch.tv/v5/vods/" + id + "/download";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-Id", clientId);
            client.DefaultRequestHeaders.Add("authorization", authorization);

            var retries = 0;
            while (true)
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(dlUrl),
                    Method = HttpMethod.Get,
                };

                var response = client.SendAsync(request);
                var responseObj = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
                if (responseObj["download_url"].ToString().Trim().Length != 0)
                {
                    return responseObj["download_url"].ToString();
                }

                _worker.ReportProgress(0, "Waiting for twitch link...");
                retries++;

                if (retries % 5 == 0) {
                    requestDownloadUrl(id);
                }
                Thread.Sleep(10000);
            }
        }

        private void requestDownloadUrl(string id)
        {
            var dlUrl = "https://api.twitch.tv/v5/vods/" + id + "/download";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-Id", clientId);
            client.DefaultRequestHeaders.Add("authorization", authorization);
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.DefaultRequestHeaders.Add("access-control-request-headers", "authorization,client-id,content-type,twitch-api-token,x-device-id,x-requested-with");
            client.DefaultRequestHeaders.Add("access-control-request-method", "GET");

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(dlUrl),
                Method = HttpMethod.Options,
            };

            var response = client.SendAsync(request).Result;
        }

        public async Task<string> DownloadFile(string url, string filePath)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-Id", clientId);
            client.DefaultRequestHeaders.Add("authorization", authorization);

            var fileInfo = new FileInfo(filePath);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var ms = await response.Content.ReadAsStreamAsync();
            var fs = File.Create(fileInfo.FullName);
            ms.Seek(0, SeekOrigin.Begin);
            ms.CopyTo(fs);
            fs.Close();
            return fileInfo.FullName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = (Int32.Parse(textBox1.Text) + 1) + "";
        }
    }
}
