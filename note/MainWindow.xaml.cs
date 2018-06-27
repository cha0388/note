using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace note
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            System.IO.File.WriteAllText(filePath, TextArea.Text);

            MessageBox.Show ("保存完畢！");
            
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filePath);

            }

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
           

            string activeDir = @"C:\myDir";

            string newPath = System.IO.Path.Combine(activeDir, "mySubDirOne");

            System.IO.Directory.CreateDirectory(newPath);

            string fileNameOne = DateTime.Now.ToString("yyyyMMddHHmmssffff")+ ".txt";

            string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);  

            System.IO.File.Create(filePathOne);

            filePath = System.IO.Path.Combine(newPath, fileNameOne);
            
        }

        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);
            }
        }
   
        private void S_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void M_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void L_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Dark_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rect.Fill = Brushes.DimGray;
        }

        private void Light_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rect.Fill = Brushes.White;
        }
    }
}
