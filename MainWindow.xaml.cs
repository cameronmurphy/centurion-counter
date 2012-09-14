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
using System.Windows.Threading;

namespace Camurphy.CenturionCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int m_SecondsRemaining = 10;
        private int m_ShotsComplete = 0;
        private DispatcherTimer m_GameTimer;

        public MainWindow()
        {
            InitializeComponent();
            m_GameTimer = new DispatcherTimer();
            m_GameTimer.Interval = TimeSpan.FromSeconds(1);
            m_GameTimer.Tick += GameTimer_TickHandler;
        }

        /// <summary>
        /// Enables dragging by windows contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5 && m_GameTimer.IsEnabled == false)
            {
                m_GameTimer.Start();
            }
        }

        private void GameTimer_TickHandler(object sender, EventArgs e)
        {
            m_SecondsRemaining--;

            if (m_SecondsRemaining == -1)
            {
                m_SecondsRemaining = 59;
                m_ShotsComplete++;
            }

            SecondsRemainingTextBlock.Text = m_SecondsRemaining.ToString();
            ShotsCompleteTextBlock.Text = m_ShotsComplete.ToString();
        }
    }
}
