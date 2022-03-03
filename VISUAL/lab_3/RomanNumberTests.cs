using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
         RomanNumber a = new(1);
         Assert.AreEqual("I", a.ToString());
         a = new(3999);
         Assert.AreEqual("MMMCMXCIX", a.ToString());
        }
        [TestMethod()]
        public void Add()
        {
            RomanNumber a = new (1);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 1; i < 3998; i++)
            {

                b = new (i);
                c = new (++i);
                Assert.AreEqual(c.ToString(), (a + b).ToString());
            }
        }
        [TestMethod()]
        public void Sub()
        {
            RomanNumber a = new (1);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 3999; i >= 2; i--)
            {
                b = new (i);
                c = new (--i);
                Assert.AreEqual(c.ToString(), (b - a).ToString());
            }
        }
        [TestMethod()]
        public void Mul()
        {
         
            RomanNumber a = new (2);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 1; i < 2000 ; i++)
            {
                b = new (i);
                c = new (Convert.ToUInt16(i * 2));
                Assert.AreEqual(c.ToString(), (a * b).ToString());
            }

        }
        [TestMethod()]
        public void Div()
        {
            RomanNumber a = new (2);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 3998; i >= 2; i-=2)
            {
                b = new (i);
                c = new (Convert.ToUInt16(i / 2));
                Assert.AreEqual(c.ToString(), (b / a).ToString());
            }
        }
        [TestMethod()]
        public void CloneTest()
        {
            RomanNumber a;
            for (ushort i = 1; i < 4000; i++)
            {
                a = new (i);
                var c = a.Clone();
                Assert.AreEqual(a.ToString(), c.ToString());
            }
        }
        [TestMethod()]
        public void ExceptionTest()
        {
            RomanNumber a;
            RomanNumber b;
            Assert.ThrowsException<RomanNumberException>(()=>a = new (0));
            Assert.ThrowsException<RomanNumberException>(()=>a = new (4000));
            Assert.ThrowsException<RomanNumberException>(()=>a = new (10000));
            a = new (1);
            b = new (3999);
            Assert.ThrowsException<RomanNumberException>(()=>(a + b).ToString());
            a = new (1);
            b = new (1);
            Assert.ThrowsException<RomanNumberException>(()=>(a - b).ToString());
            a = new (2);
            b = new (2000);
            Assert.ThrowsException<RomanNumberException>(()=>(a * b).ToString());
            a = new (1);
            b = new (10);
            Assert.ThrowsException<RomanNumberException>(() => (a / b).ToString());
        }

        [TestMethod()]
        public void CompareToTest()
        {
            RomanNumber a;
            RomanNumber b;
            for (ushort i = 1; i < 4000; i++)
            {
                a = new (i);
                b = new (i);
                Assert.IsTrue(a.CompareTo(b) == 0);
            }
            a = new (1);
            for (ushort i = 2; i < 4000; i++)
            {
                b = new (i);
                Assert.IsTrue(a.CompareTo(b) != 0);
            }
        }

    }
}