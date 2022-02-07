namespace DataStructureAndAlgo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SudokuSolver
    {
        private PossibleItems helper = new PossibleItems();

        public char[][] GetSolvedSudoku(char[][] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i][j] == '.')
                    {
                        var possibleItems = helper.GetPossibleValues(inputArray, i, j);
                        if (possibleItems.Count() == 1)
                        {
                            inputArray[i][j] = possibleItems.First().ToString().ToCharArray().First();
                        }
                    }
                }
            }

            return inputArray;
        }
    }
}
