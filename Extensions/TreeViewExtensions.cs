using System.IO;
using System.Windows.Forms;

namespace Extensions
{
    public static class TreeViewExtensions
    {
        public static string GetPath(this TreeNode n) => n.Parent != null ? Path.Combine(n.Parent.GetPath(), n.Text) : n.Text;
        public static string GetFolderPath(this TreeNode n) => Path.GetDirectoryName(n.GetPath() + "\\");
    }
}
