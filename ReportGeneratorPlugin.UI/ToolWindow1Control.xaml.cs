using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using ReportGenerator = ReportGeneratorPlugin.UI.Generator.ReportGenerator;

namespace ReportGeneratorPlugin.UI
{
    /// <summary>
    /// Interaction logic for ToolWindow1Control.
    /// </summary>
    public partial class ToolWindow1Control : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindow1Control"/> class.
        /// </summary>
        public ToolWindow1Control()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            InitializeComponent();
        }

        private bool _isPdf = false;
        private List<string> extensions = new List<string>();
        private string Introduction = "";
        private string conclusion = "";

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            ReportGenerator gen = new ReportGenerator(filePath.Text);
            gen.GenerateReport(repoPath.Text, conclusion, Introduction, extensions, _isPdf);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fileFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)fileFormat.SelectedItem;
            if (cbi.Content.ToString() == ".pdf")
                _isPdf = true;
            else
                _isPdf = false;
        }

        private void filePath_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Select_Path_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "pdf files (*.pdf)|*.pdf | doc files (*.docx, .doc) |*.docx *.doc",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = saveFileDialog.FileName;
            }
        }

        private void Conclusion_SelectionChanged(object sender, RoutedEventArgs e)
        {
            conclusion = Conclusion.Text;
        }

        private void Inroduction_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Introduction = Inroduction.Text;
        }

        private void csCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            extensions.Remove(".cs");
        }

        private void csCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extensions.Add(".cs");
        }

        private void cppCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            extensions.Remove(".cpp");
        }

        private void hCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extensions.Add(".h");
        }

        private void hCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            extensions.Remove(".h");
        }

        private void razorCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            extensions.Remove(".razor");
        }
        private void razorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extensions.Add(".razor");
        }

        private void htmlCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            extensions.Remove(".html");
        }
        private void htmlCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extensions.Add(".html");
        }

        private void Select_repoPath_Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                repoPath.Text = dlg.SelectedPath;
            }
        }

        private void cppCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extensions.Add(".cpp");
        }
    }
}