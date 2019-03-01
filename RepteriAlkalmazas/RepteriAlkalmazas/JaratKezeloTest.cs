using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepteriAlkalmazas
{
    [TestFixture]
    class JaratKezeloTest
    {
        JaratKezelo jarat;
        DateTime testDate = new DateTime(2018, 07, 21, 12, 20, 20);

        [SetUp]
        public void Setup()
        {
            jarat = new JaratKezelo();
        }

        [Test]
        public void JaratFelvetel()
        {
            jarat.UjJarat("0715", "002", "004", testDate);
        }

        [Test]
        public void JaratUtkozes()
        {
            jarat.UjJarat("0715", "002", "004", testDate);

            Assert.Throws<ArgumentException>(() =>
            {
                jarat.UjJarat("0715", "002", "004", testDate);
            });
        }

        [Test]
        public void KesesAdd()
        {
            jarat.UjJarat("0715", "002", "004", testDate);
            jarat.Keses("0715", 10);
            jarat.Keses("0715", -5);
        }

        [Test]
        public void NegativKeses()
        {
            jarat.UjJarat("0715", "002", "004", testDate);
            jarat.Keses("0715", 10);

            Assert.Throws<NegativKesesException>(() =>
            {
                jarat.Keses("0715", -15);
            });
        }

        [Test]
        public void Indulas()
        {
            DateTime testDate2 = new DateTime(2018, 07, 21, 12, 25, 20);

            jarat.UjJarat("0715", "002", "004", testDate);
            jarat.Keses("0715", 20);
            jarat.Keses("0715", -15);


            Assert.AreEqual(testDate2, testDate.AddMinutes(5));
        }

    }
}
