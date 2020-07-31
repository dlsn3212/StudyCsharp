using MahApps.Metro.Controls;
using System.Windows.Input;

namespace ArduinoMonitoringTest
{
    /// <summary>
    /// InfoProgram.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InfoProgram : MetroWindow
    {
        public InfoProgram()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)      //확인 누르면
        {
            this.Close();
        }
        private void FinishBinding_Executed(object sender, ExecutedRoutedEventArgs e)           //끝내기
        {
            this.Close();
        }
    }
}
