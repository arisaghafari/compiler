using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class lexer
    {
        List<Token> allOfTokens = new List<Token>();
        int row = 1;
        int col = -1;
        int realCol = -1;
        int state = 0;
        int length = 0;
        char lastchar = '\0';
        char nextChar;
        char[] word = new char[80];
        static int indexOfText = 0;
        bool newword = true;

        public void lexerAnalyzer(String text)
        {
            while (text.Length + 1 != indexOfText)
            {
                if (newword)
                {
                    realCol = col + 1;
                    if (lastchar != '\0')
                    {
                        realCol = realCol - 1;
                    }
                    Token newToken = new Token();
                    word = new char[80];
                    newword = false;
                }
                if (lastchar != '\0')
                {
                    nextChar = lastchar;
                    lastchar = '\0';
                }
                else
                {
                    col = col + 1;
                    if (text.Length == indexOfText)
                    {
                        if (word[0] != '\0')
                        {
                            Token newToken = new Token();
                            newToken.addToken(new String(word), row, col);
                            allOfTokens.Add(newToken);
                            state = 0;
                            length = 0;
                            newword = true;
                        }
                        break;
                    }
                    nextChar = text[indexOfText];
                    indexOfText++;
                }
                word[length++] = nextChar;

                switch (state)
                {
                    case 0:
                        if (nextChar == '\n')
                        {
                            row = row + 1;
                            col = -1;
                            realCol = -1;
                            newword = true;
                            break;
                        }
                        if (Char.IsLetter(nextChar))
                        {
                            //System.out.println("I am nextChar:");
                            //System.out.println(nextChar);
                            state = 1;
                            break;
                        }
                        if (Char.IsDigit(nextChar))
                        {
                            state = 5;
                            break;
                        }
                        if (nextChar == '.')
                        {
                            state = 6;
                            break;
                        }

                        if (nextChar == '(' | nextChar == ')' | nextChar == '+' | nextChar == '-' | nextChar == ':' | nextChar == ';' | nextChar == ',')
                        {
                            state = 0;
                            length = 0;
                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            newword = true;
                            break;

                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            length = 0;
                            newword = true;
                            break;
                        }
                        if (nextChar == '=')
                        {
                            state = 2;
                            break;
                        }
                        if (nextChar == '*')
                        {
                            state = 3;
                            break;
                        }
                        if (nextChar == '/')
                        {
                            state = 4;
                            break;
                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                        else
                        {
                            word[length - 1] = '\0';
                            state = 0;
                            length = 0;
                            newword = true;

                            LexicalError(nextChar, col, realCol);

                            break;
                        }
                    case 1:
                        if (Char.IsLetter(nextChar) | Char.IsDigit(nextChar) | nextChar == '_')
                        {
                            break;
                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                        else
                        {
                            lastchar = nextChar;
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }

                    case 2:
                        if (nextChar == '=')
                        {

                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;

                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }

                        else
                        {
                            state = 100;
                        }
                        break;
                    case 3:
                        if (nextChar == '*')
                        {

                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;

                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                        else
                        {
                            state = 100;
                        }
                        break;

                    case 4:
                        if (nextChar == '/')
                        {
                            Token newToken1 = new Token();
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;

                        }
                        else
                        {
                            state = 100;
                        }
                        break;
                    case 5:
                        if (Char.IsDigit(nextChar))
                        {
                            break;
                        }
                        if (nextChar == '.')
                        {
                            state = 6;
                            break;
                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.setSymbol(Symbols.S_number);
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                        else
                        {
                            lastchar = nextChar;
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.setSymbol(Symbols.S_number);
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                    case 6:
                        if (Char.IsDigit(nextChar))
                        {
                            state = 7;
                            break;
                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.setSymbol(Symbols.S_number);
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                        else
                        {
                            lastchar = nextChar;
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.setSymbol(Symbols.S_number);
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }

                    case 7:
                        if (Char.IsDigit(nextChar))
                        {
                            break;
                        }
                        if (nextChar == ' ')
                        {
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.setSymbol(Symbols.S_number);
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }
                        else
                        {
                            lastchar = nextChar;
                            word[length - 1] = '\0';
                            Token newToken1 = new Token();
                            newToken1.setSymbol(Symbols.S_number);
                            newToken1.addToken(new String(word), row, realCol);
                            allOfTokens.Add(newToken1);
                            state = 0;
                            length = 0;
                            newword = true;
                            break;
                        }

                    case 100:
                        lastchar = nextChar;
                        word[length - 1] = '\0';
                        Token newToken = new Token();
                        newToken.addToken(new String(word), row, realCol);
                        allOfTokens.Add(newToken);
                        state = 0;
                        length = 0;
                        newword = true;
                        break;
                }

            }


        }
        public static Symbols isKeyWord(String word)
        {
            Symbols example;
            if (word[0] == 'i' & word[1] == 'f')
            {
                example = Symbols.S_if;
                return example;
            }
            else if (word[0] == 'w' & word[1] == 'h' & word[2] == 'i' & word[3] == 'l' & word[4] == 'e')
            {
                example = Symbols.S_while;
                return example;
            }
            else if (word[0] == 'd' & word[1] == 'o')
            {
                example = Symbols.S_do;
                return example;
            }
            else if (word[0] == 'f' & word[1] == 'o' & word[2] == 'r')
            {
                example = Symbols.S_for;
                return example;
            }
            else if (word[0] == 'e' & word[1] == 'l' & word[2] == 's' & word[3] == 'e')
            {
                example = Symbols.S_else;
                return example;
            }
            else if (word[0] == '=' & word[1] == '=')
            {
                example = Symbols.S_equal;
                return example;
            }
            else if (word[0] == '=')
            {
                example = Symbols.S_assign;
                return example;
            }
            else if (word[0] == '!' & word[1] == '=')
            {
                example = Symbols.S_notEqual;
                return example;
            }


            else if (Char.IsDigit(word[0]))
            {
                example = Symbols.S_Number;
                return example;
            }
            else if (word[0] == '.')
            {
                if (Char.IsDigit(word[1]))
                {
                    example = Symbols.S_Number;
                    return example;
                }
                example = Symbols.S_dot;
                return example;
            }
            else if (word[0] == '(')
            {
                example = Symbols.S_openParantez;
                return example;
            }
            else if (word[0] == ')')
            {
                example = Symbols.S_closeParantez;
                return example;
            }
            else if (word[0] == '+')
            {
                example = Symbols.S_plus;
                return example;
            }
            else if (word[0] == '-')
            {
                example = Symbols.S_sub;
                return example;
            }
            else if (word[0] == '*' & word[1] == '*')
            {
                example = Symbols.S_power;
                return example;
            }
            else if (word[0] == '*')
            {
                example = Symbols.S_mul;
                return example;
            }
            else if (word[0] == '/' & word[1] == '/')
            {
                example = Symbols.S_devide;
                return example;
            }
            else if (word[0] == '/')
            {
                example = Symbols.S_correct_devide;
                return example;
            }

            else if (word[0] == 'c' & word[1] == 'a' & word[2] == 's' & word[3] == 'e')
            {
                example = Symbols.S_case;
                return example;
            }
            else if (word[0] == 's' & word[1] == 'w' & word[2] == 'i' & word[3] == 't' & word[4] == 'c' & word[5] == 'h')
            {
                example = Symbols.S_switch;
                return example;
            }
            else if (word[0] == 'b' & word[1] == 'r' & word[2] == 'e' & word[3] == 'a' & word[4] == 'k')
            {
                example = Symbols.S_break;
                return example;
            }
            else if (word[0] == 'c' & word[1] == 'o' & word[2] == 'n' & word[3] == 't' & word[4] == 'i' & word[5] == 'n' & word[6] == 'u' & word[7] == 'e')
            {
                example = Symbols.S_continue;
                return example;
            }
            else if (word[0] == 'r' & word[1] == 'e' & word[2] == 't' & word[3] == 'u' & word[4] == 'r' & word[5] == 'n')
            {
                example = Symbols.S_return;
                return example;
            }
            else if (word[0] == 'a' & word[1] == 'n' & word[2] == 'd')
            {
                example = Symbols.S_and;
                return example;
            }
            else if (word[0] == 'o' & word[1] == 'r')
            {
                example = Symbols.S_or;
                return example;
            }
            else if (word[0] == ',')
            {
                example = Symbols.S_comma;
                return example;

            }
            else if (word[0] == ':')
            {
                example = Symbols.S_colon;
                return example;

            }
            else if (word[0] == ';')
            {
                example = Symbols.S_semiColon;
                return example;

            }

            else if (word[0] == '.')
            {
                example = Symbols.S_dot;
                return example;
            }
            else
            {
                example = Symbols.S_id;
                return example;
            }

        }
        public void LexicalError(char nextChar, int col, int row)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("It Has Lexical Error in row: %d     col= %d\n", row, col);
            Console.WriteLine("the char is:%s\n", nextChar);
            Console.WriteLine("**********************");

        }

    }
}
