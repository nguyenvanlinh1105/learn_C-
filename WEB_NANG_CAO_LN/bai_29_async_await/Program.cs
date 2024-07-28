using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace bai_29_async_await
{
    /*
     * Lập trình bất đồng bộ : Làm việc với lớp Task
3     *          
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
         static async Task Task2(){
            Task t2 = new Task(
                () =>
                {
                    DoSomeThing(10, "T2", ConsoleColor.Green);
                }
                );
            t2.Start();
            await t2;
            // t2.Wait();
            Console.WriteLine("T2 đã hoàng thành");
            
        }// trả về task và sau khi trả về thì nó thực thi trong đó luôn
         static Task Task3()
        {
            Task t3 = new Task(
                (object ob) =>{
                string tenTacVu = (string)ob;
                DoSomeThing(10, tenTacVu, ConsoleColor.Magenta);
            },"T3"
                );
            t3.Start();
            t3.Wait();
            Console.WriteLine("T3 đã hoàn thành");
            return t3;
        }
        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
                () =>
                {
                    DoSomeThing(5, "T4", ConsoleColor.Green);
                    return "Return form t4";
                }
                );
            t4.Start();
            await t4;
            Console.WriteLine("T4 hoàn thành");
            //return t4;
            // khi khai baó phương thưc với từ khóa asyn ở phương thức trả về giá trị thì không cần return task và trả về giá trị đúng với kieru giá trị định nghĩa mà task sẽ trả về.
            var kq = t4.Result;
            return kq;
        }
        static async Task<string> Task5() {
            Task<string> t5 = new Task<string>(
                (object ob) =>
                {
                    string text = (string)ob;
                    DoSomeThing(5, text, ConsoleColor.Magenta);
                    return "T5 đã return nè";
                }, "Linh Nguyen Pro"
                );
            //t5.Start();
            await t5;
            var kq = t5.Result;
            return kq;
        }

        // xây dụng phương thức download 
        static async Task<string> GetWeb(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            string content = await kq.Content.ReadAsStringAsync();
            return content;


        }
        static async Task Main(string[] args)
        {
            // synchronous: đồng bộ -
            //DoSomeThing(5, "ABC1", ConsoleColor.Red);
            //DoSomeThing(10, "T1", ConsoleColor.Green);
            //DoSomeThing(2, "T3", ConsoleColor.Blue);
            //Console.WriteLine("hello world");

            //async: bất đồng bộ
            // khởi tạo tác vụ 
            //Task t2 =  Task2();
            //Task t3 =  Task3();

            // sử dụng task vụ 
            // t2.Start();// thread
            // t3.Start();
            //DoSomeThing(2, "T1", ConsoleColor.Blue);
            // t2.Wait();// chờ cho task2 thực hiện xong mới đến lượt t3 
            // t3.Wait();
            //Task.WaitAll(t2, t3);// liệt kê các tác vụ thực hiện theo lần lượt và hoành thành mới in ra câu hell world
            //await t2;
            //await t3;
            //Task t4 = new Task<string>(Func<string>);// task này sẽ nhận một function và trả về đúng giá trị định nghĩa của task mà không có đối số nào truyền  vào trong delegate
            //Task<string> t4 = new Task<string>(
            //    ()=>
            //    {
            //        DoSomeThing(10, "T4", ConsoleColor.Green);
            //        return "Return from t4";
            //    });
            // đã tạo ra một phương thức tương tự cách ở trên nên ta có thể rút gọn lại như sau .
            Task<string> t4 = Task4();
            //Task t5 = new Task<string>(Function< object, string>,string); delegate sẽ làm tham số của task, trong delegate nhận tham số là object1 và object2 - delegate trả về giá trị === với giá trị của Task và nhận
            Task<string> t5 = new Task<string>(
                (object obj) =>
                {
                    string text = (string)obj;
                    DoSomeThing(2, text, ConsoleColor.Magenta);
                    return text;
                },"Linh nguyễn t5"
                );// nó truyền vào delegate qua object 
            

            //t4.Start();
            //t4.Wait();
           // t5.Start();
            //Task.WaitAll(t4, t5);
           // Console.WriteLine("hello world");
           // var kq4 = await t4;
           // var kq5 = t5.Result;
           // Console.WriteLine(kq4);
           // Console.WriteLine(kq5);
           

            //TH2: async/await có kiểu trả về 

            var task = GetWeb("https://xuanthulab.net/");
            string content = await task;
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
