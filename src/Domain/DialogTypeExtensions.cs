namespace ECom.Domain;

public static class DialogTypeExtensions
{
  public static bool IsSimpleDialog(this SimpleDialogType dialogType) {
    return dialogType switch {
      SimpleDialogType.Delete => true,
      SimpleDialogType.Recover => true,
      SimpleDialogType.Enable => true,
      SimpleDialogType.Disable => true,
      _ => false
    };
  }

  public static bool ShowOkButton(this SimpleDialogType dialogType) {
    var showOkButton = dialogType switch {
      SimpleDialogType.Delete => true,
      SimpleDialogType.Disable => true,
      SimpleDialogType.Enable => true,
      //SimpleDialogType.Add => true,
      //SimpleDialogType.Update => true,
      //SimpleDialogType.Edit => true,
      SimpleDialogType.Recover => true,
      _ => false
    };
    return showOkButton;
  }

  public static bool ShowCancelButton(this SimpleDialogType dialogType) {
    var showCancelButton = dialogType switch {
      SimpleDialogType.Delete => true,
      SimpleDialogType.Disable => true,
      SimpleDialogType.Enable => true,
      //SimpleDialogType.Add => true,
      //SimpleDialogType.Update => true,
      //SimpleDialogType.Edit => true,
      SimpleDialogType.Recover => true,
      _ => false
    };
    return showCancelButton;
  }
}