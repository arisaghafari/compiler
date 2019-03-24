using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class Token
    {
        String word;
        int row = 0;
        int col = 0;
        int NestedBlockNumber;
        Symbols symbol;

         public void addToken(String word, int row, int col)
        {
            this.word = word;
            symbol = lexer.isKeyWord(word);
            this.row = row;
            this.col = col;
            
        }
        public void setSymbol(Symbols symbol)
        {
            this.symbol = symbol;
        }
        public override string ToString()
        {
            return "the word is : " + word + "\nthe Symbol Of it : " + symbol + "\n" + "row : " + row + "\n" + "col : " + col + "\n";
        }
    }
}
