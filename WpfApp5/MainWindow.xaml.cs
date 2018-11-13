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
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace WpfApp5
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Run_Click(object sender, RoutedEventArgs e)
        {
            string CodeToRun = TextBlock.Text;
       

            if (CodeToRun == "")
            {
                Output.Text = "Zadej nějáké data";
                return;
            }
            try
            {
                Output.Text =  (await CSharpScript.EvaluateAsync(TextBlock.Text)).ToString();
            }
            catch (CompilationErrorException s)
            {
                Output.Text =  (string.Join(Environment.NewLine, s.Diagnostics)).ToString();
            }

            
            
        }
    }
}
