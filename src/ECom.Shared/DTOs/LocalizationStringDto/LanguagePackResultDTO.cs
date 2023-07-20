using System.Collections.ObjectModel;

namespace ECom.Shared.DTOs.LocalizationStringDto;

public class LanguagePackResultDTO
{
  public LanguagePackResultDTO(ReadOnlyDictionary<LanguageType, ReadOnlyCollection<LocalizationStringDTO>> dictionary) {
    Packs = dictionary;
  }

  public LanguagePackResultDTO() {
  }

  public IReadOnlyDictionary<LanguageType, ReadOnlyCollection<LocalizationStringDTO>> Packs { get; }

  public void Deconstruct(out IReadOnlyDictionary<LanguageType, ReadOnlyCollection<LocalizationStringDTO>> packs) {
    packs = Packs;
  }
}