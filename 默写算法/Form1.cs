using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 默写算法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            冒泡排序();
        }

        private void  冒泡排序()
        {
            int[] data1 = new int[6] { 23, 12, 14, 19, 01, 02 };
            for(int i = 0; i < data1.Length; i++)
            {
                for(int j = i+1; j< data1.Length; j++)
                {
                    if(data1[j] < data1[i])
                    {
                        int temp = data1[j];
                        data1[j] = data1[i];
                        data1[i] = temp;
                    }
                }  
            }
            richTextBox1.Text = "";
            for(int i = 0; i < data1.Length; i++)
            {
                richTextBox1.Text += data1[i] + "，";
            }
        }

        private void 操作顺序表()
        {
            try
            {
                SLDS<int> sLDS = new SLDS<int>(20);
                sLDS.Append(1);
                sLDS.Append(2);
                sLDS.Append(4);
                int iLocate = sLDS.Locate(4);
                sLDS.Insert(3, iLocate);
                sLDS.Delete(4);
                sLDS.Delete(5); //删除不存在的元素5
            }
            catch(Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            操作顺序表();
        }
    }

    public interface iSequenceListClass<T>
    {
        //附加操作
        void Append(T item);
        //插入
        void Insert(T item, int i);
        //删除
        void Delete(T item);
        //查找
        int Locate(T item);
        //求长度
        int GetLength();
        //是否为空
        bool IsEmpty();
        //判断线性表是否为满
        bool IsFull();
        //取表元
        T GetElem(int i);
        //清除
        //void Clear();
    }

    public class SLDS<T>:iSequenceListClass<T> where T:struct
    {
        T[] data;
        /// <summary>
        /// 顺序表容量
        /// </summary>
        int maxSize;
        //最后一个数据元素位置
        int last;
        public int Length
        { get { return GetLength(); } }

        private SLDS()
        { }
        public SLDS(int size)
        {
            maxSize = size;
            data = new T[maxSize];
            last = -1;
        }

        public T this[int index]
        {
            get
            {
                //if(!IsEmpty() && maxSize > 0)
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public void Append(T item)
        {
            if(IsFull())
            {
                throw new Exception("抱歉！顺序表已满！");
            }
            else
            {
                data[++last] = item;
            }
        }

        public void Delete(T item)
        {
            for(int i=Locate(item); i <= last; i++)
            {
                data[i] = data[i + 1];
            }
            last--;
        }

        public T GetElem(int i)
        {
            if(!IsEmpty() && 0 < i && i <= last)
            {
                return data[i];
            }
            else 
            {
                throw new Exception(string.Format("获取数据的位置{0}错误，不允许！", i));
            }
        }

        public int GetLength()
        {
            return last+1;
        }

        //UNTest__
        public void Insert(T item, int i)
        {
            if(IsFull())
            {
                throw new Exception("插入失败！顺序表已满！");
            }
            if(i >= last + 2)
            {
                throw new Exception(string.Format("插入位置请选择小于{0}的位置", last + 2));
            }
            if(i < 0)
            {
                throw new Exception("插入位置不合法！");
            }
            if(i == last + 1)
            {
                Append(item);
                last++;
            }
            else
            {
                //将在插入点（含）的后面元素都后移
                for(int k=last; k>= i; k--)
                {
                    data[k + 1] = data[k];
                }
                data[i] = item;
                last++;
            }
        }

        public bool IsEmpty()
        {
            return -1 == last;
        }

        public bool IsFull()
        {
            if(last >= maxSize)
            {
                return true;
            }
            return false;
        }

        public int Locate(T item)
        {
            int j = maxSize + 1;
            for(int i = 0; i <= last; i++)
            {
                if(item.Equals(data[i]))
                {
                    j = i;
                }
            }
            if(j != maxSize + 1)
            {
                return j;
            }
            else
            {
                throw new Exception("抱歉！未找到！");
            }
        }

        public void Clear()
        {
            last = -1;
        }
    }
}
