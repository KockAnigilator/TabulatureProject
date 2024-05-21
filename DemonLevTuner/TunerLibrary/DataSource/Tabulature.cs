using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Linq;

namespace TunerLibrary.DataSource
{
    public class Tabulature
    {
        private List<string> _strings;
        private List<string> _stringNameList;
        public List<string> Strings { get => _strings; set => _strings = value; }
        public List<string> StringNameList { get => _stringNameList; set => _stringNameList = value; }

        public Tabulature(List<string> strings, List<string> names)
        {
            _strings = new List<string>(strings);
            _stringNameList = new List<string>(names);
        }

        public Tabulature(List<int> tabs, List<int> pos, List<string> names, List<int> stringIds)
        {

            _strings = new List<string>();
            _stringNameList = new List<string>(names);
            for (int i = 0; i < Enumerable.Range(0,stringIds.Max()+1).Count(); i++)
            {
                _strings.Add(string.Empty);
            }

            List<int> curPos = new List<int>();
            for (int i = 0; i < Enumerable.Range(0, stringIds.Max()+1).Count(); i++)
            {
                curPos.Add(0);
            }
            for (int i = 0; i < pos.Count; i++)
            {
                
                
                _strings[stringIds[i]] += new string('-', pos[i] - curPos[stringIds[i]]) + tabs[i];
                curPos[stringIds[i]] = pos[i];
            }
            _strings = _strings.Where(x => x.Length > 0).ToList();
            _strings.Reverse();

        }

        public override string ToString()
        {
            string ans = string.Empty;
            List<string> tmp = new List<string>(_strings);
            tmp.Reverse();
            tmp.ToList().ForEach(x =>
            {
                ans += x + "\n";
            });
            return ans;
        }
    }
}