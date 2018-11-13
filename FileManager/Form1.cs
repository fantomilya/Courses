using Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
            myImageList.Images.Add("folder", Properties.Resources.folder);
            myImageList.Images.Add("file", Properties.Resources.file);
            myImageList.Images.Add("folder_declined", Properties.Resources.folder_declined);
            tvLeft.ImageList = myImageList;
        }
        #region events
        private void Form1_Load(object sender, EventArgs e)
        {
            tvLeft.Nodes.AddRange(DriveInfo.GetDrives().Where(p => p.IsReady && p.DriveType == DriveType.Fixed).Select(p => new TreeNode(p.Name)).ToArray());

            foreach (TreeNode n in tvLeft.Nodes)
                LoadSubLevelAsync(n);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = e.Node.GetPath();
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SetSubnodesChecked(e.Node, e.Node.Checked);
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode n in e.Node.Nodes)
                LoadSubLevelAsync(n);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = e.Node.GetPath();
        }

        #endregion

        void FillRand(TreeView tv)
        {
            for (int i = 1; i < rand.Next(6, 16); i++)
                FillRand(tv.Nodes.Add(i.ToString()), rand.Next(7));
        }
        void FillRand(TreeNode n, int depth)
        {
            if (depth != 0)
                for (int i = 1; i < rand.Next(16); i++)
                    FillRand(n.Nodes.Add(n.Text + '/' + i.ToString()), depth - 1);
        }

        void SetSubnodesChecked(TreeNode n, bool isChecked = true)
        {
            n.TreeView.BeginUpdate();

            foreach (TreeNode c in n.Nodes)
                c.Checked = isChecked;

            n.TreeView.EndUpdate();
        }
        async Task<TreeNodeCollection> LoadSubLevelAsync(TreeNode node, bool refresh = false)
        {
            if (refresh)
                node.Nodes.Clear();

            if (node.Nodes.Count > 0)
                return null;

            var nodes = await Task.Factory.StartNew(new Func<List<TreeNode>>(() => LoadSubLevel(node)));
            node.Nodes.AddRange(nodes.ToArray());

            foreach (TreeNode n in node.Nodes.Cast<TreeNode>().Where(p => p.IsExpanded || p.Parent.IsExpanded))
                LoadSubLevelAsync(n, true);

            return node.Nodes;
        }
        List<TreeNode> LoadSubLevel(TreeNode n)
        {
            DirectoryInfo di = new DirectoryInfo(n.GetPath());
            var nodes = new List<TreeNode>();

            if (!di.Exists)
                return nodes;

            var attr = di.Attributes;

            try
            {
                nodes.AddRange(di.GetDirectories("*.*", SearchOption.TopDirectoryOnly).Select(p => new TreeNode(p.Name) { Checked = n.Checked, ImageKey = p.Attributes.HasFlag(FileAttributes.System) ? "folder_declined" : "folder", SelectedImageKey = p.Attributes.HasFlag(FileAttributes.System) ? "folder_declined" : "folder" }));
                nodes.AddRange(di.GetFiles("*.*", SearchOption.TopDirectoryOnly).Select(p => new TreeNode(p.Name) { Checked = n.Checked, ImageKey = "file", SelectedImageKey = "file" }));
            }
            catch (UnauthorizedAccessException)
            {
            }

            return nodes;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                e.Node.TreeView.SelectedNode = e.Node;

        }
        TreeNode copyNode;
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            copyNode = tvLeft.SelectedNode;
            tsmiPaste.Enabled = true;
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            PasteAsync(copyNode, tvLeft.SelectedNode);
        }
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            LoadSubLevelAsync(tvLeft.SelectedNode.Parent ?? tvLeft.SelectedNode, true);
        }

        private string Paste(TreeNode node, TreeNode destinationNode)
        {
            try
            {
                var destinationFolder = destinationNode.GetFolderPath();
                string newNodeName;
                if (GetNodeType(copyNode) == NodeType.File)
                {
                    FileInfo fi = new FileInfo(copyNode.GetPath());
                    newNodeName = fi.Name;

                    for (int copyNumber = 1; File.Exists(Path.Combine(destinationFolder, newNodeName)); copyNumber++)
                        newNodeName = fi.Name + $" ({copyNumber})";

                    fi.CopyTo(Path.Combine(destinationFolder, newNodeName));
                }
                else if (GetNodeType(copyNode) == NodeType.Folder)
                {
                    DirectoryInfo di = new DirectoryInfo(copyNode.GetPath());
                    newNodeName = di.Name;
                    for (int copyNumber = 1; Directory.Exists(Path.Combine(destinationFolder, newNodeName)); copyNumber++)
                        newNodeName = di.Name + $" ({copyNumber})";

                    di.CopyTo(Path.Combine(destinationFolder, newNodeName));
                }
                else
                    return null;

                return newNodeName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async void PasteAsync(TreeNode node, TreeNode destinationNode)
        {
            var newNodeName = await Task.Factory.StartNew(() => Paste(node, destinationNode));

            if (!string.IsNullOrEmpty(newNodeName))
            {
                if (GetNodeType(destinationNode) == NodeType.File)
                    destinationNode = destinationNode.Parent;

                var newNode = copyNode.Clone() as TreeNode;
                newNode.Text = newNodeName;
                destinationNode.Nodes.Add(newNode);
            }
        }
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DeleteAsync(tvLeft.SelectedNode);
        }

        private async void DeleteAsync(TreeNode node)
        {
            var success = await Task.Factory.StartNew(() => Delete(node));
            if (success)
                node.Remove();
        }
        private bool Delete(TreeNode node)
        {
            if (MessageBox.Show($"Действительно удалить \"{node.Text}\"?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;

            try
            {
                if (GetNodeType(node) == NodeType.File)
                {
                    FileInfo fi = new FileInfo(node.GetPath());
                    fi.Delete();
                }
                else if (GetNodeType(node) == NodeType.Folder)
                {
                    DirectoryInfo di = new DirectoryInfo(node.GetPath());
                    di.Delete(true);
                }
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void tsmiCut_Click(object sender, EventArgs e)
        {
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            tvLeft.SelectedNode.BeginEdit();
        }
        async private void tsmiProperties_Click(object sender, EventArgs e)
        {
            var node = tvLeft.SelectedNode;
            string properties = $"Название: {node.Text}\nПолный путь: {node.GetPath()}";

            if (GetNodeType(node) == NodeType.File)
            {
                var fi = new FileInfo(node.GetPath());
                properties += $"\nВремя создания: {fi.CreationTime}\nРазмер: {fi.Length} byte";
            }
            else if (GetNodeType(node) == NodeType.Folder)
            {
                var di = new DirectoryInfo(node.GetPath());
                properties += $"\nВремя создания: {di.CreationTime}\nРазмер: {await GetSize(node):N0} byte";
            }
            MessageBox.Show(properties, "Свойства", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        async private Task<long> GetSize(TreeNode node)
        {
            if (GetNodeType(node) == NodeType.File)
                return new FileInfo(node.GetPath()).Length;

            var size = 0L;

            await LoadSubLevelAsync(node);
            List<Task<long>> tasks = new List<Task<long>>();

            foreach (TreeNode n in node.Nodes)
                if (GetNodeType(n) == NodeType.File)
                    size += new FileInfo(n.GetPath()).Length;
                else
                    tasks.Add(GetSize(n));

            return size + (await Task.WhenAll(tasks)).Sum();
        }

        private void tvLeft_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                tsmiCopy_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.X)
                tsmiCut_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.V)
                tsmiPaste_Click(sender, e);
            else if (e.KeyCode == Keys.Delete)
                tsmiDelete_Click(sender, e);
        }

        private void btDeleteChecked_Click(object sender, EventArgs e)
        {

        }

        private void btCopyChecked_Click(object sender, EventArgs e)
        {

        }

        private void tvLeft_DoubleClick(object sender, EventArgs e)
        {
        }
        async void RenameAsync(TreeNode node, string newName)
        {
            var oldText = node.Text;
            var res = await Task.Factory.StartNew(() => Rename(node, newName));
            node.Text = res ? newName : oldText;
        }
        bool Rename(TreeNode node, string newName)
        {
            try
            {
                if (GetNodeType(node) == NodeType.File)
                {
                    var fi = new FileInfo(node.GetPath());
                    fi.MoveTo(Path.Combine(fi.DirectoryName, newName));
                }
                else if (GetNodeType(node) == NodeType.Folder)
                {
                    var di = new DirectoryInfo(node.GetPath());
                    di.MoveTo(Path.Combine(di.Parent.FullName, newName));
                }
                else if (GetNodeType(node) == NodeType.System_Folder)
                    throw new IOException("Невозможно переименовать системную папку");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void tvLeft_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!e.CancelEdit && e.Label != null && e.Node.Text != e.Label)
                RenameAsync(e.Node, e.Label);
        }

        private void tvLeft_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (GetNodeType(e.Node).In(NodeType.Drive, NodeType.System_Folder, NodeType.Unknown))
                e.CancelEdit = true;
        }
        private NodeType GetNodeType(TreeNode node)
        {
            if (node.Parent is null)
                return NodeType.Drive;
            else if (node.ImageKey == "file")
                return NodeType.File;
            else if (node.ImageKey == "folder")
                return NodeType.Folder;
            else if (node.ImageKey == "folder_declined")
                return NodeType.System_Folder;
            else
                return NodeType.Unknown;
        }
    }
    enum NodeType
    {
        File,
        Folder,
        System_Folder,
        Drive,
        Unknown
    }
}
