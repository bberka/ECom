using ECom.Foundation.Static;

namespace ECom.Business.Services;

public class ContentService : IContentService
{
  private readonly IUnitOfWork _unitOfWork;

  public ContentService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Content> GetContents(Guid id) {
    return _unitOfWork.Contents.Where(x => x.Id == id).ToList();
  }

  public Result<Content> GetContent(Guid id, CultureType cultureType) {
    var content = _unitOfWork.Contents.FirstOrDefault(x => x.Id == id && x.Culture == cultureType);
    if (content == null) {
      return DomResults.x_is_not_found("content");
    }

    return content;
  }

  public Content GetContentEnsureNotNull(Guid id, CultureType cultureType) {
    var content = GetContent(id, cultureType).Value;
    if (content == null) {
      throw new Exception($"Content with id {id} and cultureType {cultureType} not found");
    }

    return content;
  }

  public Result AddOrUpdateContent(Guid id, CultureType cultureType, string value) {
    var existing = _unitOfWork.Contents.FirstOrDefault(x => x.Id == id && x.Culture == cultureType);
    if (existing is not null) {
      existing.Value = value;
      _unitOfWork.Contents.Update(existing);
      var dbResult = _unitOfWork.Save();
      if (!dbResult) {
        return DomResults.db_internal_error(nameof(AddOrUpdateContent));
      }

      return DomResults.x_is_updated_successfully("content");
    }
    else {
      var content = new Content {
        Id = id,
        Culture = cultureType,
        Value = value
      };
      _unitOfWork.Contents.Add(content);
      var dbResult = _unitOfWork.Save();
      if (!dbResult) {
        return DomResults.db_internal_error(nameof(AddOrUpdateContent));
      }

      return DomResults.x_is_added_successfully("content");
    }
  }

  public Result<Guid> AddNewContent(CultureType cultureType, string value) {
    var content = new Content {
      Id = Guid.NewGuid(),
      Culture = cultureType,
      Value = value
    };
    _unitOfWork.Contents.Add(content);
    var dbResult = _unitOfWork.Save();
    if (!dbResult) {
      return DomResults.db_internal_error(nameof(AddNewContent));
    }

    return content.Id;
  }

  public Result AddOrUpdateContents(Guid id, Dictionary<CultureType, string> languageAndValuesDictionary) {
    foreach (var (language, value) in languageAndValuesDictionary) {
      var existing = _unitOfWork.Contents.FirstOrDefault(x => x.Id == id && x.Culture == language);
      if (existing is not null) {
        existing.Value = value;
        _unitOfWork.Contents.Update(existing);
      }
      else {
        var content = new Content {
          Id = id,
          Culture = language,
          Value = value
        };
        _unitOfWork.Contents.Add(content);
      }
    }

    var dbResult = _unitOfWork.Save();
    if (!dbResult) {
      return DomResults.db_internal_error(nameof(AddOrUpdateContents));
    }

    return DomResults.x_is_updated_successfully("contents");
  }

  public bool ContentExists(Guid id, CultureType cultureType) {
    return _unitOfWork.Contents.Any(x => x.Id == id && x.Culture == cultureType);
  }
}