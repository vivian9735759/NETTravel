using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETTravel.DataObjects
{
    public struct ValObj
    {
        private int m_x, m_y;

        public ValObj(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public void Change(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}\n", m_x, m_y);
        }
    }

    public interface IChangedBoxedValObj
    {
        void Change(int xi, int y);
    }

    public struct ValObjFromI : IChangedBoxedValObj
    {
        private int m_x, m_y;

        public ValObjFromI(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public void Change(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}\n", m_x, m_y);
        }

        public override int GetHashCode()
        {
            return m_x.GetHashCode();

        }
    }

    public static class RefVSVal
    {
        public static void Test()
        {
            // Test un-box
            string result = string.Empty;

            ValObj vo = new ValObj(2, 2);
            result += vo.ToString();

            vo.Change(3, 3);
            result += vo.ToString();

            Object o = vo;
            result += o.ToString();

            ((ValObj)o).Change(5, 5); 
            result += o.ToString(); // 3, 3 still, as un-box o to a temp ValObj, then make the update, actually o is not changed

            System.Windows.Forms.MessageBox.Show(result);

            // Test box
            result = string.Empty;

            ValObjFromI vi = new ValObjFromI(1, 1);
            result += vi;

            vi.Change(2, 2);
            result += vi;

            object ot = vi;
            result += ot;

            ((ValObjFromI)ot).Change(3, 3); // 2, 2 still, as un-box to a temp ValObjFromI, then make the update, actually it is not changed
            result += ot;

            ((IChangedBoxedValObj)vi).Change(4, 4); // 2, 2 still, as box to interface, then make the update, actually it is not changed
            result += vi;

            ((IChangedBoxedValObj)ot).Change(5, 5);
            result += ot;

            System.Windows.Forms.MessageBox.Show(result);
        }
    }
}
