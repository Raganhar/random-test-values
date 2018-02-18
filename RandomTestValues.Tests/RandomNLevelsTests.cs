using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomNLevelsTests
    {
        [TestMethod]
        public void RandomUriWillReturnANewUriObjectWithARandomEndpoint()
        {
            var uri1 = RandomValue.Uri();
            var uri2 = RandomValue.Uri();

            Assert.AreNotEqual(uri1, uri2);
        }

        [TestMethod]
        public void N_Level_Test()
        {
            var m = RandomValue.Object<Bob>();
            m.Lol.Should().NotBeNull();
        }

        [TestMethod]
        public void N0_Level_Test()
        {
            var m = RandomValue.Object<Bob>(new RandomValueSettings { NestedLevels = 0 });
            m.Lol.Should().BeNull();
        }

        [TestMethod]
        public void N1_Level_Test()
        {
            var m = RandomValue.Object<Bob>(new RandomValueSettings { NestedLevels = 1 });
            m.Lol.Bobsilol.Should().BeNull();
        }

        [TestMethod]
        public void Numeric_zero_Level_Test()
        {
            var m = RandomValue.Object<Bob>(new RandomValueSettings { NumericZero = true});
            m.Age.Should().Be(0);
        }
    }

    public class Bob
    {
        public int Age { get; set; }
        public Lol Lol { get; set; }
    }

    public class Lol
    {
        public string Name { get; set; }
        public Bobsilol Bobsilol { get; set; }
    }

    public class Bobsilol
    {
        public int Stuff { get; set; }
    }
}

