using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Vending_machine;

namespace Vending_machine
{
    public class Tests
    {
        [Fact]
        public void testCola()
        {   
            cola product = new cola();
            product.setProperties();
            bool passed = false;
            if ("Cola" == product.name && 12 == product.price && "drink" == product.usageType)
            {
                passed = true;
            }
            Assert.True(passed);
        }
        [Fact]
        public void testChips()
        {
            chips product = new chips();
            product.setProperties();
            bool passed = false;
            if ("chips" == product.name && 28 == product.price && "eat" == product.usageType)
            {
                passed = true;
            }
            Assert.True(passed);
        }
        [Fact]
        public void testIceTea()
        {
            iceTea product = new iceTea();
            product.setProperties();
            bool passed = false;
            if ("Ice tea" == product.name && 16 == product.price && "drink" == product.usageType)
            {
                passed = true;
            }
            Assert.True(passed);
        }
    }
}
