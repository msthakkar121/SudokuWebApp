using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SudokuWebApp.Default;

namespace TestSudokuWebApp
{
    [TestClass]
    public class TestSolveFromDefault
    {
        [TestMethod]
        public void TestSolve()
        {
            Grid = new int[9, 9];

            String InputValid = "000000000000495000506000104001802600000000000005709200204000805000687000080504030";
            String InputInvalid = "110000000000495000506000104001802600000000000005709200204000805000687000080504030";
            
            SetGrid(InputValid);
            Assert.IsTrue(SolveGrid());

            SetGrid(InputInvalid);
            Assert.IsFalse(SolveGrid());
        }

        private void SetGrid(String Input)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Grid[i, j] = Int32.Parse(Input[j].ToString());
                }
                Input = Input.Substring(9, Input.Length - 9);
            }
        }
    }
}
