using System;
using System.IO;
using System.Xml;
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
using Ganss.Excel;

namespace OrderItemList
{
    public partial class MainWindow : Window
    {
        ImageBrush ImageMissing = new ImageBrush();

        int RecWidth = 250;
        int RecHeight = 100;
        int SizeBetweenRec = 15;

        string[] MenuChoice = new string[19];
        int state = 0;

        List<Product> Everything = new List<Product>();

        List<Product> WindowAwning = new List<Product>(); //1
        List<Product> Awning = new List<Product>(); //2
        List<Product> MotorAwning = new List<Product>(); //3
        List<Product> Parasol = new List<Product>(); //4
        List<Product> Pavillion = new List<Product>(); //5
        List<Product> Pool = new List<Product>(); //6
        List<Product> SPA = new List<Product>(); //7
        List<Product> Railing = new List<Product>(); //8
        List<Product> CoalGrill = new List<Product>(); //9
        List<Product> GasGrill = new List<Product>(); //10
        List<Product> Chair = new List<Product>(); //11
        List<Product> Cusion = new List<Product>(); //12
        List<Product> Table = new List<Product>(); //13
        List<Product> LoungeSet = new List<Product>(); //14
        List<Product> Lissabon = new List<Product>(); //15
        List<Product> Box = new List<Product>(); //16
        List<Product> Trampoline = new List<Product>(); //17
        List<Product> JumpCastle = new List<Product>(); //18
        List<Product> Powertrap = new List<Product>(); //19

        public MainWindow()
        {
            InitializeComponent();
            MainMenuChoice();
            ImageMissing.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Bilder/ImageMissing.png"));

            var products = new ExcelMapper("Excel.xlsx").Fetch<Product>();
            Everything = products.ToList();

            WindowAwning = products.Where(p => p.ArticleGroup == 6255).ToList();
            Awning = products.Where(p => p.ArticleGroup == 6256).ToList();
            MotorAwning = products.Where(p => p.ArticleGroup == 6257).ToList();
            Parasol = products.Where(p => p.ArticleGroup == 6040 || p.ArticleGroup == 6259).ToList();
            Pavillion = products.Where(p => p.ArticleGroup == 6267).ToList();
            Pool = products.Where(p => p.ArticleGroup == 7591).ToList();
            SPA = products.Where(p => p.ArticleName.Contains("Spa")).ToList();
            Railing = products.Where(p => p.ArticleGroup == 6210 || p.ArticleGroup == 6294).ToList();
            CoalGrill = products.Where(p => p.ArticleGroup == 6239 || p.ArticleGroup == 6235).ToList();
            GasGrill = products.Where(p => p.ArticleGroup == 6235).ToList();
            Chair = products.Where(p => p.ArticleGroup == 6020).ToList();
            Cusion = products.Where(p => p.ArticleGroup == 6030).ToList();
            Table = products.Where(p => p.ArticleGroup == 6010).ToList();
            LoungeSet = products.Where(p => p.ArticleGroup == 6050).ToList();
            Lissabon = products.Where(p => p.ArticleGroup == 6255).ToList();
            Box = products.Where(p => p.ArticleGroup == 6255).ToList();
            Trampoline = products.Where(p => p.ArticleGroup == 7590).ToList();
            JumpCastle = products.Where(p => p.ArticleGroup == 7550 || p.ArticleGroup == 7040).ToList();
            Powertrap = products.Where(p => p.ArticleGroup == 6296).ToList();
            
        }
        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            switch (state)
            {
                case 0:
                    SpawnMainMeny(19);
                    break;
                case 1:
                    SpawnCategory(WindowAwning);
                    break;
                case 2:
                    SpawnCategory(Awning);
                    break;
                case 3:
                    SpawnCategory(MotorAwning);
                    break;
                case 4:
                    SpawnCategory(Parasol);
                    break;
                case 5:
                    SpawnCategory(Pavillion);
                    break;
                case 6:
                    SpawnCategory(Pool);
                    break;
                case 7:
                    SpawnCategory(SPA);
                    break;
                case 8:
                    SpawnCategory(Railing);
                    break;
                case 9:
                    SpawnCategory(CoalGrill);
                    break;
                case 10:
                    SpawnCategory(GasGrill);
                    break;
                case 11:
                    SpawnCategory(Chair);
                    break;
                case 12:
                    SpawnCategory(Cusion);
                    break;
                case 13:
                    SpawnCategory(Table);
                    break;
                case 14:
                    SpawnCategory(LoungeSet);
                    break;
                case 15:
                    SpawnCategory(Lissabon);
                    break;
                case 16:
                    SpawnCategory(Box);
                    break;
                case 17:
                    SpawnCategory(Trampoline);
                    break;
                case 18:
                    SpawnCategory(JumpCastle);
                    break;
                case 19:
                    SpawnCategory(Powertrap);
                    break;
                case 20:

                    break;
            }
            
        }

        private void MainMenuChoice()
        {
            MenuChoice[0] = " Fönstermarkis";
            MenuChoice[1] = " Markis med vev";
            MenuChoice[2] = " Motormarkis";
            MenuChoice[3] = $" Parasoll{('\n')} Insynsskydd";
            MenuChoice[4] = " Paviljonger";
            MenuChoice[5] = $" Pool{('\n')} Pooltillbehör";
            MenuChoice[6] = " Spabad";
            MenuChoice[7] = " Glasräcke";
            MenuChoice[8] = $" Kolgrill{('\n')}Pelletsgrill";
            MenuChoice[9] = $" Gasolgrill";
            MenuChoice[10] = " Stolar";
            MenuChoice[11] = " Dynor";
            MenuChoice[12] = " Bord";
            MenuChoice[13] = " LoungeSet";
            MenuChoice[14] = $" LoungeSet{('\n')}Lissabon";
            MenuChoice[15] = $" Förvaring-{('\n')}/dynlåda";
            MenuChoice[16] = $" Studsmatta{('\n')}Kantskydd";
            MenuChoice[17] = $" Hoppborg{('\n')}Vattenland";
            MenuChoice[18] = $" Mosquito{('\n')}powertrap";

        }
        private void SpawnMainMeny(double RecToSpawn)
        {
            state = 0;
            ScrollViewerCanvas.Children.Clear();
            ScrollViewerCanvas.Height = ScrollViewer.ActualHeight;
            double Height = ScrollViewerCanvas.Height;
            double Height2 = RecHeight + SizeBetweenRec;


            double Width = ScrollViewer.ActualWidth;
            int y = 0;
            int x2 = 0;
            int x3 = 1;
            for (int x = 0; x < RecToSpawn; x++)
            {
                SolidColorBrush White = new SolidColorBrush(Colors.White);

                Rectangle r = new Rectangle();
                r.Name = $"r{x2}";
                r.Width = RecWidth /2;
                r.Height = RecHeight;

                try { r.Fill = ImageMissing; }
                catch { r.Fill = ImageMissing; }


                Canvas.SetLeft(r, (SizeBetweenRec * (x2+1)) + (RecWidth * x2));
                Canvas.SetTop(r, (SizeBetweenRec * (y+1)) + (RecHeight * y));
                ScrollViewerCanvas.Children.Add(r);

                TextBox tb = new TextBox();
                tb.Name = $"tb{x2}";
                tb.Width = RecWidth / 2;
                tb.Height = RecHeight;
                tb.IsReadOnly = true;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0);
                tb.Text = MenuChoice[x];

                Canvas.SetLeft(tb, (SizeBetweenRec * (x2 + 1)) + (RecWidth * x2) + (RecWidth / 2));
                Canvas.SetTop(tb, (SizeBetweenRec * (y + 1)) + (RecHeight * y));
                ScrollViewerCanvas.Children.Add(tb);

                r = new Rectangle();
                r.Name = $"r2{x3}";
                r.Width = RecWidth;
                r.Height = RecHeight;
                r.MouseLeftButtonUp += new MouseButtonEventHandler(UIElement_MouseUp);
                r.Fill = new SolidColorBrush(Colors.Red);
                r.Opacity = 0;

                Canvas.SetLeft(r, (SizeBetweenRec * (x2 + 1)) + (RecWidth * x2));
                Canvas.SetTop(r, (SizeBetweenRec * (y + 1)) + (RecHeight * y));
                ScrollViewerCanvas.Children.Add(r);

                Width = Width - (RecWidth + SizeBetweenRec);
                x3++;
                x2++;
                if(Width < RecWidth)
                {
                    y++; x2 = 0;
                    Width = ScrollViewer.ActualWidth;
                    Height2 = Height2 + RecHeight + SizeBetweenRec;

                    if(Height2>Height) ScrollViewerCanvas.Height = ScrollViewerCanvas.Height + RecHeight + SizeBetweenRec;
                }

            }
        }
        private void SpawnCategory(List<Product> SpecificList)
        {
            ScrollViewerCanvas.Children.Clear();
            ScrollViewerCanvas.Height = ScrollViewer.ActualHeight;
            double Height = ScrollViewerCanvas.Height;
            double Height2 = RecHeight + SizeBetweenRec;


            double Width = ScrollViewer.ActualWidth;
            int y = 0;
            int x2 = 0;
            foreach(var p in SpecificList)
            {
                SolidColorBrush White = new SolidColorBrush(Colors.White);

                Rectangle r = new Rectangle();
                r.Name = $"r{p.ArticleNumber}";
                r.Width = RecWidth / 2;
                r.Height = RecHeight;

                try { r.Fill = ImageMissing; } //productbild
                catch { r.Fill = ImageMissing; }


                Canvas.SetLeft(r, (SizeBetweenRec * (x2 + 1)) + (RecWidth * x2));
                Canvas.SetTop(r, (SizeBetweenRec * (y + 1)) + (RecHeight * y));
                ScrollViewerCanvas.Children.Add(r);

                TextBox tb = new TextBox();
                tb.Name = $"tb{p.ArticleNumber}";
                tb.Width = RecWidth / 2;
                tb.Height = RecHeight;
                tb.IsReadOnly = true;
                tb.FontSize = 14;
                tb.BorderThickness = new Thickness(0);
                tb.Text = $" {p.ArticleName}{('\n')} {p.Measurment}{('\n')} {p.ArticleNumber}{('\n')} ";

                Canvas.SetLeft(tb, (SizeBetweenRec * (x2 + 1)) + (RecWidth * x2) + (RecWidth / 2));
                Canvas.SetTop(tb, (SizeBetweenRec * (y + 1)) + (RecHeight * y));
                ScrollViewerCanvas.Children.Add(tb);

                /*r = new Rectangle();
                r.Name = $"r{x2}";
                r.Width = RecWidth;
                r.Height = RecHeight;
                r.MouseLeftButtonUp += new MouseButtonEventHandler(UIElement_MouseUp);
                r.Fill = new SolidColorBrush(Colors.Red);
                r.Opacity = 0;

                Canvas.SetLeft(r, (SizeBetweenRec * (x2 + 1)) + (RecWidth * x2));
                Canvas.SetTop(r, (SizeBetweenRec * (y + 1)) + (RecHeight * y));
                ScrollViewerCanvas.Children.Add(r);*/

                Width = Width - (RecWidth + SizeBetweenRec);
                x2++;
                if (Width < RecWidth)
                {
                    y++; x2 = 0;
                    Width = ScrollViewer.ActualWidth;
                    Height2 = Height2 + RecHeight + SizeBetweenRec;

                    if (Height2 > Height) ScrollViewerCanvas.Height = ScrollViewerCanvas.Height + RecHeight + SizeBetweenRec;
                }

            }
        }

        public int timesdividedby10(double x)
        {
            double CanvasWidth = ScrollViewer.ActualWidth;
            int count = 0;
            while (x >= CanvasWidth)
            {
                ++count;
                x = x - (RecWidth - SizeBetweenRec);
            }

            return count;
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Search.Text == "Sök...") Search.Text = "";
        }
        private void Search_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void UIElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string selectedElement = ((Rectangle)sender).Name;

            if(selectedElement == "r21") { SpawnCategory(WindowAwning); state = 1; }
            else if (selectedElement == "r22") { SpawnCategory(Awning); state = 2; }
            else if (selectedElement == "r23") { SpawnCategory(MotorAwning); state = 3; }
            else if (selectedElement == "r24") { SpawnCategory(Parasol); state = 4; }
            else if (selectedElement == "r25") { SpawnCategory(Pavillion); state = 5; }
            else if (selectedElement == "r26") { SpawnCategory(Pool); state = 6; }
            else if (selectedElement == "r27") { SpawnCategory(SPA); state = 7; }
            else if (selectedElement == "r28") { SpawnCategory(Railing); state = 8; }
            else if (selectedElement == "r29") { SpawnCategory(CoalGrill); state = 9; }
            else if (selectedElement == "r210") { SpawnCategory(GasGrill); state = 10; }
            else if (selectedElement == "r211") { SpawnCategory(Chair); state = 11; }
            else if (selectedElement == "r212") { SpawnCategory(Cusion); state = 12; }
            else if (selectedElement == "r213") { SpawnCategory(Table); state = 13; }
            else if (selectedElement == "r214") { SpawnCategory(LoungeSet); state = 14; }
            else if (selectedElement == "r215") { SpawnCategory(Lissabon); state = 15; }
            else if (selectedElement == "r216") { SpawnCategory(Box); state = 16; }
            else if (selectedElement == "r217") { SpawnCategory(Trampoline); state = 17; }
            else if (selectedElement == "r218") { SpawnCategory(JumpCastle); state = 18; }
            else if (selectedElement == "r219") { SpawnCategory(Powertrap); state = 19; }
            else { }

        }
        private void HomeButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SpawnMainMeny(19);
        }
    }
}
