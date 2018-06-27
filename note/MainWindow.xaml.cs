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
        //創建ㄧ個空的檔案路徑
        string filePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 將輸入欄文字寫入已開啟的檔案
            System.IO.File.WriteAllText(filePath, TextArea.Text);

            // 提示已保存完畢
            MessageBox.Show ("保存完畢！");
            
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 可開啟類型:txt及所有檔案
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

            // 使標題文字顯示為檔案名稱
            Title.Text = System.IO.Path.GetFileName(filePath);
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            // 清空輸入欄
            TextArea.Text = "";

            // 預設在C槽有ㄧ個名為"myDir"的資料夾
            string activeDir = @"C:\myDir";

            // 設新檔案將會放入"myDir"中的"mySubDirOne"
            string newPath = System.IO.Path.Combine(activeDir, "mySubDirOne");

            // 若上兩行的路徑不存在，則自動創建
            System.IO.Directory.CreateDirectory(newPath);

            // 預設檔案名為按下此按鈕的時間，檔案格式為txt
            string fileNameOne = DateTime.Now.ToString("yyyyMMddHHmmssffff")+ ".txt";

            // 新檔案路徑為C:\myDir\mySubDirOne
            string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);

            // 在C:\myDir\mySubDirOne內創建新檔案
            System.IO.File.Create(filePathOne);

            // 將此新檔案的路徑導出為全域可用
            filePath = System.IO.Path.Combine(newPath, fileNameOne);

            // 使標題文字顯示為檔案名稱
            Title.Text = System.IO.Path.GetFileName(filePath);
        }

        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生儲存檔案視窗
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 可存檔類型:txt及所有檔案
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

            // 使標題文字顯示為檔案名稱
            Title.Text = System.IO.Path.GetFileName(filePath);
        }

        // 輸入欄字型變小
        private void S_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextArea.FontSize = 12;
        }

        // 輸入欄字型中等
        private void M_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextArea.FontSize = 16;
        }

        // 輸入欄字型變大
        private void L_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextArea.FontSize = 20;
        }

        // 背景變暗
        private void Dark_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rect.Fill = Brushes.DimGray;
            Dark.Stroke = Brushes.White;
            Light.Stroke = Brushes.DarkGray;
        }

        // 背景變白
        private void Light_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rect.Fill = Brushes.White;
            Dark.Stroke = Brushes.DarkGray;
            Light.Stroke = Brushes.White;
        }

        // 滑鼠左鍵拖曳可移動視窗
        private void G_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // 關閉視窗
        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        // 視窗最大化
        private void big_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        // 視窗最小化
        private void small_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
