using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBuilder
{
    class LexicalAnalizer
    {
        List<String>[] messages = new List<String>[6];
        bool isProgram;
        List<String> possibleLabels;

        private String[] lexemas = { 
                                       "prog", "getNumber", "printNumber", "to", "do", 
                                       "next", "if", "then", "goto", "or", "and"
                                   };
        private String[] separators = {
                                          "{", "}", "=", "(", ")", "+", "-", "*", "/", "<", 
                                          ">", "!", "\r", "[", "]", ",", " "
                                      };

        public LexicalAnalizer()
        {
            messages[0] = new List<string>();
            messages[1] = new List<string>();
            messages[2] = new List<string>();
            messages[3] = new List<string>();
            messages[4] = new List<string>();
            messages[5] = new List<string>();
            isProgram = false;
            possibleLabels = new List<string>();
        }

        public List<String>[] CheckLine(String s)
        {
            messages[1] = new List<string>();
            StringBuilder item = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (IsSeparator(s.ElementAt(i).ToString()))
                {
                    if (item.Length != 0)
                    {
                        if (!IsLexema(item.ToString()) && !IsNumber(item.ToString()) && !IsId(item.ToString()) && !IsLabel(item.ToString()))
                        {
                            messages[1].Add("\"" + item + "\"" + " is unknown item");
                        }
                        else
                        {
                            int result = 0;
                            if (IsLexema(item.ToString()))
                            {
                                result = GetLexemasCode(item.ToString());
                            }
                            else
                                if (IsNumber(item.ToString()))
                                {
                                    result = Constants.NUMBER;
                                    if (!IsContains(messages[3], item.ToString()))
                                        messages[3].Add(item.ToString());
                                }
                                else
                                    if (IsLabel(item.ToString()))
                                    {
                                        result = Constants.LABEL;
                                        if (!IsContains(messages[4], item.ToString().Substring(0, item.Length - 1)))
                                            messages[4].Add(item.ToString().Substring(0, item.Length - 1));
                                        item.Remove(item.Length - 1, 1);
                                    }
                                    else
                                        if (IsId(item.ToString()))
                                        {
                                            if (messages[0].Count > 0 && messages[0][messages[0].Count - 1].Equals("9"))
                                            {
                                                result = Constants.LABEL;
                                                if (!IsContains(possibleLabels, item.ToString()))
                                                {
                                                    possibleLabels.Add(item.ToString());
                                                }
                                            }
                                            else
                                            {
                                                result = Constants.ID;
                                                if (!isProgram)
                                                {
                                                    if (!IsContains(messages[2], item.ToString()))
                                                        messages[2].Add(item.ToString());
                                                    else
                                                        messages[1].Add("Duplicate variable " + item.ToString() + ". You must delete one.");
                                                }
                                                else
                                                {
                                                    if (!IsContains(messages[2], item.ToString()))
                                                        messages[1].Add("Using of undeclared variable " + item.ToString() + ". You must declare it before using.");

                                                }
                                            }
                                        }
                            messages[0].Add(result.ToString());
                            messages[5].Add(item.ToString());
                        }
                    }
                    if (!s[i].Equals(' '))
                    {
                        int res = GetSeparatorsCode(s[i].ToString());
                        messages[5].Add(s[i].ToString());
                        if (messages[0].Count > 0)
                        {
                            int sep = int.Parse(messages[0][messages[0].Count - 1]);
                            if (s[i].Equals('='))
                            {
                                switch (sep)
                                {
                                    case 21: res = 28; messages[0].RemoveAt(messages[0].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1); 
                                        messages[5].Add("<="); break;
                                    case 22: res = 29; messages[0].RemoveAt(messages[0].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1);
                                        messages[5].Add(">="); break;
                                    case 14: res = 30; messages[0].RemoveAt(messages[0].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1); 
                                        messages[5].Add("=="); break;
                                    case 23: res = 31; messages[0].RemoveAt(messages[0].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1);
                                        messages[5].RemoveAt(messages[5].Count - 1); 
                                        messages[5].Add("!="); break;
                                }
                            }
                        }
                        if (res == Constants.PROGRAM_BEGINS)
                            isProgram = true;
                        messages[0].Add(res.ToString());
                    }
                    item = new StringBuilder();
                }
                else
                {
                    item.Append(s[i]);
                }
            }
            return messages;
        }

        public List<String> CheckLabels()
        {
            List<String> errors = new List<string>();
            foreach (String pLabel in possibleLabels)
            {
                if (!IsContains(messages[4], pLabel))
                    errors.Add("Error: Undelared label \"" + pLabel + "\" is used!");
            }
            return errors;
        }

        private bool IsContains(List<String> source, String item)
        {
            foreach (String element in source)
            {
                if (element.Equals(item))
                    return true;
            }
            return false;
        }

        private int GetSeparatorsCode(String s)
        {
            for (int i = 0; i < separators.Length; i++ )
            {
                if (separators[i].Equals(s))
                    return i + lexemas.Length + 1;
            }
            return -1;
        }

        private bool IsSeparator(String s)
        {
            foreach (String sep in separators)
            {
                if (sep.Equals(s))
                    return true;
            }
            return false;
        }

        private int GetLexemasCode(String s)
        {
            for (int i = 0; i < lexemas.Length; i++ )
            {
                if (lexemas[i].Equals(s))
                    return i+1;
            }
            return -1;
        }
        private bool IsLexema(String s)
        {
            foreach (String lex in lexemas)
            {
                if (lex.Equals(s))
                    return true;
            }
            return false;
        }
        private bool IsNumber(String s)
        {
            try
            {
                float num = float.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool IsId(String s)
        {
            if ((s.ElementAt(0) >= 65 && s.ElementAt(0) <= 90) || (s.ElementAt(0) >= 97 && s.ElementAt(0) <= 122))
            {
                if (s.Length > 1)
                {
                    foreach (char c in s)
                    {
                        if (!Char.IsLetterOrDigit(c))
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
        private bool IsLabel(String s)
        {
            if (s.Length > 1)
            {
                if (IsId(s.Substring(0, s.Length - 1)) && s.ElementAt(s.Length - 1).Equals(':'))
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
