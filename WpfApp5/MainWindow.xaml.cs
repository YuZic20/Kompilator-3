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
        Item Input = new Item("meč", 10);
       
        public MainWindow()
        {
            Hrac.Items.Add(Input);
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
                //WithImports("System.Collections.Generic")
                var metadata = MetadataReference.CreateFromFile(typeof(Item).Assembly.Location);
                ScriptOptions options = ScriptOptions.Default.WithReferences(metadata).WithImports("System.Collections.Generic");


                Output.Text = (await CSharpScript.RunAsync(
                CodeToRun
                , options: options
                , globals: Hrac)).ToString();


            }
            catch (CompilationErrorException s)
            {
                Output.Text =  (string.Join(Environment.NewLine, s.Diagnostics)).ToString();
                
            }
            /*
            using WpfApp5;
            Item Input = new Item("meč2", 20);
            Items.Add(Input);
            */
            /*
            using WpfApp5;
            using System.Collections;
            int MaxIndex = Items.Count;
            for (int i = 0; i< MaxIndex; i++)
            {
                Items[i].Value = Items[i].Value * 1.5f;
            }
            */
        }

    }
}
