namespace ECom.Domain;

public static class DialogTypeExtensions
{
  public static bool IsSimpleDialog(this SimpleDialogType dialogType) {
    return dialogType switch {
      SimpleDialogType.delete => true,
      SimpleDialogType.recover => true,
      SimpleDialogType.enable => true,
      SimpleDialogType.disable => true,
      _ => false
    };
  }

  public static bool ShowOkButton(this SimpleDialogType dialogType) {
    var showOkButton = dialogType switch {
      SimpleDialogType.delete => true,
      SimpleDialogType.disable => true,
      SimpleDialogType.enable => true,
      //SimpleDialogType.Add => true,
      //SimpleDialogType.Update => true,
      //SimpleDialogType.Edit => true,
      SimpleDialogType.recover => true,
      _ => false
    };
    return showOkButton;
  }

  public static bool ShowCancelButton(this SimpleDialogType dialogType) {
    var showCancelButton = dialogType switch {
      SimpleDialogType.delete => true,
      SimpleDialogType.disable => true,
      SimpleDialogType.enable => true,
      //SimpleDialogType.Add => true,
      //SimpleDialogType.Update => true,
      //SimpleDialogType.Edit => true,
      SimpleDialogType.recover => true,
      _ => false
    };
    return showCancelButton;
  }
}