using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HAPExplorer.Properties;

namespace HAPExplorer
{
    /// <summary>
    /// Interaction logic for UrlDialog.xaml
    /// </summary>
    public partial class UrlDialog
    {
        #region Constructors

        public UrlDialog()
        {
            InitializeComponent();
            Loaded += UrlDialog_Loaded;
            
        }

        void UrlDialog_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.ItemsSource = Settings.Default.UrlHistoryItems
                                                   .Select(item => new ComboBoxItem {Content = item});

            textBox1.Focus();

        }

        #endregion

        #region Properties

        public string Url
        {
            get { return textBox1.Text.Trim(); }
        }

        #endregion

        #region Private Methods

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.Default.UrlHistoryItems.Contains(textBox1.Text))
            {
                Settings.Default.UrlHistoryItems.Add(textBox1.Text);
                var ss = Settings.Default.UrlHistoryItems.Count;
            }
            DialogResult = !textBox1.Text.IsEmpty();

            return;
        }

        #endregion

        private void textBox1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}