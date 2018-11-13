using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class DirectoryExtensions
    {
        public static void CopyTo(this DirectoryInfo dir, string destDirName)
        {
            var dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);

            foreach (var file in dir.GetFiles())
                file.CopyTo(Path.Combine(destDirName, file.Name), false);

            foreach (DirectoryInfo subdir in dirs)
                subdir.CopyTo(Path.Combine(destDirName, subdir.Name));
        }
    }
}
