using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bai_28_File_dic
{
    class Program
    {
        /* MỘT SỐ THUỘC TÍNH CỦA LỚP DRIVEINFO // import System.IO
         *      IsReady: true ổ đĩa ở trạng thái sẵn sàng 
         *      DriveType: Kiểu ổ đĩa : CDRom, Fixed, Network, NoRootDirectory, Ramm, Removable, Unknown.
         *      VolumeLabel: Nhãn đĩa
         *      DriveFormat: Chuổi cho biết định dạng đãi: NTFS, FAT32, FAT, devfs...
         *      AvailableFreeSpace : Số byte có hiệu lực còn trống
         *      TotalFreeSpace: Số byte còn trống
         *      TotalSize: Tổng số byte trên đĩa
         *      
         *      
         *      Lấy tất cả drive 
         *      DriveInfo[] allDrives = DriveInfo.GetDrives();
         *      
         * 
         */
        /*
            * LÀM VIỆC VỚI DIRECTORY- thư mục 
            *       Exists(string path): Kiểm tra xem thư mục có tồn tại hay không ( T/F)
            *       CreateDirectory(string Path) Tạo thư mục, trả về đổi tượng  System.IO.Directory chứa thông tin thư mục 
            *       Delete(string path): Xóa thư mục 
            *       GetFiles(string path) : Lấy các file trong thư mục 
            *       GetDirectories: Lấy các thư mục trong thư mục 
            *       Move(src, des): Di chuyển thư mục .
            *       ListFileDirectory(directory directory) thường được sử dụng để liệt kê tất cả các tệp và thư mục con trong một thư mục nhất định.
            */
        /*
         * LÀM VIỆC VỚI LỚP PATH - làm việc với đường dẫn.
         *          Path.DirectorySepareatorChar: Thuộc tính này chứa ký tự phân cách thư mục đặc trưng cho hệ điều hành hiện tại. Ví dụ, trên Windows, ký tự phân cách là \, trong khi trên Unix hoặc Linux, ký tự phân cách là /.
         *                      char separator = Path.DirectorySeparatorChar;
                                Console.WriteLine($"Directory Separator: {separator}");
         *          Path.PathSeparator: Thuộc tính này chứa ký tự được sử dụng để phân cách các đường dẫn trong danh sách đường dẫn môi trường. Trên Windows, ký tự phân cách là ;, trong khi trên Unix hoặc Linux, ký tự phân cách là :
         *                      char pathSeparator = Path.PathSeparator;
                                Console.WriteLine($"Path Separator: {pathSeparator}");
         *          Combine: Phương thức này được sử dụng để kết hợp nhiều thành phần đường dẫn lại với nhau thành một đường dẫn duy nhất. Nó sẽ tự động thêm các ký tự phân cách thích hợp giữa các thành phần.
         *                      string combinedPath = Path.Combine("folder1", "folder2", "file.txt");
                                Console.WriteLine($"Combined Path: {combinedPath}");
         *          ChangeExtension: Phương thức này được sử dụng để thay đổi phần mở rộng của tệp trong đường dẫn. Nếu phần mở rộng mới là null, phần mở rộng hiện tại sẽ bị loại bỏ.
         *                      string newPath = Path.ChangeExtension("file.txt", ".bak");
                                Console.WriteLine($"New Path: {newPath}");
         *          GetDirectoryName:Phương thức này được sử dụng để lấy phần đường dẫn thư mục của một đường dẫn tệp. Nó sẽ loại bỏ phần tên tệp và chỉ trả về phần đường dẫn thư mục.
         *                      string directoryName = Path.GetDirectoryName("C:\\folder1\\file.txt");
                                Console.WriteLine($"Directory Name: {directoryName}");
         *          GetExtension :Phương thức này được sử dụng để lấy phần mở rộng của một tệp từ đường dẫn.
         *                      string extension = Path.GetExtension("file.txt");
                                Console.WriteLine($"Extension: {extension}");
         *          GetFileName: Phương thức này được sử dụng để lấy phần tên tệp (bao gồm cả phần mở rộng) từ đường dẫn.
         *                      string fileName = Path.GetFileName("C:\\folder1\\file.txt");
                                Console.WriteLine($"File Name: {fileName}");
                    GetFullPath: trả về đường dẫn đầy đủ
                    GetRandomFilename: tạo file ngẫu nhiên 
                                var path = Path.GetRandomFileName()
         */

        /*
         * Làm việc với lớp FILE
         *          File.WriteAllText: hàm này tạo ra file mới (nếu đã tồn tại nó sẽ ghi đè) ghi vào nó một nội dung text, rồi đóng file đó luôn 
         *          File.AppendAllText(fileName,content): hàm này nối thêm text vào sau đoạn văn bản đã có 
         *          File.ReadAllLines: đọc text trong file 
         *          file.Move(oldFile, newFileChange)
         */


        /*LÀM VIỆC VỚI IO.STREAM: LUỒNG 
         *      CanRead : Cho biết stream hỗ trợ việc đọc hay không 
         *      CanWrite: Cho biết stream có hỗ trợ việc ghi hay không
         *      CanSeek: Cho biết stream có hỗ trợ dịch chuyển con trỏ hay không 
         *      CanTimeout: cho biết steam hỗ trợ dịch chuyển con trỏ hay không
         *      Length: Cho biết kích thước (byte) của stream.
         *      Position: Đọc hoặc thiết lập vị trí đọc ( thiết lập stream thì phải hỗ trợ seek)
         *      ReadTimeout: Đọc hoặc thiết lập giá trị (mili giấy) dành cho tác vụ đọc stream trước khi timeout phát sinh
         *      WriteTimeout : Ghi hoặc thiết lập giá trị (mili giây) danh cho tác vụ ghi stream trước khi timeout phát sinh
         *      
         * 
         */



        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //        Làm việc DriveInfo
            //driveinfo drive = new driveinfo("abc");
            //console.writeline($"dirve {drive.name}");
            //console.writeline($"drive type: {drive.drivetype}");
            //console.writeline($"label: {drive.volumelabel}");
            //console.writeline($"driveformat: {drive.driveformat}");


            // Làm việc với Directory 
            //string path = "sa";
            //Directory.CreateDirectory(path);
            //if (Directory.Exists(path))
            //{
            //    Console.WriteLine($"{path}- ton tai");
            //}
            //else
            //{
            //    Console.WriteLine($"{path}-- khong ton tai");
            //}
            //DriveInfo drive = new DriveInfo("D:\\OneDriver\\OneDrive - University of Technology and Education\\2024-2025 ki 5 124\\WEB_NANG_CAO\\WEB_NANG_CAO_LN\\bai_28_File_dic\\bin\\Debug\\sa");
            //Console.WriteLine($"Drive Name: {drive.Name}");
            //Console.WriteLine($"Drive Name: {drive.DriveFormat}");
            //Console.WriteLine($"Drive Name: {drive.DriveFormat}");

            //var files = Directory.GetFiles(path);
            //var directories = Directory.GetDirectories(path);
            //foreach(var file in files)
            //{
            //    Console.WriteLine(file);
            //}

            // làm việc với path 
            //var path = Path.Combine("Dir1", "dir2");
            //Console.WriteLine($"path =>{path}");
            //path = "linh.txt";
            //path = Path.ChangeExtension(path,"md");// đổi đuôi kiểu file
            //Console.WriteLine($"{path}");
            //Console.WriteLine($"GetExtension:trả về phần mở rộng {Path.GetExtension(path)}");



            // làm việc với file 
            //string fileName = " abc.txt";
            //string content = "Vui vẻ quả nhỉ";
            //File.WriteAllText(fileName, content);
            //File.AppendAllText(fileName, content);
            //var Lines = File.ReadAllLines(fileName);
            //foreach(var i in Lines)
            //{
            //    Console.WriteLine(i);
            //}
            //content = File.ReadAllText(fileName);
            //Console.WriteLine(content);



            // Đọc và ghi file 

            string path = "data.txt";
             var stream = new FileStream(path:path, FileMode.OpenOrCreate);
            // lưu dữ liệu 
            byte[] buffer = { 1, 2 ,3 };
        int offset = 0;
            int count = 3;
            stream.Write(buffer, offset,count);
           int sobyte= stream.Read(buffer, offset, count);
            Console.WriteLine(sobyte);


        }

    }
}
