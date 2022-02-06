namespace DataStructureAndAlgo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design.Serialization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PossibleItems
    {
        private Dictionary<int, string[]> dict = new Dictionary<int, string[]>();

        public PossibleItems()
        {
            dict[1] = new string[] { "0,0", "0,1", "0,2", "1,0", "1,1", "1,2", "2,0", "2,1", "2,2" };
            dict[2] = new string[] { "0,3", "0,4", "0,5", "1,3", "1,4", "1,5", "2,3", "2,4", "2,5" };
            dict[3] = new string[] { "0,6", "0,7", "0,8", "1,6", "1,7", "1,8", "2,6", "2,7", "2,8" };
            dict[4] = new string[] { "3,0", "3,1", "3,2", "4,0", "4,1", "4,2", "5,0", "5,1", "5,2" };
            dict[5] = new string[] { "3,3", "3,4", "3,5", "4,3", "4,4", "4,5", "5,3", "5,4", "5,5" };
            dict[6] = new string[] { "3,6", "3,7", "3,8", "4,6", "4,7", "4,8", "5,6", "5,7", "5,8" };
            dict[7] = new string[] { "6,0", "6,1", "6,2", "7,0", "7,1", "7,2", "8,0", "8,1", "8,2" };
            dict[8] = new string[] { "6,3", "6,4", "6,5", "7,3", "7,4", "7,5", "8,3", "8,4", "8,5" };
            dict[9] = new string[] { "6,6", "6,7", "6,8", "7,6", "7,7", "7,8", "8,6", "8,7", "8,8" };
        }

        public IEnumerable<int> GetPossibleValues(char[][] arr, int row, int col)
        {
            List<int> possibleList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            List<int> quadrants = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[row][i] == '.')
                {
                    rows.Add(arr[row][i]);
                }

                if (arr[i][col] == '.')
                {
                    cols.Add(arr[i][col]);
                }
            }

            var dictValue = row.ToString() + "," + col.ToString();
            var quadrant = dict.Where(x => x.Value.Contains(dictValue));
            var indexList = quadrant.First().Value;
            foreach (var index in indexList)
            {
                var rowAndCol = index.Split(',').ToArray();
                var row1 = Convert.ToInt32(rowAndCol[0]);
                var col1 = Convert.ToInt32(rowAndCol[1]);
                if (arr[row1][col1] != '.')
                {
                    quadrants.Add(arr[row1][col1]);
                }
            }

            var list = possibleList.Where(x => !rows.Contains(x) && !cols.Contains(x) && !quadrants.Contains(x));

            return list;
        }
    }
}
