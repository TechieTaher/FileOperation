using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace FileOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==3)
            {
                Concat(args[0], args[1], args[2]);
            }
            Console.WriteLine("Welcome To file Operation");
            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Copy a File");
                Console.WriteLine("2) Rename a File");
                Console.WriteLine("3) Concatenate two files");
                Console.WriteLine("4) Create a file");
                Console.WriteLine("5) Display contents of a file");
                Console.WriteLine("6) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        {
                            Console.Write("Enter File Name : ");
                            string FileName = Console.ReadLine().Trim();
                            Console.Write("Enter File Path : ");
                            string FilePath = Console.ReadLine().Trim();
                            Console.Write("Enter Path in which u want to copy : ");
                            string TargetPath = Console.ReadLine().Trim();
                            if (Directory.Exists(FilePath)&& File.Exists(Path.Combine(FilePath,FileName)))
                            {
                                Directory.CreateDirectory(TargetPath);
                                File.Copy(Path.Combine(FilePath, FileName), Path.Combine(TargetPath, FileName), true);
                            }
                            else
                            {
                                Console.WriteLine("path or file does not exist");
                            }
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter Old File Name : ");
                            string OldFileName = Console.ReadLine().Trim();
                            Console.Write("Enter File Path : ");
                            string FilePath = Console.ReadLine().Trim();
                            Console.Write("Enter New File Name : ");
                            string NewFileName = Console.ReadLine().Trim();
                            FileSystem.RenameFile(Path.Combine(FilePath,OldFileName),NewFileName);
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Enter First File Path with Name : ");
                            string FirstFile= Console.ReadLine().Trim();
                            Console.Write("Enter Secound File Path with Name  : ");
                            string SecoundFile = Console.ReadLine().Trim();
                            Console.Write("Enter Merged File Name : ");
                            string MergedFileName = Console.ReadLine().Trim();
                            Concat(FirstFile, SecoundFile, MergedFileName);
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Enter File Name : ");
                            string FileName = Console.ReadLine().Trim();
                            Console.Write("Enter File Path : ");
                            string FilePath = Console.ReadLine().Trim();
                            File.Create(Path.Combine(FilePath, FileName));
                            Console.WriteLine("File Created");
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Enter File Name : ");
                            string FileName = Console.ReadLine().Trim();
                            Console.Write("Enter File Path : ");
                            string FilePath = Console.ReadLine().Trim();
                            StreamReader file =new StreamReader(Path.Combine(FilePath,FileName));
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                            file.Close();
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("please enter correct option");
                        break;
                }
            }
        }
        public static void Concat(string firstFile, string secoundFile, string mergedFileName)
        {
            string TargetPath = Path.GetDirectoryName(firstFile);
            string FirstFileText = File.ReadAllText(firstFile);
            string SecoundFileText = File.ReadAllText(secoundFile);
            //File.Create(Path.Combine(TargetPath, mergedFileName));
            File.WriteAllText(Path.Combine(TargetPath, mergedFileName), FirstFileText +"\n"+ SecoundFileText);
        }
    }
}
