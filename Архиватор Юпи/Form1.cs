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
        /// Полный путь к файлу.
        /// </summary>
        private string fullPath { get; set; }

        /// <summary>
        /// Ициализация дерева диска.
        /// </summary>
        private void DriveTreeInit()
        {
            string[] arrayDrive = Directory.GetLogicalDrives();
            treeView1.BeginUpdate();

            for (int i = 0; i < arrayDrive.Length; i++)
            {
                TreeNode treeNode = new TreeNode(arrayDrive[i],0,1);
                
                treeView1.Nodes.Add(treeNode);
            }

            treeView1.EndUpdate();
        }

        /// <summary>
       /// Получить список директорий.
       /// </summary>
        private void GetDirectory()
        {

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
    }
}
