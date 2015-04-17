using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NETTravel.DataObjects
{
    public class UsingLocalVariableInCallbackCode
    {
        public static void Test(int numToDo)
        {
            int[] squares = new int[numToDo];
            AutoResetEvent done = new AutoResetEvent(false);

            for (int n = 0; n < squares.Length; n++)
            {
                ThreadPool.QueueUserWorkItem(
                    obj =>
                    {
                        int num = (int)obj;
                        squares[num] = num * num;
                        Thread.Sleep(2000);
                        if (Interlocked.Decrement(ref numToDo) == 0)
                            done.Set();
                    }, n);
            }

            done.WaitOne();

            string result = "";
            for (int n = 0; n < squares.Length; n++)
            {
                result += string.Format("Index {0}, Square = {1}\n", n, squares[n]);
            }

            System.Windows.Forms.MessageBox.Show(result);
        }
    }
}
