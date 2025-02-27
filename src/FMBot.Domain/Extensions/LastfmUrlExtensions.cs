using System.Text.Encodings.Web;

namespace FMBot.Domain.Extensions;

public static class LastfmUrlExtensions
{
    public static string GetArtistUrl(string artistName)
    {
        return $"https://last.fm/music/{UrlEncoder.Default.Encode(artistName)}";
    }

    public static string GetAlbumUrl(string artistName, string albumName)
    {
        if (albumName == null)
        {
            return null;
        }

        var encodedAlbumName = UrlEncoder.Default.Encode(albumName);

        if (encodedAlbumName.Length > 400)
        {
            return null;
        }

        return $"https://last.fm/music/{UrlEncoder.Default.Encode(artistName)}/{encodedAlbumName}";
    }

    public static string GetTrackUrl(string artistName, string trackName)
    {
        var encodedTrackName = UrlEncoder.Default.Encode(trackName);

        if (encodedTrackName.Length > 400)
        {
            return null;
        }

        return $"https://last.fm/music/{UrlEncoder.Default.Encode(artistName)}/_/{encodedTrackName}";
    }

    public static string GetUserUrl(string userName, string addOn = null)
    {
        var url =  $"https://last.fm/user/{UrlEncoder.Default.Encode(userName)}";

        if (addOn != null)
        {
            url += addOn;
        }

        return url;
    }
}
