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
    }
}
