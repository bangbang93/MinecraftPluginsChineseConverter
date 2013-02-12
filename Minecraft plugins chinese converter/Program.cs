using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Win32;
using System.Management;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        public static string unicode_js_0(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (Regex.IsMatch(str[i].ToString(), @"[\u007f-\uffff]")) { outStr += "\\u" + ((int)str[i]).ToString("x4"); }
                    else { outStr += str[i]; }
                }
            }
            return outStr;
        } 
        static void Main(string[] args)
        {
            string[] spliter = { "\"" };
            string infile = Environment.CommandLine.Split(spliter, StringSplitOptions.RemoveEmptyEntries)[2];
            Console.WriteLine(infile);
            Console.ReadLine();
            StreamReader input = new StreamReader(infile,Encoding.Default);
            string outfile=infile.Substring(0,infile.LastIndexOf("."))+"new";
            StreamWriter output = new StreamWriter(outfile,false,Encoding.Default);
            string str;
            do
            {
                str = input.ReadLine();
                //string t = HttpUtility.UrlEncodeUnicode(str);
                //t = t.Replace("%", @"\");
                //t = t.Replace(@"\26", "&");
                //t = t.Replace(@"\3a", ":");
                //t = t.Replace("+", " ");
                //t = t.Replace(@"\23", "#");
                //t = t.Replace(@"\25", "%");
                //t = t.Replace(@"\2f", @"\");
                //t = t.Replace(@"\7e", @"~");
                string t = unicode_js_0(str);
                
                output.WriteLine(t);
            }
            while (input.EndOfStream == false);
            input.Close();
            output.Close();
            File.Move(infile,infile+"bak");
            File.Move(outfile, infile);
            Console.WriteLine();
            //Console.WriteLine(HttpUtility.UrlEncodeUnicode(str).Replace("%","/"));
            //Console.Write("\u82e5\u9700\u67e5\u8be2\u66f4\u591a\u5173\u4e8e\u6bcf\u79cd\u804c\u4e1a\u7684\u4fe1\u606f\u8bf7\u5728\u5bf9\u8bdd\u6846\u4e2d\u8f93\u5165");
            //Console.ReadLine();
        }
    }
}
