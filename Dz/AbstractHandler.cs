using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Dz
{
    /*  Задание 1
        Создайте класс AbstractHandler.
        В теле класса создать методы void Open(), void Create(), void Chenge(), абстрактный void Save().
        Создать производные классы XMLHandler, TXTHandler, DOCHandler от базового класса
        AbstractHandler.
        Написать программу, которая будет выполнять определение документа и для каждого формата должны быть методы открытия, создания, редактирования, сохранения определенного формата документа. 
    */

    public abstract partial class AbstractHandler : Form
    {
        protected AbstractHandler() => InitializeComponent();

        protected string Type;
        private string _path;
        private bool _edited;

        private bool Edited
        {
            get => _edited;
            set
            {
                _edited = value;
                if (value && Text.Last() != '*')
                    Text += '*';
                else
                    Text = Text.TrimEnd('*');
            }
        }
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                Text = _path.Any() ? _path : $"Новый {Type} файл";
            }
        }

        private void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = $"{Type} (*.{Type})|*.{Type}"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.OpenFile() is Stream fs)
            {
                Path = openFileDialog.FileName;
                tb.Enabled = saveToolStripMenuItem.Enabled = true;
                using (StreamReader reader = new StreamReader(fs, Encoding.GetEncoding(1251)))
                    tb.Text = reader.ReadToEnd();

                Edited = false;
            }
        }

        private void Create()
        {
            tb.Clear();
            Path = string.Empty;
            Edited = false;
            tb.Enabled = saveToolStripMenuItem.Enabled = true;
        }
        public virtual void Save()
        {
            if (string.IsNullOrEmpty(Path))
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = $"{Type} (*.{Type})|*.{Type}",
                    AddExtension = true
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                    Path = sfd.FileName;
                else
                    return;
            }
            File.WriteAllText(Path, tb.Text, Encoding.GetEncoding(1251));
            Edited = false;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e) => Create();
        private void openToolStripMenuItem1_Click(object sender, EventArgs e) => Open();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => Save();
        private void AbstractHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Edited && MessageBox.Show("Сохранить изменения?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                try
                {
                    Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Не удалось сохранить файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
        }
        private void tb_TextChanged(object sender, EventArgs e) => Edited = true;
    }

    public class XmlHandler : AbstractHandler
    {
        public XmlHandler() => Type = "xml";

        public override void Save()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(tb.Text);
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.Message, "Неверный xml", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.Save();
        }
    }

    public class TxtHandler : AbstractHandler
    {
        public TxtHandler() => Type = "txt";
    }

    public class DocHandler : AbstractHandler
    {
        public DocHandler() => Type = "doc";
    }
}
