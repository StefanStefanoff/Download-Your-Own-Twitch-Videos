# Download-Your-Own-Twitch-Videos
Download your videos/highlights for archiving reasons

![alt text](https://github.com/StefanStefanoff/Download-Your-Own-Twitch-Videos/blob/master/TwitchDownload/bin/blobs/settings.PNG?raw=true)

All fields marked with * are mandatory.

# Getting the values:

Open your video-producer poage (https://dashboard.twitch.tv/u/{username}/content/video-producer)
open your developer console (usually F12) and refresh the page. You will see a lot of requests, but you need the one with name beginning with "video_manager?"

![alt text](https://github.com/StefanStefanoff/Download-Your-Own-Twitch-Videos/blob/master/TwitchDownload/bin/blobs/channelId.PNG?raw=true)

there is going to be more than 1, so you will want the method to be "GET" not "OPTIONS".
Your channelId will be on the plkace of the first red box (under path:)
your authorization is the second red box and looks like "OAuth asdfghjkl123qwertyuio321a1zb1z"

The max length field is not mandatory and if left empty all video lengths will be downloaded.
For the category field you can choose from "All" or only "highlights"

# The download window:

![alt text](https://github.com/StefanStefanoff/Download-Your-Own-Twitch-Videos/blob/master/TwitchDownload/bin/blobs/download.PNG?raw=true)

After you click start, if everything is OK, you will see some messages as to what is happening.
If you see a lot of "Waiting for twitch link..." do not panic - twitch sometimes takes a lot of time to generate a download link (for me the max was 10 minutes)
