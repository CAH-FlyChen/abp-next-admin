using Zion.Product.MongoDB;
using Zion.Product.Samples;
using Xunit;

namespace Zion.Product.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<ProductMongoDbTestModule>
{

}
