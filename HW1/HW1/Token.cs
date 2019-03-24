using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Token
    {
        string KeyWord;
        int Row = 0;
        int Col = 0;
        int NestedBlockNumber;

        public void AddToken(string keyWord, int row, int col)
        {
            this.KeyWord = keyWord;
            this.Row = row;
            this.Col = col;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
