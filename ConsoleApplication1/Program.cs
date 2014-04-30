﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Util;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(@"E:\Code\WWW\DEV\Soap\WebSite\AJAX\AddressAjax.aspx");
            RepeatRun(() =>
            {
                var fiLink = new FileInfo(@"E:\Code\WWW\DEV\Diapers\WebSite\JS\SearchSite\plplazyload.js");
                var originFile = new FileInfo(@"E:\Code\WWW\DEV\QuidsiWebSite\UnifiedJs\SearchSite\plplazyload.js");

                Console.WriteLine(fiLink.Length);
                Console.WriteLine((fiLink.Directory.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint);
                Console.WriteLine(originFile.Directory.Attributes);
            });
        }

        static void RepeatRun(Action action)
        {
            string q = string.Empty;
            while (!"q".Equals(q, StringComparison.OrdinalIgnoreCase))
            {
                DateTime TimeStart = DateTime.Now;
                Console.WriteLine("start " + TimeStart.ToString("HH:mm:ss fff"));

                action();

                Console.WriteLine("done, " + DateTime.Now.Subtract(TimeStart).TotalMilliseconds);

                Console.Write("input q to exit:");
                q = Console.ReadLine().Trim();
            }
        }
    }
}