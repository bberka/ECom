namespace ECom.Foundation.Extensions;

public static class FileExtensions
{
  public static bool IsImage(this string filePath) {
    var extension = Path.GetExtension(filePath);
    var isImage = extension switch {
      ".jpg" => true,
      ".png" => true,
      ".jpeg" => true,
      ".gif" => true,
      ".bmp" => true,
      _ => false
    };
    return isImage;
  }

  public static bool IsDirectory(this string filePath) {
    return File.GetAttributes(filePath).HasFlag(FileAttributes.Directory);
  }

  public static bool IsVideo(this string filePath) {
    var extension = Path.GetExtension(filePath);
    var isVideo = extension switch {
      ".mp4" => true,
      ".avi" => true,
      ".mkv" => true,
      ".mov" => true,
      ".wmv" => true,
      ".flv" => true,
      ".webm" => true,
      _ => false
    };
    return isVideo;
  }
}