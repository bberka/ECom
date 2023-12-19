using ECom.Foundation.Entities;
using ECom.Foundation.Enum;

namespace ECom.Foundation.Abstract.Services;

public interface IContentService
{
  List<Content> GetContents(Guid id);

  Result<Content> GetContent(Guid id, Language language);
  Content GetContentEnsureNotNull(Guid id, Language language);

  Result AddOrUpdateContent(Guid id, Language language, string value);

  Result<Guid> AddNewContent(Language language, string value);

  Result AddOrUpdateContents(Guid id, Dictionary<Language, string> languageAndValuesDictionary);

  bool ContentExists(Guid id, Language language);
}