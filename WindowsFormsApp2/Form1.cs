using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    [Serializable]
    public partial class Form1 : Form
    {
        public List<Row> rows = new List<Row>();
        public List<TextBox> cars = new List<TextBox>();
        public Random rand = new Random();
        public CancellationTokenSource cts = new CancellationTokenSource();
        public System.Drawing.Size minSizeDefault = new System.Drawing.Size(423, 420);
        public Form1()
        {
            InitializeComponent();
            dgvResults.AutoGenerateColumns = true;
            dgvResults.DataSource = new BindingSource() { DataSource = rows };
            cars.AddRange(new[] { tbCar1, tbCar2, tbCar3 });
        }
        private void Do(Delegate d, params object[] args)
        {
            if (d.Target is Control c && c.InvokeRequired)
                Invoke(d, args);
            else
                d.DynamicInvoke(args);
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            foreach (var c in cars)
                Task.Factory.StartNew(() => Do(new Action<TextBox, CancellationToken>(Move), c, cts.Token), cts.Token);

            btPause.Enabled = true;
            btStop.Enabled = true;
            btStart.Enabled = false;
        }
        public async new void Move(TextBox t, CancellationToken ct)
        {
            while (t.Location.X + t.Size.Width < tbFinish.Location.X)
                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();
                else
                {
                    t.Location = new System.Drawing.Point(t.Location.X + rand.Next(5), t.Location.Y);
                    await Task.Delay(30);
                }

            lock (rows)
            {
                if (rows.Any() && rows.Last() is Row r && r.Third is null)
                {
                    if (r.First is null)
                        r.First = t.Tag.ToString();
                    else if (r.Second is null)
                        r.Second = t.Tag.ToString();
                    else if (r.Third is null)
                    {
                        r.Third = t.Tag.ToString();
                        btPause.Enabled = false;
                        MinimumSize = Size;
                        MaximumSize = Size;
                    }
                }
                else
                    rows.Add(new Row(t.Tag.ToString(), null, null));

                dgvResults.DataSource = new BindingSource() { DataSource = rows };
            }
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            btStart.Enabled = true;
            btStop.Enabled = true;
            btPause.Enabled = false;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            foreach (var c in cars)
                c.Location = new System.Drawing.Point(c.Margin.Left, c.Location.Y);

            MinimumSize = minSizeDefault;
            MaximumSize = new System.Drawing.Size(0, 0);
            btStart.Enabled = true;
            btPause.Enabled = false;
            btStop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var file = new FileInfo("tmp.txt");
            if (file.Exists && MessageBox.Show("Восстановить состояние?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var fs = file.OpenRead();
                var f = (new BinaryFormatter().Deserialize(fs)) as Form1;
                cars = f.cars;
                rows = f.rows;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var file = new FileInfo("tmp.txt");
            var fs = file.Exists ? file.OpenRead() : file.Create();

            new BinaryFormatter().Serialize(fs, this);
        }
    }

    public class Row
    {
        public Row(string first, string second, string third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
    }
}
