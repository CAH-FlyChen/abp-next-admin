using Zion.Sales.Samples;
using Xunit;

namespace Zion.Sales.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<SalesMongoDbTestModule>
{

}
