using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            ImageList myImageList = new ImageList();
            myImageList.Images.Add("folder", Properties.Resources.Folder_Generic_Green_icon);
            myImageList.Images.Add("file", Properties.Resources.Document_Blank_icon);
            myImageList.Images.Add("folder_selected", Properties.Resources.Folder_Checked_icon);
            myImageList.Images.Add("file_selected", Properties.Resources.File_Checked_icon);
            treeView1.ImageList = myImageList;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = GetPath(e.Node);
        }
        void InitDefault(TreeView tv)
        {
            for (int i = 1; i < rand.Next(6, 16); i++)
                fillRand(tv.Nodes.Add(i.ToString()), rand.Next(7));
        }
        void fillRand(TreeNode n, int depth)
        {
            if (depth != 0)
                for (int i = 1; i < rand.Next(16); i++)
                    fillRand(n.Nodes.Add(n.Text + '/' + i.ToString()), depth - 1);
        }
        void Check(TreeNode n, bool isChecked = true)
        {
            foreach (TreeNode c in n.Nodes)
                c.Checked = isChecked;
        }

        List<TreeNode> LoadNextLevel(object nObj)
        {
            var n = nObj as TreeNode;
            var l = 
            DirectoryInfo di = new DirectoryInfo(GetPath(n));
            if (!di.Exists || n.Nodes.Count > 0)
                return new List<TreeNode>();

            try
            {
                foreach (var directory in di.GetDirectories("*.*", SearchOption.TopDirectoryOnly))
                    n.Nodes.Add(directory.Name, directory.Name, "folder", "folder_selected").Checked = n.Checked;
            }
            catch (UnauthorizedAccessException)
            {

            }
            try
            {
                foreach (var file in di.GetFiles("*.*", SearchOption.TopDirectoryOnly))
                    n.Nodes.Add(file.Name, file.Name, "file", "file_selected").Checked = n.Checked;
            }
            catch (UnauthorizedAccessException)
            {

            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Check(e.Node, e.Node.Checked);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = GetPath(e.Node);
        }
        string GetPath(TreeNode n) => n.Parent != null? Path.Combine(GetPath(n.Parent), n.Text): n.Text;

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var d in DriveInfo.GetDrives().Where(p => p.IsReady && p.DriveType == DriveType.Fixed))
               treeView1.Nodes.Add(d.Name);

            treeView1.BeginUpdate();
            foreach (var n in treeView1.Nodes)
                Task.Factory.StartNew(new Action<object>(LoadNextLevel), n);

            treeView1.EndUpdate();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (var n in e.Node.Nodes)
                treeView1.BeginInvoke(new Action<TreeNode>(LoadNextLevel), n);
        }
    }
}
