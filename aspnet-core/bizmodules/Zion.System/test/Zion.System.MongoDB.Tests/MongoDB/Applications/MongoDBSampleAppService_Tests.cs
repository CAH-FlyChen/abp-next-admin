using Zion.System.MongoDB;
using Zion.System.Samples;
using Xunit;

namespace Zion.System.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<SystemMongoDbTestModule>
{

}
