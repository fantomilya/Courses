using System.Drawing;
using System.Windows.Forms;

namespace FileManager
{
    partial class Form1
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
            this.tvLeft = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btDeleteChecked = new System.Windows.Forms.Button();
            this.btCopyChecked = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvLeft
            // 
            this.tvLeft.CheckBoxes = true;
            this.tvLeft.ContextMenuStrip = this.contextMenuStrip1;
            this.tvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLeft.LabelEdit = true;
            this.tvLeft.Location = new System.Drawing.Point(3, 3);
            this.tvLeft.Name = "tvLeft";
            this.tvLeft.Size = new System.Drawing.Size(794, 409);
            this.tvLeft.TabIndex = 0;
            this.tvLeft.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvLeft_BeforeLabelEdit);
            this.tvLeft.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvLeft_AfterLabelEdit);
            this.tvLeft.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.tvLeft.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.tvLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.tvLeft.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.tvLeft.DoubleClick += new System.EventHandler(this.tvLeft_DoubleClick);
            this.tvLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvLeft_KeyUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiPaste,
            this.tsmiDelete,
            this.tsmiCut,
            this.tsmiRename,
            this.tsmiRefresh,
            this.tsmiProperties});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 158);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tvLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.btDeleteChecked);
            this.flowLayoutPanel1.Controls.Add(this.btCopyChecked);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 418);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Операции с отмеченными";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvLeft;
        private TableLayoutPanel tableLayoutPanel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiCopy;
        private ToolStripMenuItem tsmiPaste;
        private ToolStripMenuItem tsmiDelete;
        private ToolStripMenuItem tsmiCut;
        private ToolStripMenuItem tsmiRename;
        private ToolStripMenuItem tsmiProperties;
        private ToolStripMenuItem tsmiRefresh;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Button btDeleteChecked;
        private Button btCopyChecked;
    }
}

