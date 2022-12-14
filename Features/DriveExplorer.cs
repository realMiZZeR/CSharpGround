using System;
using System.IO;

namespace CSharpGround.Features
{
    public class DriveExplorer : Feature
    {
        public override int Id => 1;
        public override string Name => "Drive Explorer";

        public override void Show()
        {
            Console.WriteLine("Enter directory path:");

            string dirname = Console.ReadLine();

            var directory = new DirectoryInfo(dirname);

            if (directory.Exists)
            {
                ShowFolderInfo(directory, 0);

                Console.WriteLine("\n////////////////////////////////");
                Console.WriteLine("/// That's all :)");
                Console.WriteLine("////////////////////////////////");
            }
            else
            {
                Console.WriteLine("Entered a wrong path, try write again\n");
                Show();
            }
        }
        private void AddSpaces(int spacesCount)
        {
            for (int i = 0; i < spacesCount; i++)
                Console.Write(" ");
        }
        private void ShowFilesInFolder(DirectoryInfo directory, int spacesCount)
        {
            try
            {
                FileInfo[] files = directory.GetFiles();

                for (int i = 0; i < files.Length; i++)
                {
                    AddSpaces(spacesCount);

                    Console.WriteLine(" " + files[i].Name);
                }
            }
            catch
            {
                AddSpaces(spacesCount);
                Console.WriteLine(" Access denied");
            }
        }

        private void ShowFolderInfo(DirectoryInfo directory, int level)
        {
            try
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    AddSpaces(level);
                    Console.WriteLine(dirs[i].Name);

                    ShowFilesInFolder(dirs[i], level + 1);

                    // recursion
                    ShowFolderInfo(dirs[i], level + 1);
                }
            }
            catch (UnauthorizedAccessException error)
            {
                AddSpaces(level);
                Console.WriteLine("You haven't permission to the folder " + error.Source);
            }
        }

        #region Unused
        DriveInfo[] unused_drives = DriveInfo.GetDrives();
        private long unused_ConvertToGB(long size) => size / 1000 / 1000 / 1000;
        private void unused_GetDriveInfo(DriveInfo drive)
        {
            Console.WriteLine("Название диска: " + drive.Name);
            Console.WriteLine("Тип: " + drive.DriveType);

            if (drive.IsReady)
            {
                Console.WriteLine("Объём диска: " + unused_ConvertToGB(drive.TotalSize) + "GB");
                Console.WriteLine("Доступно места: " + unused_ConvertToGB(drive.AvailableFreeSpace) + "GB");
                Console.WriteLine("Метка тома: " + drive.VolumeLabel);
            }
        }
        #endregion
    }
}