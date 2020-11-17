using System;
using System.IO;
using System.Windows.Forms;

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

        /// <summary>
        /// Ициализация дерева диска.
        /// </summary>
        private void DriveTreeInit()
        {
            string[] arrayDrive = Directory.GetLogicalDrives();
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            for (int i = 0; i < arrayDrive.Length; i++)
            {
                TreeNode treeNode = new TreeNode(arrayDrive[i],0,1);
                
                treeView1.Nodes.Add(treeNode);
                GetDirectory(treeNode);

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
                TreeNode dir = new TreeNode(infoArray[i].Name,0,1);
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
                lvi.SubItems.Add(GetSize(item.Length));
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
    }
}
