using System.Collections.ObjectModel;
using ECom.Shared.DTOs.LocalizationStringDto;

namespace ECom.AdminBlazorServer.Common.Packs;

public static class Empty
{
  public static readonly ReadOnlyCollection<LocalizationStringDTO> Pack = new List<LocalizationStringDTO>() {

  }.AsReadOnly();
}