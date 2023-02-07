using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface ICollectionService
    {
        public Result CreateCollection(CreateCollectionRequestModel model);
        public ResultData<Collection> GetCollection(int collectionId);
        public ResultData<Collection> GetCollection(int userId,int collectionId);
        public Result UpdateCollection(UpdateCollectionRequestModel model);
        public Result DeleteCollection(int userId,int collectionId);
        public List<Collection> GetCollections(int userId);
        public ResultData<List<CollectionProduct>> GetCollectionProducts(int userId,int collectionId,ushort page,string culture = ConstantMgr.DefaultCulture); 
    }
}
