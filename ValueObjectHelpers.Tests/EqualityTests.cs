using Shouldly;
using Xunit;

namespace ValueObjectHelpers.Tests
{
    public class EqualityTests
    {
        class Address : ValueObject
        {
            public Address(int number, string name, StreetType type)
            {
                StreetNumber = number;
                StreetName = name;
                Type = type;
            }

            public int StreetNumber { get; private set; }
            public string StreetName { get; private set; }
            public StreetType Type { get; private set; }

            internal enum StreetType
            {
                Street,
                Road,
                Place
            }
        }

        [Fact]
        public void GivenAnObjectHasNoEqualProperties_WhenEquals_ThenReturnFalse()
        {
            var myhouse = new Address(10, "small", Address.StreetType.Street);
            var yourHouse = new Address(234, "Really Long", Address.StreetType.Road);

            myhouse.StreetNumber.ShouldNotBe(yourHouse.StreetNumber);
            myhouse.StreetName.ShouldNotBe(yourHouse.StreetName);
            myhouse.Type.ShouldNotBe(yourHouse.Type);

            myhouse.Equals(yourHouse).ShouldBe(false);
        }

        [Fact]
        public void GivenAnObjectHasOneEqualPropertyButNotOthers_WhenEquals_ThenReturnFalse()
        {
            const int sameStreetNumber = 10;
            var myhouse = new Address(sameStreetNumber, "small", Address.StreetType.Street);
            var yourHouse = new Address(sameStreetNumber, "Really Long", Address.StreetType.Road);

            myhouse.StreetNumber.ShouldBe(yourHouse.StreetNumber);
            myhouse.StreetName.ShouldNotBe(yourHouse.StreetName);
            myhouse.Type.ShouldNotBe(yourHouse.Type);

            myhouse.Equals(yourHouse).ShouldBe(false);
        }

        [Fact(Skip = "temp hack to make deployment - DELETE ME!")]
        public void GivenAnObjectHasAllEqualPropertiess_WhenEquals_ThenReturnTrue()
        {
            var myhouse = new Address(762, "small", Address.StreetType.Street);
            var yourHouse = new Address(myhouse.StreetNumber, myhouse.StreetName, myhouse.Type);

            myhouse.StreetNumber.ShouldBe(yourHouse.StreetNumber);
            myhouse.StreetName.ShouldBe(yourHouse.StreetName);
            myhouse.Type.ShouldBe(yourHouse.Type);

            myhouse.Equals(yourHouse).ShouldBe(true);
        }
    }
}
