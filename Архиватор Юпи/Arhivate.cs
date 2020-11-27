using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Архиватор_Юпи
{
    /// <summary>
    /// Класс для архивирования.
    /// </summary>
    public class Arhivate
    {
        private static uint[] ArrayChastot = new uint[256];
        private static string[] ArrayCode = new string[256];

        private static Element h;

        /// <summary>
        /// Создание списка.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Element CreateList(string fileName)
        {
            for (int i = 0; i < ArrayChastot.Length; i++)
            {
                ArrayChastot[i] = 0;
            }

            using (var br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                long lenghtFile = br.BaseStream.Length;

                while (br.BaseStream.Position < lenghtFile)
                {
                    byte currentByte = br.ReadByte();
                    ArrayChastot[currentByte] += 1;
                }

                h = new Element();
                h.Left = h.Right = h.Next = h.Back = null;

                Element a, b;
                a = h;

                for (int i = 0; i < ArrayChastot.Length; i++)
                {
                    if (ArrayChastot[i] != 0)
                    {
                        b = new Element();
                        b.Left = b.Right = null;

                        b.Back = a;
                        a.Next = b;

                        b.Value = Convert.ToByte(i);
                        b.Chastot = ArrayChastot[i];

                        a = b;
                    }
                }

                a = h;
                h = h.Next;
                h.Back = a.Next = a = null;
            }

            return h;
        }

        /// <summary>
        /// Создание списка для упаковки.
        /// </summary>
        private static void CreateListForUnPack()
        {
            h = new Element();
            h.Left = h.Right = h.Next = h.Back = null;

            Element a, b;
            a = h;

            for (int i = 0; i < ArrayChastot.Length; i++)
            {
                if (ArrayChastot[i] != 0)
                {
                    b = new Element();
                    b.Left = b.Right = null;

                    b.Back = a;
                    a.Next = b;

                    b.Value = Convert.ToByte(i);
                    b.Chastot = ArrayChastot[i];

                    a = b;
                }
            }

            a = h;
            h = h.Next;
            h.Back = a.Next = a = null;
        }

        /// <summary>
        /// Поиск минимального значения в списке.
        /// </summary>
        /// <returns></returns>
        private static Element FindMinElement()
        {
            Element min = h;

            if (h.Next == null)
                h = null;
            else
            {
                Element a = h.Next;

                while (a != null)
                {
                    if (a.Chastot < min.Chastot)
                        min = a;

                    a = a.Next;
                }

                if (min == h)
                {
                    h = h.Next;
                    h.Back = min.Next = null;
                }
                else
                if (min.Next == null)
                {
                    min.Back.Next = null;
                    min.Back = null;
                }
                else
                {
                    min.Back.Next = min.Next;
                    min.Next.Back = min.Back;
                    min.Next = min.Back = null;
                }
            }

            return min;
        }

        /// <summary>
        /// Создание дерева.
        /// </summary>
        private static void CreateTree()
        {
            Element FirstMin,
                    SecondMin,
                    a;

            while (h.Next != null)
            {
                FirstMin = FindMinElement();
                SecondMin = FindMinElement();

                a = new Element();
                a.Chastot = FirstMin.Chastot + SecondMin.Chastot;
                a.Left = FirstMin;
                a.Right = SecondMin;
                a.Next = h;
                if (h != null)
                    h.Back = a;
                h = a;
            }
        }

        /// <summary>
        /// Получение кодов байтов.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="code"></param>
        private static void GetCode(Element e, string code)
        {
            if (e.Left == null && e.Right == null)
                ArrayCode[e.Value] = code;
            else
            {
                if (e.Left != null)
                    GetCode(e.Left, code + '0');
                if (e.Right != null)
                    GetCode(e.Right, code + '1');
            }
        }

        /// <summary>
        /// Упаковка файла.
        /// </summary>
        /// <param name="baseName">исходное</param>
        /// <param name="finalyName">результат</param>
        public static void Pack(string baseName, string finalyName)
        {
            for (int i = 0; i < 256; i++)
            {
                ArrayCode[i] = "";
                ArrayChastot[i] = 0;
            }

            CreateList(baseName);
            CreateTree();
            GetCode(h, "");


            Int64 t = 0;
            for (int i = 0; i < 256; i++)
            {
                t = (t + ArrayChastot[i] * ArrayCode[i].Length) % 8;
            }
            byte zeroEnd = Convert.ToByte(8 - t);

            using (var br = new BinaryReader(File.Open(baseName, FileMode.Open)))
            {
                

                using (var bw = new BinaryWriter(File.Open(finalyName, FileMode.Create)))
                {
                    
                    for (int i = 0; i < 256; i++)
                    {
                        bw.Write(ArrayChastot[i]);
                    }
                    bw.Write(zeroEnd);

                    bw.Write(baseName);

                    string s = "";
                    long lenght = br.BaseStream.Length;

                    while (br.BaseStream.Position < lenght)
                    {
                        

                        byte currentByte = br.ReadByte();
                        s += ArrayCode[currentByte];

                        while (s.Length > 7)
                        {
                            int byteWrite = 0;
                            if (s[0] == '1') byteWrite += 128;
                            if (s[1] == '1') byteWrite += 64;
                            if (s[2] == '1') byteWrite += 32;
                            if (s[3] == '1') byteWrite += 16;
                            if (s[4] == '1') byteWrite += 8;
                            if (s[5] == '1') byteWrite += 4;
                            if (s[6] == '1') byteWrite += 2;
                            if (s[7] == '1') byteWrite += 1;

                            s = s.Remove(0, 8);
                            bw.Write(Convert.ToByte(byteWrite));
                        }
                    }

                    if (s.Length > 0)
                    {
                        for (int i = 1; i <= zeroEnd; i++)
                        {
                            s += '0';
                        }

                        int byteWrite = 0;
                        if (s[0] == '1') byteWrite += 128;
                        if (s[1] == '1') byteWrite += 64;
                        if (s[2] == '1') byteWrite += 32;
                        if (s[3] == '1') byteWrite += 16;
                        if (s[4] == '1') byteWrite += 8;
                        if (s[5] == '1') byteWrite += 4;
                        if (s[6] == '1') byteWrite += 2;
                        if (s[7] == '1') byteWrite += 1;

                        s = s.Remove(0, 8);
                        bw.Write(Convert.ToByte(byteWrite));
                    }
                }

            }
        }

        /// <summary>
        /// Распаковка.
        /// </summary>
        /// <param name="baseName">имя распковываемого файла.</param>
        public static void UnPack(string baseName,string readFile)
        {
            using (var br = new BinaryReader(File.Open(baseName, FileMode.Open)))
            {
                for (int i = 0; i < 256; i++) ArrayChastot[i] = br.ReadUInt32();
                int zerows = Convert.ToInt32(br.ReadByte());
                string fileName = br.ReadString();

                CreateListForUnPack();
                CreateTree();

                int x = 0;
                Element a = h;

                using (var bw = new BinaryWriter(File.Open(readFile, FileMode.Create)))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length - 1)
                    {

                        x = br.ReadByte();

                        for (int i = 0; i < 8; i++)
                        {
                            a = (x & 128) == 128 ? a.Right : a.Left;
                            x = x << 1;

                            if (a.Left == null && a.Right == null)
                            {
                                bw.Write(a.Value);
                                a = h;
                            }

                        }

                    }

                    x = br.ReadByte();

                    for (int i = 0; i < 8 - zerows; i++)
                    {
                        a = (x & 128) == 128 ? a.Right : a.Left;
                        x = x << 1;

                        if (a.Left == null && a.Right == null)
                        {
                            bw.Write(a.Value);
                            a = h;
                        }
                    }

                }
            }
        }

        public static string IsExitFile(string fileName)
        {
            using (var br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                for (int i = 0; i < 256; i++) ArrayChastot[i] = br.ReadUInt32();
                int zerows = Convert.ToInt32(br.ReadByte());
                fileName= br.ReadString();
            }

            return fileName;
        }
    }
}
