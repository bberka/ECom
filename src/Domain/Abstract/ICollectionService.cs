using ECom.Domain.DTOs.CollectionDTOs;

namespace ECom.Domain.Abstract
{
    public interface ICollectionService
    {
        public Result CreateCollection(AddCollectionRequest model);
        public ResultData<Collection> GetCollection(int collectionId);
        public ResultData<Collection> GetCollection(int userId,int collectionId);
        public Result UpdateCollection(UpdateCollectionRequest model);
        public Result DeleteCollection(int userId,int collectionId);
        public List<Collection> GetCollections(int userId);
        public ResultData<List<CollectionProduct>> GetCollectionProducts(int userId,int collectionId,ushort page,string culture = ConstantMgr.DefaultCulture); 
    }
}
