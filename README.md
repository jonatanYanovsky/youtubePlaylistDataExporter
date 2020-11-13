Youtube Playlist Data Exporter

export your playlists to CSV format as backups incase videos get deleted


---


how to build:

import into IntelliJ

Build > Build Solution

Go to the build directory ../youtubePlaylistExporter/bin

Create a directory named youtubePlaylistDataExporter

copy the /Release folder into it

create a shortcut to youtubePlaylistExporter.exe in /Release (not in the /app.publish directory!)

done.


---


dependencies:

CsvHelper

YoutubeExplode


---


issues:

Excel will not be able to read UTF-8 automatically, so Japanese and other unicode characters will not render correctly

fix: 
open the .csv in notepad++

alternatively, in Excel, go to Data > (Get External Data) > From Text > select UTF-8 and click Finish. Note that text will no longer be bound to cells


also see: https://stackoverflow.com/questions/6002256/is-it-possible-to-force-excel-recognize-utf-8-csv-files-automatically





