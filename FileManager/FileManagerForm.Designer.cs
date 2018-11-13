using System.Windows.Forms;

namespace FileManager
{
    partial class FileManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvFileBrowser = new System.Windows.Forms.TreeView();
            this.cmsActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flpButtonsForCheckedNodes = new System.Windows.Forms.FlowLayoutPanel();
            this.lbCheckedButtons = new System.Windows.Forms.Label();
            this.btDeleteChecked = new System.Windows.Forms.Button();
            this.btCopyChecked = new System.Windows.Forms.Button();
            this.cmsActions.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.flpButtonsForCheckedNodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFileBrowser
            // 
            this.tvFileBrowser.CheckBoxes = true;
            this.tvFileBrowser.ContextMenuStrip = this.cmsActions;
            this.tvFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFileBrowser.LabelEdit = true;
            this.tvFileBrowser.Location = new System.Drawing.Point(3, 3);
            this.tvFileBrowser.Name = "tvFileBrowser";
            this.tvFileBrowser.Size = new System.Drawing.Size(794, 444);
            this.tvFileBrowser.TabIndex = 0;
            this.tvFileBrowser.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvFileBrowser_BeforeLabelEdit);
            this.tvFileBrowser.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvFileBrowser_AfterLabelEdit);
            this.tvFileBrowser.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvFileBrowser_AfterCheck);
            this.tvFileBrowser.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFileBrowser_BeforeExpand);
            this.tvFileBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFileBrowser_AfterSelect);
            this.tvFileBrowser.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFileBrowser_NodeMouseClick);
            this.tvFileBrowser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvFileBrowser_KeyUp);
            // 
            // cmsActions
            // 
            this.cmsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiPaste,
            this.tsmiDelete,
            this.tsmiCut,
            this.tsmiRename,
            this.tsmiRefresh,
            this.tsmiProperties});
            this.cmsActions.Name = "contextMenuStrip1";
            this.cmsActions.Size = new System.Drawing.Size(162, 158);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(161, 22);
            this.tsmiCopy.Text = "Копировать";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Enabled = false;
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(161, 22);
            this.tsmiPaste.Text = "Вставить";
            this.tsmiPaste.Click += new System.EventHandler(this.tsmiPaste_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(161, 22);
            this.tsmiDelete.Text = "Удалить";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiCut
            // 
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(161, 22);
            this.tsmiCut.Text = "Вырезать";
            this.tsmiCut.Click += new System.EventHandler(this.tsmiCut_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(161, 22);
            this.tsmiRename.Text = "Переименовать";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(161, 22);
            this.tsmiRefresh.Text = "Обновить";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiProperties
            // 
            this.tsmiProperties.Name = "tsmiProperties";
            this.tsmiProperties.Size = new System.Drawing.Size(161, 22);
            this.tsmiProperties.Text = "Свойства";
            this.tsmiProperties.Click += new System.EventHandler(this.tsmiProperties_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tvFileBrowser, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.flpButtonsForCheckedNodes, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // flpButtonsForCheckedNodes
            // 
            this.flpButtonsForCheckedNodes.Controls.Add(this.lbCheckedButtons);
            this.flpButtonsForCheckedNodes.Controls.Add(this.btDeleteChecked);
            this.flpButtonsForCheckedNodes.Controls.Add(this.btCopyChecked);
            this.flpButtonsForCheckedNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtonsForCheckedNodes.Location = new System.Drawing.Point(3, 453);
            this.flpButtonsForCheckedNodes.Name = "flpButtonsForCheckedNodes";
            this.flpButtonsForCheckedNodes.Size = new System.Drawing.Size(794, 1);
            this.flpButtonsForCheckedNodes.TabIndex = 1;
            // 
            // lbCheckedButtons
            // 
            this.lbCheckedButtons.Location = new System.Drawing.Point(3, 0);
            this.lbCheckedButtons.Name = "lbCheckedButtons";
            this.lbCheckedButtons.Size = new System.Drawing.Size(139, 23);
            this.lbCheckedButtons.TabIndex = 3;
            this.lbCheckedButtons.Text = "Операции с отмеченными";
            this.lbCheckedButtons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btDeleteChecked
            // 
            this.btDeleteChecked.Location = new System.Drawing.Point(148, 3);
            this.btDeleteChecked.Name = "btDeleteChecked";
            this.btDeleteChecked.Size = new System.Drawing.Size(131, 23);
            this.btDeleteChecked.TabIndex = 0;
            this.btDeleteChecked.Text = "Удалить";
            this.btDeleteChecked.UseVisualStyleBackColor = true;
            this.btDeleteChecked.Click += new System.EventHandler(this.btDeleteChecked_Click);
            // 
            // btCopyChecked
            // 
            this.btCopyChecked.Location = new System.Drawing.Point(285, 3);
            this.btCopyChecked.Name = "btCopyChecked";
            this.btCopyChecked.Size = new System.Drawing.Size(91, 23);
            this.btCopyChecked.TabIndex = 1;
            this.btCopyChecked.Text = "Скопировать";
            this.btCopyChecked.UseVisualStyleBackColor = true;
            this.btCopyChecked.Click += new System.EventHandler(this.btCopyChecked_Click);
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FileManagerForm";
            this.Text = "FileManagerForm";
            this.Load += new System.EventHandler(this.FileManagerForm_Load);
            this.cmsActions.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.flpButtonsForCheckedNodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvFileBrowser;
        private TableLayoutPanel tableLayoutPanel;
        private ContextMenuStrip cmsActions;
        private ToolStripMenuItem tsmiCopy;
        private ToolStripMenuItem tsmiPaste;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripMenuItem tsmiCut;
        private ToolStripMenuItem tsmiRename;
        private ToolStripMenuItem tsmiProperties;
        private ToolStripMenuItem tsmiRefresh;
        private FlowLayoutPanel flpButtonsForCheckedNodes;
        private Label lbCheckedButtons;
        private Button btDeleteChecked;
        private Button btCopyChecked;
    }
}

