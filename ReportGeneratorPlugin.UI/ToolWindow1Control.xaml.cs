using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            this.InitializeComponent();
        }

        private bool isPdf = false;

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> ext = new List<string>() { ".cs" };
            ReportGenerator gen = new ReportGenerator(filePath.Text);
            gen.GenerateReport(@"C:\Users\andri\source\repos\ReportGeneratorPlugin", "", "", ext);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fileFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isPdf = !isPdf;
        }

        private void filePath_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Select_Path_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pdf files (*.pdf)|*.pdf | doc files (*.docx, .doc) |*.docx *.doc";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = saveFileDialog.FileName;
            }
        }
    }
}