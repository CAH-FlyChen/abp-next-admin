using Zion.Sales.MongoDB;
using Zion.Sales.Samples;
using Xunit;

namespace Zion.Sales.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<SalesMongoDbTestModule>
{

}
