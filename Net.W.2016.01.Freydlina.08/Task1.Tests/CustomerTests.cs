using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        public static IEnumerable<TestCaseData> TestCasesForToString
        {
            get
            {
                yield return new TestCaseData(null, null).Returns("John Carter, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData("NRP", null).Returns("John Carter, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData("NR", null).Returns("John Carter, 123,456,789.00");
                yield return new TestCaseData("NP", null).Returns("John Carter, +1 (111) 111-1111");
                yield return new TestCaseData("PR", null).Returns("+1 (111) 111-1111, 123,456,789.00");
                yield return new TestCaseData("N", null).Returns("John Carter");
                yield return new TestCaseData("P", null).Returns("+1 (111) 111-1111");
                yield return new TestCaseData("R", null).Returns("123,456,789.00");
                yield return new TestCaseData(null, new CustomFormatter()).Returns("JOHN CARTER, 123456789,00, +1 (111) 111 11 11");
                yield return new TestCaseData("NRP", new CustomFormatter()).Returns("JOHN CARTER, 123456789,00, +1 (111) 111 11 11");
                yield return new TestCaseData("NR", new CustomFormatter()).Returns("JOHN CARTER, 123456789,00");
                yield return new TestCaseData("NP", new CustomFormatter()).Returns("JOHN CARTER, +1 (111) 111 11 11");
                yield return new TestCaseData("PR", new CustomFormatter()).Returns("+1 (111) 111 11 11, 123456789,00");
                yield return new TestCaseData("N", new CustomFormatter()).Returns("JOHN CARTER");
                yield return new TestCaseData("P", new CustomFormatter()).Returns("+1 (111) 111 11 11");
                yield return new TestCaseData("R", new CustomFormatter()).Returns("123456789,00");
            }
        }
        [Test, TestCaseSource(nameof(TestCasesForToString))]
        public string TestToString(string format, IFormatProvider provider)
        {
            Customer current = new Customer("John Carter", "+1 (111) 111-1111", 123456789);
            return current.ToString(format, provider);
        }
    }
}
