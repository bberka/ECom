using ECom.Shared.DTOs.LocalizationStringDto;
using System.Collections.ObjectModel;

namespace ECom.AdminBlazor.Client.Common.Packs;

public static class Empty
{
  public static readonly ReadOnlyCollection<LocalizationStringDTO> Pack = new List<LocalizationStringDTO>() {

  }.AsReadOnly();
}