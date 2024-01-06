using ECom.Foundation.Entities;
using ECom.Foundation.Static;

namespace ECom.Foundation.Abstract.Services;

public interface IContentService
{
  List<Content> GetContents(Guid id);

  Result<Content> GetContent(Guid id, CultureType cultureType);
  Content GetContentEnsureNotNull(Guid id, CultureType cultureType);

  Result AddOrUpdateContent(Guid id, CultureType cultureType, string value);

  Result<Guid> AddNewContent(CultureType cultureType, string value);

  Result AddOrUpdateContents(Guid id, Dictionary<CultureType, string> languageAndValuesDictionary);

  bool ContentExists(Guid id, CultureType cultureType);
}