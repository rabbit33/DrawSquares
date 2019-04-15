using NUnit.Framework;

namespace ConsoleApp2
{
    public class ProblemTwoTests
    {
        [Test]
        public void ProblemTwo_EdgesIsNull_ReturnEmptyString()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(null);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ProblemTwo_EdgesIsEmpty_ReturnEmptyString()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(new int[] { });

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ProblemTwo_EdgesHasOneElementOfValue1_Returns1Hash()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(new[] { 1 });

            Assert.AreEqual("#", result);
        }

        [Test]
        public void ProblemTwo_EdgesHasOneElementOfValue2_ReturnsExpectedSquare()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(new[] { 2 });

            Assert.AreEqual("##\n##", result);
        }

        [Test]
        public void ProblemTwo_EdgesHasElements1and2_ReturnsExpectedSquare()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(new[] { 1, 2 });

            Assert.AreEqual("##\n##", result);
        }

        [Test]
        public void ProblemTwo_EdgesHasTwoElements_ReturnsExpectedSquare()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(new[] { 3, 5 });

            Assert.AreEqual("#####\n# # #\n### #\n#   #\n#####", result);
        }

        [Test]
        public void ProblemTwo_EdgesHasMultipleRandomElements_ReturnsExpectedSquare()
        {
            ProblemTwo problem = new ProblemTwo();

            string result = problem.DrawSquares(new[] { 1, 3, 5, 6, 11 });

            string expectedResult = "###########\n" +
                                    "# # ##    #\n" +
                                    "### ##    #\n" +
                                    "#   ##    #\n" +
                                    "######    #\n" +
                                    "######    #\n" +
                                    "#         #\n" +
                                    "#         #\n" +
                                    "#         #\n" +
                                    "#         #\n" +
                                    "###########";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
