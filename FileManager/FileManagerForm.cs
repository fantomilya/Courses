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
    public partial class FileManagerForm : Form
    {
        private Random _rand = new Random();
        private TreeNode _copyNode;
        /*ProgressBar pb = new ProgressBar
        {
            Style = ProgressBarStyle.Marquee,
            MarqueeAnimationSpeed = 500
        };*/
        public FileManagerForm()
        {
            InitializeComponent();
            ImageList imageList = new ImageList();
            imageList.Images.Add("folder", Properties.Resources.folder);
            imageList.Images.Add("file", Properties.Resources.file);
            imageList.Images.Add("folder_declined", Properties.Resources.folder_declined);
            tvFileBrowser.ImageList = imageList;
        }

        #region events
        private void FileManagerForm_Load(object sender, EventArgs e)
        {
            tvFileBrowser.Nodes.AddRange(DriveInfo.GetDrives().Where(p => p.IsReady && p.DriveType == DriveType.Fixed).Select(p => new TreeNode(p.Name)).ToArray());

            foreach (TreeNode n in tvFileBrowser.Nodes)
                LoadSubLevelAsync(n);
        }

        private void tvFileBrowser_AfterSelect(object sender, TreeViewEventArgs e) => 
            Text = e.Node.GetPath();
        private void tvFileBrowser_AfterCheck(object sender, TreeViewEventArgs e) => 
            SetSubnodesChecked(e.Node, e.Node.Checked);
        private void tvFileBrowser_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode n in e.Node.Nodes)
                LoadSubLevelAsync(n);
        }
        private void tvFileBrowser_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!e.CancelEdit && e.Label != null && e.Node.Text != e.Label)
                RenameAsync(e.Node, e.Label);
        }
        private void tvFileBrowser_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (GetNodeType(e.Node).In(NodeType.Drive, NodeType.System_Folder, NodeType.Unknown))
                e.CancelEdit = true;
        }
        private void tvFileBrowser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                e.Node.TreeView.SelectedNode = e.Node;
        }
        private void tvFileBrowser_KeyUp(object sender, KeyEventArgs e)
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

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            _copyNode = tvFileBrowser.SelectedNode;
            tsmiPaste.Enabled = true;
        }
        private void tsmiPaste_Click(object sender, EventArgs e) => 
            PasteAsync(_copyNode, tvFileBrowser.SelectedNode);
        private void tsmiRefresh_Click(object sender, EventArgs e) => 
            LoadSubLevelAsync(tvFileBrowser.SelectedNode.Parent ?? tvFileBrowser.SelectedNode, true);
        private void tsmiDelete_Click(object sender, EventArgs e) => 
            DeleteAsync(tvFileBrowser.SelectedNode);
        private void tsmiCut_Click(object sender, EventArgs e)
        {
        }
        private void tsmiRename_Click(object sender, EventArgs e) => 
            tvFileBrowser.SelectedNode.BeginEdit();
        private void tsmiProperties_Click(object sender, EventArgs e) => 
            ShowPropertiesAsync(tvFileBrowser.SelectedNode);

        private void btDeleteChecked_Click(object sender, EventArgs e)
        {

        }
        private void btCopyChecked_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void FillRand(TreeView tv)
        {
            for (int i = 1; i < _rand.Next(6, 16); i++)
                FillRand(tv.Nodes.Add(i.ToString()), _rand.Next(7));
        }
        private void FillRand(TreeNode n, int depth)
        {
            if (depth != 0)
                for (int i = 1; i < _rand.Next(16); i++)
                    FillRand(n.Nodes.Add(n.Text + '/' + i.ToString()), depth - 1);
        }

        private void SetSubnodesChecked(TreeNode n, bool isChecked = true)
        {
            foreach (TreeNode c in n.Nodes)
                c.Checked = isChecked;
        }

        private long GetSize(TreeNode node) => GetNodeType(node) == NodeType.File
                                                ? new FileInfo(node.GetPath()).Length
                                                : new DirectoryInfo(node.GetPath()).GetAllFiles().Sum(p => p.Length);
        private async void ShowPropertiesAsync(TreeNode node)
        {
            string properties = $"Название: {node.Text}\nПолный путь: {node.GetPath()}";

            if (GetNodeType(node) == NodeType.File)
            {
                var fi = new FileInfo(node.GetPath());
                properties += $"\nВремя создания: {fi.CreationTime}\nРазмер: {fi.Length} byte";
            }
            else if (GetNodeType(node) == NodeType.Folder)
            {
                var di = new DirectoryInfo(node.GetPath());
               // pb.Show();
                properties += $"\nВремя создания: {di.CreationTime}\nРазмер: { await Task.Factory.StartNew(() => GetSize(node)):N0} byte";
                //pb.Hide();
            }
            MessageBox.Show(properties, "Свойства", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<TreeNodeCollection> LoadSubLevelAsync(TreeNode node, bool refresh = false, bool loadExpanded = true)
        {
            if (refresh)
                node.Nodes.Clear();

            if (node.Nodes.Count > 0)
                return node.Nodes;

            var nodes = await Task.Factory.StartNew(new Func<List<TreeNode>>(() => LoadSubLevel(node)));
            node.Nodes.AddRange(nodes.ToArray());

            if (loadExpanded)
                foreach (TreeNode n in node.Nodes.Cast<TreeNode>().Where(p => p.IsExpanded || p.Parent.IsExpanded))
                    LoadSubLevelAsync(n, true);

            return node.Nodes;
        }
        private List<TreeNode> LoadSubLevel(TreeNode n)
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

        private async void PasteAsync(TreeNode node, TreeNode destinationNode)
        {
            var newNodeName = await Task.Factory.StartNew(() => Paste(node, destinationNode));

            if (!string.IsNullOrEmpty(newNodeName))
            {
                if (GetNodeType(destinationNode) == NodeType.File)
                    destinationNode = destinationNode.Parent;

                var newNode = _copyNode.Clone() as TreeNode;
                newNode.Text = newNodeName;
                destinationNode.Nodes.Add(newNode);
            }
        }
        private string Paste(TreeNode node, TreeNode destinationNode)
        {
            try
            {
                var destinationFolder = destinationNode.GetFolderPath();
                string newNodeName;
                if (GetNodeType(_copyNode) == NodeType.File)
                {
                    FileInfo fi = new FileInfo(_copyNode.GetPath());
                    newNodeName = fi.Name;

                    for (int copyNumber = 1; File.Exists(Path.Combine(destinationFolder, newNodeName)); copyNumber++)
                        newNodeName = fi.Name + $" ({copyNumber})";

                    fi.CopyTo(Path.Combine(destinationFolder, newNodeName));
                }
                else if (GetNodeType(_copyNode) == NodeType.Folder)
                {
                    DirectoryInfo di = new DirectoryInfo(_copyNode.GetPath());
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

        private async void DeleteAsync(TreeNode node)
        {
            if (await Task.Factory.StartNew(() => Delete(node)))
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

        private async void RenameAsync(TreeNode node, string newName)
        {
            var oldText = node.Text;
            var res = await Task.Factory.StartNew(() => Rename(node, newName));
            node.Text = res ? newName : oldText;
        }
        private bool Rename(TreeNode node, string newName)
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
        private enum NodeType
        {
            File,
            Folder,
            System_Folder,
            Drive,
            Unknown
        }
    }

}
