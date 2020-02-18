using System;
using System.IO;

namespace ChangeName
{
	class Program
	{
		private static Random rand = new Random();
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the path to the directory with the files:");
			string path = Console.ReadLine();

			if (File.Exists(path))
			{				
				FileProcessing(path, rand.Next(1, 999).ToString("000"));
			}
			else if (Directory.Exists(path))
			{
				DirectoryProcessing(path);
			}
			else
			{
				Console.WriteLine("{0} the path entered is not a valid file or directory.", path);
			}

			Console.WriteLine("Press any button to exit.");
			Console.ReadKey();
		}

		public static void DirectoryProcessing(string targetDirectory)
		{
			string[] fileEntries = Directory.GetFiles(targetDirectory);
			foreach (string fileName in fileEntries)
			{
				FileProcessing(fileName, rand.Next(1, 999).ToString("000"));
			}

			string[] subdirectoryItems = Directory.GetDirectories(targetDirectory);
			foreach (string subdirectory in subdirectoryItems)
			{
				DirectoryProcessing(subdirectory);
			}
		}

		public static void FileProcessing(string path, string salt = "")
		{
			int ind = path.LastIndexOf('\\');
			//File.Move(path, path.Insert(ind + 1, salt + "-"));
			Console.WriteLine("File Handlinged successfully '{0}'.", path.Insert(ind + 1, salt + "-"));
		}
	}
}
