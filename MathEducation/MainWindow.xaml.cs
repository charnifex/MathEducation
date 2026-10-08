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
using MathEducation.ModelsBD;
using Microsoft.EntityFrameworkCore;

namespace MathEducation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //frame1.Navigate(new TheoryPage());
            LoadTreeView();
        }
        
        MathContext db = new MathContext();

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Column1.Width.Value > 50)
            {
                Column1.Width = new GridLength(50);
                treeView.Visibility = Visibility.Collapsed;
            }
            else
            {
                Column1.Width = new GridLength(200);
                treeView.Visibility = Visibility.Visible;
            }
        }

        private void LoadTreeView()
        {
            using (var db = new MathContext())
            {
                var sections = db.Sections.ToList();

                foreach (var section in sections)
                {
                    TreeViewItem sectionItem = new TreeViewItem();
                    sectionItem.Header = section.Title;

                    var topics = db.Topics
                        .Where(t => t.SectionId == section.SectionId)
                        .ToList();

                    foreach (var topic in topics)
                    {
                        TreeViewItem topicItem = new TreeViewItem();
                        topicItem.Header = topic.Title;
                        topicItem.Tag = topic;

                        sectionItem.Items.Add(topicItem);
                    }

                    treeView.Items.Add(sectionItem);
                }
            }
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //db.Topics.Load();

            //var selected = treeView.SelectedItem;

            //MessageBox.Show(selected.GetType().FullName);

            //Data.selectedTopic = selected as Topic;

            //MessageBox.Show(
            //    Data.selectedTopic == null
            //        ? "selectedTopic = NULL"
            //        : Data.selectedTopic.Title
            //);

            if (treeView.SelectedItem != null)
            {
                db.Topics.Load();
                Data.selectedTopic =  (treeView.SelectedItem as TreeViewItem).Tag as Topic;
                frame1.Navigate(new TheoryPage());
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Authorization a = new Authorization();
            a.Show();
            if (Data.login == false)
            {
                this.Close();
            }

        }
    }
}