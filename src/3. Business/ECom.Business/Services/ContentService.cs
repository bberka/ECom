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

  public Result<Content> GetContent(Guid id, Language language) {
    var content = _unitOfWork.Contents.FirstOrDefault(x => x.Id == id && x.Culture == language);
    if (content == null) {
      return DefResult.NotFound("content");
    }

    return content;
  }

  public Content GetContentEnsureNotNull(Guid id, Language language) {
    var content = GetContent(id, language).Data;
    if (content == null) {
      throw new Exception($"Content with id {id} and language {language} not found");
    }

    return content;
  }

  public Result AddOrUpdateContent(Guid id, Language language, string value) {
    var existing = _unitOfWork.Contents.FirstOrDefault(x => x.Id == id && x.Culture == language);
    if (existing is not null) {
      existing.Value = value;
      _unitOfWork.Contents.Update(existing);
      var dbResult = _unitOfWork.Save();
      if (!dbResult) {
        return DefResult.DbInternalError("update_content");
      }
    }
    else {
      var content = new Content {
        Id = id,
        Culture = language,
        Value = value
      };
      _unitOfWork.Contents.Add(content);
      var dbResult = _unitOfWork.Save();
      if (!dbResult) {
        return DefResult.DbInternalError("add_content");
      }
    }

    return DefResult.OkAddedOrUpdated("content");
  }

  public Result<Guid> AddNewContent(Language language, string value) {
    var content = new Content {
      Id = Guid.NewGuid(),
      Culture = language,
      Value = value
    };
    _unitOfWork.Contents.Add(content);
    var dbResult = _unitOfWork.Save();
    if (!dbResult) {
      return DefResult.DbInternalError("add_content");
    }

    return content.Id;
  }

  public Result AddOrUpdateContents(Guid id, Dictionary<Language, string> languageAndValuesDictionary) {
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
      return DefResult.DbInternalError("add_or_update_contents");
    }

    return DefResult.OkAddedOrUpdated("contents");
  }

  public bool ContentExists(Guid id, Language language) {
    return _unitOfWork.Contents.Any(x => x.Id == id && x.Culture == language);
  }
}