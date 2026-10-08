using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mammoth;
using System.IO;


namespace MathEducation
{
    /// <summary>
    /// Логика взаимодействия для TheoryPage.xaml
    /// </summary>
    public partial class TheoryPage : Page
    {
        public TheoryPage()
        {
            InitializeComponent();


            ShowDocument();
        }

        private async void ShowDocument()
        {
            if (Data.selectedTopic != null)
            {
                await webView.EnsureCoreWebView2Async();

                string path = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "EducationalMaterial",
                Data.selectedTopic.DocName.ToString() + ".docx"
                );

                var converter = new DocumentConverter();
                var result = converter.ConvertToHtml(path);

                webView.NavigateToString(result.Value);
            }
        }
    }
}
