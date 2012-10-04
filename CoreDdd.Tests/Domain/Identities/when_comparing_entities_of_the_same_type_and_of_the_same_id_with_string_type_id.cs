using NUnit.Framework;

namespace CoreDdd.Tests.Domain.Identities
{
    [TestFixture]
    public class when_comparing_entities_of_the_same_type_and_of_the_same_id_with_string_type_id 
        : base_when_comparing_entities_of_the_same_type_and_of_the_same_id<string>
    {
        protected override string GetId()
        {
            return "string id";
        }
    }
}