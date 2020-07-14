﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingThrow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomething(1);
                DoSomething(2);
                DoSomething(9);
                DoSomething(12);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외 발생 : {ex.Message}");
                Console.WriteLine($"도움말 링크 : {ex.HelpLink}");
                Console.WriteLine($"소스 : {ex.Source}");
            }
            finally
            {
                Console.WriteLine("에러가 있든 없든 수행합니다~");
            }
        }

        private static void DoSomething(int arg)
        {
            if (arg < 10)
                Console.WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 큽니다")
                {
                    HelpLink = "http://www.google.com",
                    Source = "UsingThrow line18"
                };
        }
    }
}
