using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NzbDrone.Core.Download.Clients.Spomix
{
    public class SpomixResult<T>
        where T : new()
    {
        public bool Result { get; set; }

        public string Errid { get; set; }

        public T Data { get; set; }
    }

    public class SpomixConfigResult
    {
        public SpomixConfig Settings { get; set; }
    }

    public class SpomixConfig
    {
        public string DownloadLocation { get; set; }
        public bool CreateAlbumFolder { get; set; }
        public bool CreateSingleFolder { get; set; }
    }

    public class SpomixConnect
    {
        public SpomixUser CurrentUser { get; set; }
    }

    public class SpomixUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("can_stream_hq")]
        public bool CanStreamHq { get; set; }
        [JsonProperty("can_stream_lossless")]
        public bool CanStreamLossless { get; set; }
    }

    public class SpomixAddResult
    {
        public List<string> Url { get; set; }
        public string Bitrate { get; set; }
        public List<SpomixQueueItem> Obj { get; set; }
    }

    public class SpomixQueue
    {
        public Dictionary<string, SpomixQueueItem> Queue { get; set; }
        public List<string> QueueOrder { get; set; }
        public SpomixQueueItem Current { get; set; }
    }

    public class SpomixQueueItem
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Cover { get; set; }
        public bool Explicit { get; set; }
        public int Size { get; set; }
        public string ExtrasPath { get; set; }
        public int Downloaded { get; set; }
        public int Failed { get; set; }
        public List<object> Errors { get; set; }
        public int Progress { get; set; }
        public List<SpomixFile> Files { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string Bitrate { get; set; }
        public string Uuid { get; set; }
        public string Status { get; set; }
    }

    public class SpomixSearchResponse
    {
        public IList<SpomixGwAlbum> Data { get; set; }
        public int Total { get; set; }
    }

    public class ExplicitAlbumContent
    {
        [JsonProperty("EXPLICIT_LYRICS_STATUS")]
        public int ExplicitLyrics { get; set; }

        [JsonProperty("EXPLICIT_COVER_STATUS")]
        public int ExplicitCover { get; set; }
    }

    public class SpomixGwAlbum
    {
        [JsonProperty("ALB_ID")]
        public string AlbumId { get; set; }
        [JsonProperty("ALB_TITLE")]
        public string AlbumTitle { get; set; }
        [JsonProperty("ALB_PICTURE")]
        public string AlbumPicture { get; set; }
        public bool Available { get; set; }
        [JsonProperty("ART_ID")]
        public string ArtistId { get; set; }
        [JsonProperty("ART_NAME")]
        public string ArtistName { get; set; }
        [JsonProperty("EXPLICIT_ALBUM_CONTENT")]
        public ExplicitAlbumContent ExplicitAlbumContent { get; set; }

        // These two are string not DateTime since sometimes Spomix provides invalid values (like 0000-00-00)
        [JsonProperty("PHYSICAL_RELEASE_DATE")]
        public string PhysicalReleaseDate { get; set; }
        [JsonProperty("DIGITAL_RELEASE_DATE")]
        public string DigitalReleaseDate { get; set; }

        public string Type { get; set; }
        [JsonProperty("ARTIST_IS_DUMMY")]
        public bool ArtistIsDummy { get; set; }
        [JsonProperty("NUMBER_TRACK")]
        public string TrackCount { get; set; }
        [JsonProperty("DURATION")]
        public int DurationInSeconds { get; set; }

        public string Version { get; set; }
        public string Link { get; set; }

        public bool Explicit => ExplicitAlbumContent?.ExplicitLyrics == 1 ||
                                ExplicitAlbumContent?.ExplicitLyrics == 4 ||
                                ExplicitAlbumContent?.ExplicitCover == 1;
    }

    public class SpomixAlbumUrl
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("ext")]
        public string Ext { get; set; }
    }

    public class SpomixFileData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }
    }

    public class SpomixFile
    {
        [JsonProperty("albumURLs")]
        public List<SpomixAlbumUrl> AlbumUrls { get; set; }

        [JsonProperty("albumPath")]
        public string AlbumPath { get; set; }

        [JsonProperty("albumFilename")]
        public string AlbumFilename { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("data")]
        public SpomixFileData Data { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
