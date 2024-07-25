using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bai_29_async_await
{
    /*
     * Lập trình bất đồng bộ : Làm việc với lớp Task
     *          
     */
    class Program
    {
        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.WriteLine("Start");
            }
            string a = "ab";
            // lock(a) những luồng khác muốn truy cập vào a thì phải đợi a thực hiện xong luồng của mình, thì các luồng khác mới có thể truy cập vào được
            lock (a)
            {
                //....
            }
            for(int i = 1; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Thread.Sleep(1000);
                }
            }

            Console.ResetColor();
            Console.WriteLine("End....");
        }
        static void Main(string[] args)
        {
            // synchronous: đồng bộ -
            //DoSomeThing(5, "ABC1", ConsoleColor.Red);
            //DoSomeThing(10, "T1", ConsoleColor.Green);
            //DoSomeThing(2, "T3", ConsoleColor.Blue);
            //Console.WriteLine("hello world");

            //async: bất đồng bộ
            // khởi tạo tác vụ 
            Task t2 = new Task(
                () =>
                {
                    DoSomeThing(10, "T2", ConsoleColor.Green);
                }
                );
            Task t3 = new Task(
                (object obj) =>
                {
                    string tenTacVu = (string)obj;
                    DoSomeThing(10, tenTacVu, ConsoleColor.Magenta);
                },"T3"
                );

            // sử dụng task vụ 
            t2.Start();// thread
            t3.Start();
            DoSomeThing(2, "T1", ConsoleColor.Blue);
            t2.Wait();// chờ cho task2 thực hiện xong mới đến lượt t3 
            t3.Wait();
            //Task.WaitAll(t2, t3);// liệt kê các tác vụ thực hiện theo lần lượt và hoành thành mới in ra câu hell world

            Console.WriteLine("hello world");
            Console.ReadKey();
        }
    }
}
