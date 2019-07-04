using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace 深拷贝浅拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            #region//深克隆 浅克隆 MemberwiseClone() clone()

            //#region
            ////Animal a1 = new Dog(1, 2, 3, "A", "B");
            ////Console.WriteLine("Animal a1 's  members :" + a1.i + " " + a1.d + " " + a1.b + a1.s[0] + a1.s[1] + "<br/>");

            ////Animal a2;
            ////a2 = a1.Clone();
            ////Console.WriteLine("Animal a2的Members:" + a2.i + a2.d + a2.b + a2.s[0] + a2.s[1] + "<br/>");

            ////Console.WriteLine("do a1.i = 9;a1.s[0] = C" + "<br/>");
            ////a1.i = 9;
            ////a1.s[0] = "C";
            ////Console.WriteLine("Animal a1的Members:" + a1.i + a1.d + a1.b + a1.s[0] + a1.s[1] + "<br/>");
            ////Console.WriteLine("Animal a2的Members:" + a2.i + a2.d + a2.b + a2.s[0] + a2.s[1] + "<br/>");

            ////Console.WriteLine("do a2.i = 8;a2.s[1] =D" + "<br/>");
            ////a2.i = 8;
            ////a2.s[1] = "D";
            ////Console.WriteLine("Animal a1的Members:" + a1.i + a1.d + a1.b + a1.s[0] + a1.s[1] + "<br/>");
            ////Console.WriteLine("Animal a2的Members:" + a2.i + a2.d + a2.b + a2.s[0] + a2.s[1] + "<br/>");
            //#endregion

            #endregion

            #region//深克隆 ,自添加自写的深度克隆函数DeepClone
            //#region
            //Dog dog1 = new Dog(1, 2, 3, "A", "B");
            //Console.WriteLine("Dog dog1 's members :" + dog1.i + " " + dog1.d + " " + dog1.b + dog1.s[0] + dog1.s[1] + "<br/>");

            //Dog dog2 = dog1.DeepClone();
            //Console.WriteLine("Dog dog2的Members:" + dog2.i + dog2.d + dog2.b + dog2.s[0] + dog2.s[1] + "<br/>");

            //Console.WriteLine("===>>>Change dog1.i = 9;dog1.s[0] = C" + "<br/>");
            //dog1.i = 9;
            //dog1.s[0] = "C";
            //Console.WriteLine("Dog dog1 's members :" + dog1.i + " " + dog1.d + " " + dog1.b + dog1.s[0] + dog1.s[1] + "<br/>");
            //Console.WriteLine("Dog dog2的Members:" + dog2.i + dog2.d + dog2.b + dog2.s[0] + dog2.s[1] + "<br/>");

            //Console.WriteLine("===>>>Change dog2.i = 8;dog2.s[1] = D" + "<br/>");
            //dog2.i = 8;
            //dog2.s[1] = "D";
            //Console.WriteLine("Dog dog1 's members :" + dog1.i + " " + dog1.d + " " + dog1.b + dog1.s[0] + dog1.s[1] + "<br/>");
            //Console.WriteLine("Dog dog2的Members:" + dog2.i + dog2.d + dog2.b + dog2.s[0] + dog2.s[1] + "<br/>");

            //#endregion
            #endregion

            #region ICloneable接口下的 Clone()方法

            ClassA ca = new ClassA();
            ca.value = 88;
            ClassA ca2 = new ClassA();
            ca2 = (ClassA)ca.Clone();
            ca2.value = 99;
            Console.WriteLine(ca.value + "-----" + ca2.value);//88---99

            ClassB cb = new ClassB();
            cb.Member.value = 13;
            Console.WriteLine("===>>>cb.Member.value = 13;");

            ClassB cb2 = (ClassB)cb.Clone();
            cb2.Member.value = 7;
            Console.WriteLine(cb.Member.value.ToString() + "------" + cb2.Member.value.ToString());//浅拷贝：7---7      深拷贝：13----7           
            #endregion

            Console.ReadLine();
        }
    }

}
 
 #region//深克隆 浅克隆 MemberwiseClone() DeepClone()
/// <summary>
/// Abstract Class Animal
/// </summary>
//[Serializable]
public abstract class Animal
{
    public int i;
    public double d;
    public byte b;
    public string[] s;
    //public abstract Animal Clone();
}

/// <summary>
/// SubClass Dog
/// </summary>
[Serializable]
public class Dog : Animal
{
    public Dog(int i, double d, byte b, string s1, string s2)
    {
        this.i = i;
        this.d = d;
        this.b = b;
        string[] ms = { s1, s2 };
        this.s = ms;
    }
    //public override Animal Clone()
    //{
    //    return (Animal)this.MemberwiseClone();
    //}
    
    public Dog DeepClone()
    {
        BinaryFormatter bFormatter = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        bFormatter.Serialize(stream, this);
        stream.Seek(0, SeekOrigin.Begin);
        return (Dog)bFormatter.Deserialize(stream);
    }
}
#endregion


public class ClassA : ICloneable
{
    public int value = 0;

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class ClassB : ICloneable
{
    public ClassA Member = new ClassA();

    public object Clone()
    {
        //浅拷贝
        return this.MemberwiseClone();

        //深拷贝
        ClassB obj = new ClassB();
        obj.Member = (ClassA)Member.Clone();
        return obj;
    }
}


