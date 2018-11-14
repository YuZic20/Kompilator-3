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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace WpfApp5
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player Hrac = new Player("Apolo", 10, 5, 20);
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
                var metadata = MetadataReference.CreateFromFile(typeof(Item).Assembly.Location);
                Output.Text = (await CSharpScript.RunAsync(
                CodeToRun
                , options: ScriptOptions.Default.WithReferences(metadata)
                , globals: Hrac)).ToString();

            }
            catch (CompilationErrorException s)
            {
                Output.Text =  (string.Join(Environment.NewLine, s.Diagnostics)).ToString();
            }
            /*
            using WpfApp5;
            Item Input = new Item("meč", 10);
            Items.Add(Input);
            */
        }
    }
}
