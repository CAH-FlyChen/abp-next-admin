using Zion.Product.Samples;
using Xunit;

namespace Zion.Product.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<ProductMongoDbTestModule>
{

}
