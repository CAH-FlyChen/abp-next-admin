using Zion.System.Samples;
using Xunit;

namespace Zion.System.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<SystemMongoDbTestModule>
{

}
