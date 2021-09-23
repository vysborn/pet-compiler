using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBuilder
{
    class Grammar
    {
        private Dictionary<string, List<List<string>>> rules;
        private List<string> keys, allItems, exceptions;

        public Grammar()
        {
            rules = new Dictionary<string, List<List<string>>>();
            keys = new List<string>();
            allItems = new List<string>();
            //exceptions = new List<string> { "id","const","=",";","+","-","/","*","and","or","ratio","to",",", "by","if","then","do", "while", "end"};
          
            exceptions = new List<string> {  };
        }

        public void AddRule(string title, List<List<string>> sequnce)
        {
            rules.Add(title, sequnce);
        }

        public void UpdateKeys()
        {
            foreach (var item in rules.Keys)
            {
                keys.Add(item);
            }
        }

        public void UpdateAllItems()
        {
            foreach (var key in rules.Keys)
            {
                List<List<string>> list;
                if (!allItems.Contains(key))
                {
                    allItems.Add(key);
                }
                if (rules.TryGetValue(key, out list))
                {
                    foreach (var lst in list)
                    {
                        foreach (var item in lst)
                        {
                            if (!allItems.Contains(item) && !item.Equals("|"))
                                allItems.Add(item);
                        }
                    }
                }
            }
        }

        public List<List<string>> GetSuquence(string key)
        {
            List<List<string>> list;
            if (rules.TryGetValue(key, out list))
            {
                return list;
            }
            return null;
        }

        public List<string> GetKeys()
        {
            return keys;
        }
        public List<string> GetAllItems()
        {
            return allItems;
        }
        public List<string> GetExceptions()
        {
            return exceptions;
        }
        public void First(string value, List<string> result)
        {
            List<List<string>> list;
            if (rules.TryGetValue(value, out list))
            {
                foreach (var item in list)
                {
                    if (!result.Contains(item[0]))
                    {
                        result.Add(item[0]);
                        First(item[0], result);
                    }

                }
                
            }
        }

        public void Last(string value, List<string> result)
        {
            List<List<string>> list;
            if (rules.TryGetValue(value, out list))
            {
                foreach (var item in list)
                {
                    if (!result.Contains(item[item.Count - 1]))
                    {
                        result.Add(item[item.Count - 1]);
                        Last(item[item.Count - 1], result);
                    }
                }
               
            }
        }
    }
}
