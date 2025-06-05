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


namespace corridor_danil_shafiev;
using corridor_danil_shafiev.ModelView;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    MV mv = new MV();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = mv;
    }

    private void clickOnCanvas(object sender, MouseButtonEventArgs e)
    {
        Point pos = e.GetPosition((Canvas)sender);
        int x = (int)(pos.X / 8);
        int y = (int)(pos.Y / 8);


        mv.myClick(x,y);
    }
}