using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
            OnMemoryValueChangedEvent += CalculatorForm_OnMemoryValueChangedEvent;
            _buttons.AddRange(this.ChildControls().OfType<Button>());
        }

        event EventHandler<double?> OnMemoryValueChangedEvent;

        private double? _memoryValue;
        public double? MemoryValue
        {
            get => _memoryValue;
            set
            {
                _memoryValue = value;
                OnMemoryValueChangedEvent(this, value);
            }

        }
        bool _newNumber = true;

        List<Button> _buttons = new List<Button>();
        Expression _ex = Expression.Constant(0D, typeof(double));
        MyExpressionVisitor _visitor = new MyExpressionVisitor();

        Expression Ex
        {
            get => _ex;
            set
            {
                _ex = value;
                var str = _visitor.GetStringRepresentation(_ex);
                tbOperations.Text = str == "0" ? string.Empty : str;
            }
        }

        private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e) =>
            _buttons.FirstOrDefault(p => p.Tag.ToString() == e.KeyChar.ToString().Replace(".", ","))?.PerformClick();

        private void NumButton_Click(object sender, EventArgs e)
        {
            if (_newNumber)
            {
                _newNumber = false;
                tbResult.Text = "";
            }

            var num = (sender as Button).Tag.ToString();
            if (("0" != num || "0" != tbResult.Text) && (num != "," || !tbResult.Text.Contains(",")))
                tbResult.Text += num;
        }

        private void AddOperation(string op, double value)
        {
            var valueAsExpression = Expression.Constant(value, typeof(double));
            if (op == " ")
                Ex = valueAsExpression;
            else if (op == "*")
                Ex = Expression.MultiplyChecked(Ex, valueAsExpression);
            else if (op == "/")
                Ex = Expression.Divide(Ex, valueAsExpression);
            else if (op == "+")
                Ex = Expression.AddChecked(Ex, valueAsExpression);
            else if (op == "-")
                Ex = Expression.Subtract(Ex, valueAsExpression);
        }

        string _lastOperation = " ";

        private void btBinaryOperation_Click(object sender, EventArgs e)
        {
            var op = (sender as Button).Tag.ToString();

            AddOperation(_lastOperation, tbResult.DoubleValue());

            tbOperations.Text += " " + op;
            _lastOperation = op;
            _newNumber = true;
        }

        private void btResult_Click(object sender, EventArgs e)
        {
            AddOperation(_lastOperation, tbResult.DoubleValue());
            tbResult.Text = Expression.Lambda<Func<double>>(Ex).Compile()().ToString();
            AddOperation(" ", 0);
            _lastOperation = " ";
            _newNumber = true;
        }

        private void btClear_Click(object sender, EventArgs e) => ClearResult();

        private void btBackspace_Click(object sender, EventArgs e)
        {
            if (tbResult.TextLength == 1)
                ClearResult();
            else
                tbResult.Text = tbResult.Text.CutRight(1);
        }

        private void CalculatorForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            AddOperation(" ", 0);
            _lastOperation = " ";
            ClearResult();
        }

        void ClearResult()
        {
            tbResult.Text = "0";
            _newNumber = true;
        }
        private void btUnaryOperation_Click(object sender, EventArgs e)
        {
            try
            {
                double res = tbResult.DoubleValue();
                if (ReferenceEquals(sender, btNegate))
                    res *= -1;
                else if (ReferenceEquals(sender, btSqrt))
                    res = Math.Sqrt(res);
                else if (ReferenceEquals(sender, btSquare))
                    res = res * res;
                else if (ReferenceEquals(sender, btInvert))
                    res = 1 / res;
                else if (ReferenceEquals(sender, btPercent))
                    res = res * 0.01;

                tbResult.Text = res.ToString();
            }
            catch (ArithmeticException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btMemoryRead_Click(object sender, EventArgs e)
        {
            tbResult.Text = MemoryValue.ToString();
        }

        private void btMemoryClear_Click(object sender, EventArgs e)
        {
            MemoryValue = null;
        }

        private void btMemoryAdd_Click(object sender, EventArgs e)
        {
            if (MemoryValue is null)
                MemoryValue = 0;

            MemoryValue += tbResult.DoubleValue();
        }

        private void btMemorySubtract_Click(object sender, EventArgs e)
        {
            if (MemoryValue is null)
                MemoryValue = 0;

            MemoryValue -= tbResult.DoubleValue();
        }

        private void btMemorySave_Click(object sender, EventArgs e)
        {
            MemoryValue = tbResult.DoubleValue();
        }

        private void CalculatorForm_OnMemoryValueChangedEvent(object sender, double? e)
        {
            toolTip1.RemoveAll();

            btMemoryRead.Enabled = btMemoryClear.Enabled = _memoryValue.HasValue;

            if (!_memoryValue.HasValue)
                return;

            foreach (var ctrl in new[] { btMemoryAdd, btMemoryClear, btMemoryRead, btMemorySave, btMemorySubtract })
                toolTip1.SetToolTip(ctrl, _memoryValue.Value.ToString("0.##"));
        }
    }
}
