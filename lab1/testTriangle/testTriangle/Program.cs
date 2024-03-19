using System.Diagnostics;
using System.IO;
using System.Linq;

namespace testTriangle
{
    public class Program
    {
        private static Process GetTriangleProcess(string argsTriangle)
        {
            const string pathTriangleExe = "C:\\volgatech\\kk\\lab1\\triangle\\triangle\\bin\\Debug\\triangle.exe";

            var triangleProcess = new Process();

            triangleProcess.StartInfo.FileName = pathTriangleExe;
            triangleProcess.StartInfo.UseShellExecute = false;
            triangleProcess.StartInfo.RedirectStandardInput = true;
            triangleProcess.StartInfo.RedirectStandardError = true;
            triangleProcess.StartInfo.RedirectStandardOutput = true;
            triangleProcess.StartInfo.CreateNoWindow = true;
            triangleProcess.StartInfo.Arguments = argsTriangle;

            return triangleProcess;
        }

        private static string[] GetTestFile()
        {
            const string path = "C:\\volgatech\\kk\\lab1\\testFile\\test.txt";
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Не найден файл {path}");
            }

            return File.ReadAllLines(path);
        }

        private static string GetArgsTriangle(string testLine)
        {
            return string.Join(" ", testLine.Split(' ').Take(3));
        }

        private static string GetTriangleType(string testLine)
        {
            return string.Join(" ", testLine.Split(' ').Skip(3));
        }

        private static void WriteResult(StreamWriter outFile, string triangleType, string expectedTriangleType)
        {
            if (triangleType == expectedTriangleType)
            {
                outFile.WriteLine("success");
            }
            else
            {
                outFile.WriteLine("error");
            }
        }
        
        public static void Main(string[] args)
        {
            const string pathFile = "C:\\volgatech\\kk\\lab1\\testFile\\result.txt";
            
            var testList = GetTestFile();
            var outFile = new StreamWriter(pathFile);
            
            foreach (var test in testList)
            {
                var argsTriangle = GetArgsTriangle(test);
                var expectedTriangleType = GetTriangleType(test);
            
                var triangleProcess = GetTriangleProcess(argsTriangle);
                triangleProcess.Start();
        
                string triangleType = triangleProcess.StandardOutput.ReadToEnd().Trim();
                WriteResult(outFile, triangleType, expectedTriangleType);
            
                triangleProcess.WaitForExit();
            }
            
            outFile.Close();
        }
    }
}