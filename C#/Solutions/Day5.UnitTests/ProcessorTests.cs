using NUnit.Framework;

namespace Day5.UnitTests
{
    public class ProcessorTests
    {
        [Test]
        public void DecomposeOpCode_WhenPassedSingleDigit_ReturnsOpcodeAnd2ParameterValues()
        {
            var value = 1;
            var res = Processor.DecomposeOpCode(value);
            Assert.That(res.Item1.Length, Is.EqualTo(2));
            Assert.IsTrue(res.Item2 == value);
        }

        [Test]
        public void DecomposeOpCode_WhenPassedSingleDigit_ReturnsParameterValuesInPositionModes()
        {
            var value = 1;
            var res = Processor.DecomposeOpCode(value);
            Assert.IsTrue(res.Item1[0] == ParameterMode.Position);
            Assert.IsTrue(res.Item1[1] == ParameterMode.Position);
        }


        [Test]
        public void DecomposeOpCode_WhenPassed4Digits_ReturnsOpcodeAs2LastDigitsAndParameterModesForEachDigitStartedFromHundredDigit()
        {
            var value = 1004;
            var res = Processor.DecomposeOpCode(value);
            Assert.IsTrue(res.Item1[0] == ParameterMode.Position);
            Assert.IsTrue(res.Item1[1] == ParameterMode.Immediate);
            Assert.That(res.Item2, Is.EqualTo(4));
        }
    }
}