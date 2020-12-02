using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace Архиватор_Юпи
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Полный путь к каталогу.
        /// </summary>
        private string fullPath { get; set; }
        private const string Exect = "upi";

        /// <summary>
        /// Ициализация дерева диска.
        /// </summary>
        private void DriveTreeInit()
        {
            string[] mas = Directory.GetLogicalDrives();
            treeView1.Update();
            treeView1.Nodes.Clear();

            for (int i = 0; i < mas.Length; i++)
            {
                TreeNode tr = new TreeNode(mas[i],0,1);
                treeView1.Nodes.Add(tr);
                GetDirectory(tr);
            }

            treeView1.EndUpdate();
        }

        /// <summary>
        /// Получить директории узла.
        /// </summary>
        /// <param name="node">Выбраный узел</param>
        private void GetDirectory(TreeNode node)
        {
            node.Nodes.Clear();//Очистка узла;

            fullPath = node.FullPath;

            //Информация о катологу соответ. узлу Node.
            DirectoryInfo info = new DirectoryInfo(fullPath);

            DirectoryInfo[] infoArray;

            try
            {
                infoArray = info.GetDirectories();
            }
            catch
            {
                return;
            }

            for (int i = 0; i < infoArray.Length; i++)
            {
                TreeNode dir = new TreeNode(infoArray[i].Name, 0, 1);
                node.Nodes.Add(dir);
            }
        }

        /// <summary>
        /// Старт приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DriveTreeInit();

            //Получаем параметры, передаваймые приложению
            string[] args = Environment.GetCommandLineArgs();

            //Если приложению передаются какие либо параметры...
            if (args.Length > 2)
            {
                if (args[2] == "-unpack")//Если второй параметр "-unpack"
                {
                    DialogResult rez = MessageBox.Show("Распаковать архив?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rez == DialogResult.Yes) //Если пользователь потверждаем распаковку.
                    {
                        try
                        {    //Распаковка.
                             Arhivate.UnPack(args[1], Arhivate.IsExitFile(args[1]));
                             MessageBox.Show("Распаковка завершена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch 
                        {
                            MessageBox.Show("Ошибка распаковки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }

                    this.Close();
                }
                else
                if(args[2] == "-pack")
                {
                    DialogResult rez = MessageBox.Show("Упаковать файл?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rez == DialogResult.Yes) //Если пользователь потверждаем распаковку.
                    {
                        try
                        {
                            string s = Path.GetDirectoryName(args[1]) + "\\" + Path.GetFileNameWithoutExtension(args[1]) + ".upi";
                            //Распаковка.
                            Arhivate.Pack(args[1], s);
                            MessageBox.Show("Упаковка завершена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка распаковки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    this.Close();
                }
            }
               
        }                             

        /// <summary>
        /// Событие до раскрытия.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();
            //Перебрать все вложеные каталоги в выбраном узле.
            //e.Node - узел который разворачивается.
            //e.Node.Nodes - вложенные узлы.

            foreach (TreeNode item in e.Node.Nodes)
            {
                GetDirectory(item);
            }

            treeView1.EndUpdate();
        }

        /// <summary>
        /// Событие наступает после выделения узла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = e.Node;

            fullPath = selectNode.FullPath;

            DirectoryInfo di = new DirectoryInfo(fullPath);

            DirectoryInfo[] arrayDir;
            FileInfo[] arrayFile;

            try
            {
                arrayDir = di.GetDirectories();
                arrayFile = di.GetFiles();
            }
            catch 
            {
                return;
            }

            
            listView1.Items.Clear();

            foreach (DirectoryInfo item in arrayDir)
            {
                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(string.Empty);
                lvi.SubItems.Add(GetDate(item.LastWriteTime));
                listView1.Items.Add(lvi);
            }

            foreach (FileInfo item in arrayFile)
            {
                ListViewItem lvi = new ListViewItem(item.Name);

                //string t= item.Length.ToString();
                //for (int i = t.Length-3; i > 0; i-=3)
                //{
                //    t = t.Insert(i, " ");
                    
                //}

                lvi.SubItems.Add(GetSize(item.Length));
                //lvi.SubItems.Add(t);
                lvi.SubItems.Add(GetDate(item.LastWriteTime));

                listView1.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Изменение формата даты.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetDate(DateTime dt)
        {
            string s = dt.ToShortDateString();


            int h = dt.Hour;
            if (h < 10)
                s += " 0" + dt.ToShortTimeString();
            else
                s += " " + dt.ToShortTimeString();

            return s;
        }

        /// <summary>
        /// Полученение размера файла.
        /// </summary>
        /// <param name="lenght"></param>
        /// <returns></returns>
        private string GetSize(double lenght)
        {
            string[] f = { "Байт", "Кб", "Mб", "Гб" };
            int i = 0;
            while (lenght > 1024)
            {
                lenght = lenght / 1024.0;
                i++;
            }
            return string.Format("{0:f1} {1}",lenght,f[i]);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Text = fullPath+"\\"+listView1.SelectedItems[0].Text;
        }

        /// <summary>
        /// Архивация.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fPack_Click(object sender, EventArgs e)
        {
            string fSourse, fPack;

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали файл для упаковки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fSourse = fullPath + "\\" + listView1.SelectedItems[0].Text;
            if (!File.Exists(fSourse))
            {
                MessageBox.Show("Не удается упаковать папку.\nВыберите файл.");
                return;
            }

            fPack  = fullPath + "\\" + Path.GetFileNameWithoutExtension(listView1.SelectedItems[0].Text)+".upi";
            bool f = File.Exists(fPack);

            try
            {
                Arhivate.Pack(fSourse, fPack);
            }
            catch 
            {
                MessageBox.Show("Ошибка архивации","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (!f)
            {
                FileInfo fl = new FileInfo(fPack);
                ListViewItem lvi = new ListViewItem(fl.Name);
                lvi.SubItems.Add(GetSize(fl.Length));
                lvi.SubItems.Add(GetDate(fl.LastWriteTime));
                listView1.Items.Insert(listView1.SelectedIndices[0]+1, lvi);
            }

            MessageBox.Show("Файл упакован", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Разархивацяи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fUnPack_Click(object sender, EventArgs e)
        {
            string fSourse;
            string fUnp = "";

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали файл для распаковки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fSourse = fullPath + "\\" + listView1.SelectedItems[0].Text;

            //Получаем имя исходного файла.
            try
            {
                fUnp = Arhivate.IsExitFile(fSourse);
            }
            catch 
            {
                MessageBox.Show("Не удалось распаковать файл", "Внимание",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                return;
            }

            fUnp = fullPath + "\\" + Path.GetFileName(fUnp);
            
            //Если файл существует.
            if (File.Exists(fUnp))
            {
               var res = MessageBox.Show("Перезаписать существующий файл", "Внимание", 
                         MessageBoxButtons.OKCancel,
                         MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    File.Delete(fUnp);
                    listView1.Items.Remove(listView1.FindItemWithText(Path.GetFileName(fUnp)));
                }
                else
                    return;
            }

            //Извлечение файла.
            try
            {
                Arhivate.UnPack(fSourse,fUnp);
            }
            catch
            {
                MessageBox.Show("Не удалось распаковать файл", "Внимание",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                return;
            }

            //Добавление файла
            FileInfo fl = new FileInfo(fUnp);
            ListViewItem lvi = new ListViewItem(fl.Name);
            lvi.SubItems.Add(GetSize(fl.Length));
            lvi.SubItems.Add(GetDate(fl.LastWriteTime));
            listView1.Items.Insert(listView1.SelectedIndices[0], lvi);

            MessageBox.Show("Файл распокован", "Распаковка", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        ///Удаление файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fDel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Вы не выбрали файл для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileName = fullPath + "\\" + listView1.SelectedItems[0].Text;

            var res = MessageBox.Show($"Удалить файл {Path.GetFileName(fileName)} ?", "Удаление", 
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if(res == DialogResult.OK)
            {
                try
                {
                    File.Delete(fileName);
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
                catch 
                {
                    MessageBox.Show("Не удалось удалить файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        /// <summary>
        /// Выход из приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsExit_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Уже уходите ?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
                Application.Exit();
        }

        /// <summary>
        /// Добавления расширения.
        /// </summary>
        private void AddExet()
        {
            var prg = Application.ExecutablePath;
            string description = "";
            var reg = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true);

            reg.CreateSubKey("." + Exect).SetValue(string.Empty, Exect + "_open");

            //Смещение указателя.
            reg = reg.CreateSubKey(Exect + "_open");
            reg.SetValue(string.Empty, description);

            reg.CreateSubKey("DefaultIcon").SetValue(string.Empty, "\"" + prg + "\",0");
            reg = reg.CreateSubKey("Shell");
            reg = reg.CreateSubKey("Open");
            reg = reg.CreateSubKey("Command");
            reg.SetValue(string.Empty, "\"" + prg + "\" \"%1\" -unpack");

            reg.Close();
        }

        /// <summary>
        /// Удаление расширение.
        /// </summary>
        private void DeletExet()
        {
            using (var reg = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true))
            {
                try
                {
                    reg.DeleteSubKeyTree("." + Exect);
                    reg.DeleteSubKeyTree(Exect + "_open");
                }
                catch
                {
                }

            }
        }

        /// <summary>
        /// Информация о программе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hInform_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Архиватор Юпи" +
                "\nВерсия: 1.0v\n" +
                "Описание: " +
                "\nАрхиватор предназначен для упаковки текстовых,exe файлов и изображение с расширение bmp.","Описание",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        /// <summary>
        /// Проверка соостояние кнопки(выбранно/не выбранно)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pAddExet_CheckedChanged(object sender, EventArgs e)
        {
            if (pAddExet.Checked)
                AddExet();
            else
                DeletExet();
        }

        /// <summary>
        /// Добавление в контекстное меню.
        /// </summary>
        private void AddContMenu()
        {
            RegistryKey k = Registry.ClassesRoot.CreateSubKey(@"*\Shell\Pack");
            k.SetValue(string.Empty, "Упаковать архив");
            k.SetValue("icon", "\"" + Application.ExecutablePath + "\",0");
            k.CreateSubKey("Command").SetValue(string.Empty, "\"" + Application.ExecutablePath + "\" \"%1\" -pack");
            k.Close();

            RegistryKey reg = Registry.ClassesRoot.CreateSubKey(@"*\Shell\UnPack");
            reg.SetValue(string.Empty, "Распаковать архив");
            reg.SetValue("icon", "\"" + Application.ExecutablePath + "\",0");
            reg.CreateSubKey("Command").SetValue(string.Empty, "\"" + Application.ExecutablePath + "\" \"%1\" -unpack");
            reg.Close();

        }

        /// <summary>
        /// Удаление из контекстного меню.
        /// </summary>
        private void DeletComMenu()
        {
            RegistryKey k = Registry.ClassesRoot.CreateSubKey("*\\Shell", true);
            try
            {
                k.DeleteSubKeyTree("Pack");
                k.DeleteSubKeyTree("UnPack");
            }
            catch{}
            finally
            {
                k.Close();
            }


        }

        /// <summary>
        /// Добавление/Удаление.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pAddKonMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (pAddKonMenu.Checked)
                AddContMenu();
            else
                DeletComMenu();
        }

        /// <summary>
        /// При разворачивании.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mPropertis_DropDownOpened(object sender, EventArgs e)
        {
            using (var k = Registry.CurrentUser.OpenSubKey(@"Software\Classes\.upi"))
            {
                pAddExet.Checked = k != null;
            }

            RegistryKey reg = Registry.ClassesRoot.OpenSubKey(@"*\Shell\Pack");
            if (reg != null)
            {
                pAddKonMenu.Checked = true;
                reg.Close();
            }
            
        }

        /// <summary>
        /// Документация.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hHelp_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath +"\\help.chm");
        }
    }
}
