using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        var nums = Console.ReadLine().Split(' ');
        for (int  i = 0; i < n; i++)
            sb.Append(Find(float.Parse(nums[i])) + " ");

        Console.WriteLine(sb.ToString().TrimEnd(' '));
    }
    public static int Find(float f)
    {
        int res = 0;
        int fact = 1;
        double pow = 1;
        while (pow >= fact)
        {
            res++;
            fact *= res;
            pow *= f;
        }

        return res;
    }
    //private void SetText(string text)
    //{
    //    // InvokeRequired required compares the thread ID of the
    //    // calling thread to the thread ID of the creating thread.
    //    // If these threads are different, it returns true.
    //    if (this.textBox1.InvokeRequired)
    //    {
    //        StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
    //        this.Invoke(d, new object[] { text });
    //    }
    //    else
    //    {
    //        this.textBox1.Text = text;
    //    }
    //}
}