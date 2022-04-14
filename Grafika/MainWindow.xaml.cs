using Grafika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;
using Point = System.Windows.Point;

namespace Grafika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private bool flag = false;
        private int counter = 0;
        private List<UIElement> collection;
        public static AddTextModel addTextModel;
        public static EllipseModel model;
        public static PolygonModel polygonModel;
        List<Point> points;
        public static EllipseChangeModel ellipseChangeModel;
        public static TextChangeModel textChangeModel;
        public static PolyghonChangeModel polyghonChangeModle;
     
        public MainWindow()
        {
            InitializeComponent();
            model = null;
            addTextModel = null;
            polygonModel = null;
            points = new List<Point>();
            collection = new List<UIElement>();
            this.DataContext = this;
        }
        #region Left Right mouse clicks
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_polygon.IsChecked)
            {
                DrawPolygon();
            }
          
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_ellipse.IsChecked)
            {
                points.Add(e.GetPosition(canvas));
                DrawEllipseClicked();
            }
            if (_polygon.IsChecked)
            {
                points.Add(e.GetPosition(canvas));
            }
            if (_text.IsChecked)
            {
                points.Add(e.GetPosition(canvas));
                DrawTextClicked();
            }
        }

        #endregion

        #region DrawElipse

        private void DrawEllipseClicked()
        {
            DrawElipse el = new DrawElipse();
            el.ShowDialog();

            Ellipse ellipse = new Ellipse();

            ellipse.Height = model.Height;
            ellipse.Width = model.Width;
            ellipse.StrokeThickness = model.StrokeThic;
            ellipse.Fill = model.Fill;
            ellipse.Stroke = model.StrokeFill;
            
            ellipse.MouseLeftButtonDown += Ellipse_MouseLeftButtonDown;



            Grid grid = new Grid();
            grid.Children.Add(ellipse);

            if(model.Text!="" && model.TextColour != null)
            {
                Label label = new Label() { Content = model.Text, Foreground = model.TextColour, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                grid.Children.Add(label);
            }
           

            Point point = points.Last();
            points.Remove(point);

            coordinates.Visibility = Visibility.Visible;
            coordinates.Text = point.ToString();
            _coordinates.Visibility = Visibility.Visible;


            Canvas.SetLeft(grid, point.X);
            Canvas.SetTop(grid, point.Y);

            canvas.Children.Add(grid);
            collection.Add(grid);
            counter++;

            UnCheck();
            EnableFunctions();
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EllipseChange el = new EllipseChange();
            el.ShowDialog();
            Ellipse ellipse = null;
            Grid grid = null;
            int counter = canvas.Children.Count - collection.Count;
            for (int i = counter; i < canvas.Children.Count; i++)
            {
                try
                {
                    grid = (Grid)canvas.Children[i];
                    if (grid.Children.Contains((Ellipse)sender))
                    {
                        ellipse = (Ellipse)grid.Children[grid.Children.IndexOf((Ellipse)sender)];
                        break;
                    }
                }
                catch (Exception) { }
                
            }

         
            if (ellipse == null)
                return;
            if (ellipseChangeModel.StrokeFill != null)
            {
                ellipse.Stroke = ellipseChangeModel.StrokeFill;
            }
            if (ellipseChangeModel.Fill != null)
            {
                ellipse.Fill = ellipseChangeModel.Fill;
            }
            if (ellipseChangeModel.StrokeThickess != -1)
            {
                ellipse.StrokeThickness = ellipseChangeModel.StrokeThickess;
            }
            int indexGrid = canvas.Children.IndexOf(grid);
            canvas.Children.Remove(grid);
            grid.Children.Remove((Ellipse)sender);
            //Maybe we have textbox so we wont to override that 
            grid.Children.Insert(0,ellipse);
            canvas.Children.Insert(indexGrid,grid);
        }

      
        #endregion

        #region DrawPolygon
        private void DrawPolygon()
        {
            
            DrawPolygon pol = new DrawPolygon();
            pol.ShowDialog();
            Polygon polygon = new Polygon();
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            foreach (var item in points)
            {
                polygon.Points.Add(item);
                x.Add(item.X);
                y.Add(item.Y);
            }

            double minX = x.Min();
            double maxX = x.Max();
            double minY = y.Min();
            double maxY = y.Max();

            polygon.Fill = polygonModel.Fill;
            polygon.Stroke = polygonModel.StrokeFill;
            polygon.StrokeThickness = polygonModel.StrokThic;
            polygon.VerticalAlignment = VerticalAlignment.Center;
            polygon.HorizontalAlignment = HorizontalAlignment.Center;
            polygon.Stretch = Stretch.Fill;
            polygon.MouseLeftButtonDown += Polygon_MouseLeftButtonDown;

            Grid grid = new Grid();
            grid.Children.Add(polygon);
            grid.Width = (Math.Abs(minX - maxX) + 10);
            grid.Height = (Math.Abs(minY - maxY) + 10);


            if (polygonModel.Text != "" && polygonModel.TextColour != null)
            {
                Label label = new Label() { Content = polygonModel.Text, Foreground = polygonModel.TextColour, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                grid.Children.Add(label);
            }

            Canvas.SetLeft(grid, minX);
            Canvas.SetTop(grid, minY);
            canvas.Children.Add(grid);
            collection.Add(grid);
            counter++;
            points.Clear();
            UnCheck();
            EnableFunctions();
        }

   
       

        private void Polygon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PolyghonChange pol = new PolyghonChange();
            pol.ShowDialog();
            Polygon polygon = null;
            Grid grid = null;
            int counter = canvas.Children.Count - collection.Count;
            for (int i = counter; i < canvas.Children.Count; i++)
            {
                try
                {
                    grid = (Grid)canvas.Children[i];
                    if (grid.Children.Contains((Polygon)sender))
                    {
                        polygon = (Polygon)grid.Children[grid.Children.IndexOf((Polygon)sender)];
                        break;
                    }
                }
                catch (Exception) { }
            }
       
            if (polygon == null)
                return;
            if (polyghonChangeModle.StrokeFill != null)
            {
                polygon.Stroke = polyghonChangeModle.StrokeFill;
            }
            if (polyghonChangeModle.Fill != null)
            {
                polygon.Fill = polyghonChangeModle.Fill;
            }
            if (polyghonChangeModle.StrokThic != -1)
            {
                polygon.StrokeThickness = polyghonChangeModle.StrokThic;
            }

            int indexGrid = canvas.Children.IndexOf(grid);
            canvas.Children.Remove(grid);
            grid.Children.Remove((Polygon)sender);
            //Maybe we have textbox so we wont to override that 
            grid.Children.Insert(0, polygon);
            canvas.Children.Insert(indexGrid,grid);
        }
        #endregion

        #region AddText
       

        private void DrawTextClicked() {

            AddText add = new AddText();
            add.ShowDialog();

            Point point = points.Last();
            points.Remove(point);

            coordinates.Visibility = Visibility.Visible;
            coordinates.Text = point.ToString();
            _coordinates.Visibility = Visibility.Visible;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = addTextModel.Text;
            textBlock.Foreground = addTextModel.Foregorund;
            textBlock.Background = addTextModel.Background;
            textBlock.FontSize = addTextModel.Size;

            textBlock.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;

            Canvas.SetLeft(textBlock, point.X);
            Canvas.SetTop(textBlock, point.Y);
            canvas.Children.Add(textBlock);
            collection.Add(textBlock);
            counter++;

            UnCheck();
            EnableFunctions();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextChange text = new TextChange();
            text.ShowDialog();
            TextBlock block = (TextBlock)sender;
            int count = canvas.Children.IndexOf(block);
            canvas.Children.Remove(block);
            if(textChangeModel.Foregroung != null)
            {
                block.Foreground = textChangeModel.Foregroung;
            }
            if (textChangeModel.Background != null)
            {
                block.Background = textChangeModel.Background;
            }

            canvas.Children.Insert(count, block);

        }
        #endregion

        #region Undo Redo Clear
        private void Clear(object sender, RoutedEventArgs e)
        {
            canvas.Children.RemoveRange(canvas.Children.Count - counter, canvas.Children.Count);
            counter = collection.Count;
            flag = true;
        }
   
        private void Undo(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                foreach (var item in collection)
                {
                    canvas.Children.Add(item);
                }
                flag = false;
                return;
            }
            if (counter == 0)
                return;
            
            canvas.Children.RemoveAt(canvas.Children.Count - 1);
            counter--;

        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            if (flag || canvas.Children.Count - 1 == collection.Count)
                return;
            canvas.Children.Add(collection[counter++]);
        }
        #endregion
       
        #region Enable Disable
        private void DisableFunctions()
        {
            _ellipse.IsEnabled = false;
            _polygon.IsEnabled = false;
            _text.IsEnabled = false;
            _undo.IsEnabled = false;
            _redo.IsEnabled = false;
            _clear.IsEnabled = false;
            coordinates.Visibility = Visibility.Hidden;
            coordinates.Text = "";
            _coordinates.Visibility = Visibility.Hidden;
        }
        private void EnableFunctions()
        {
            _ellipse.IsEnabled = true;
            _polygon.IsEnabled = true;
            _text.IsEnabled    = true;
            _undo.IsEnabled    = true;
            _redo.IsEnabled    = true;
            _clear.IsEnabled   = true;
        }
        #endregion

        #region Field Checks and UnCheck function
        private void _ellipse_Checked(object sender, RoutedEventArgs e)
        {
            DisableFunctions();
        }

        private void _polygon_Checked(object sender, RoutedEventArgs e)
        {
            DisableFunctions();
        }

        private void _text_Checked(object sender, RoutedEventArgs e)
        {
            DisableFunctions();
        }
        private void UnCheck()
        {
            _polygon.IsChecked = false;
            _text.IsChecked = false;
            _ellipse.IsChecked = false;
        }
        #endregion



        #region MAP !!!

        Dictionary<KeyValuePair<int, int>, UIElement> elementss = new Dictionary<KeyValuePair<int, int>, UIElement>();
        int[,] array = new int[10000, 10000];

        public enum Intersception { Yes, No, Collinear };
        public enum Element { Switch, Node, Substation };

        Element element;
        Element element1;
        bool clicked = false;
        long helperA;
        long helperB;

        public double noviX, noviY;
        Dictionary<Point, Rectangle> inters = new Dictionary<Point, Rectangle>();
        Dictionary<UIElement, Point> dicitonary = new Dictionary<UIElement, Point>();
        Dictionary<long, Point> container = new Dictionary<long, Point>();
        Dictionary<Polyline, double> linijeZaBFS = new Dictionary<Polyline, double>();
        Dictionary<long, Ellipse> pairs = new Dictionary<long, Ellipse>();
   
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            List<Point> points = new List<Point>();


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Geographic.xml");

            XmlNodeList nodeList;
            SubstationEntity sub = new SubstationEntity();

            #region Substations
            nodeList = xmlDoc.DocumentElement.SelectNodes("/NetworkModel/Substations/SubstationEntity");



            foreach (XmlNode node in nodeList)
            {

                sub.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                sub.Name = node.SelectSingleNode("Name").InnerText;
                sub.X = double.Parse(node.SelectSingleNode("X").InnerText);
                sub.Y = double.Parse(node.SelectSingleNode("Y").InnerText);

                ToLatLon(sub.X, sub.Y, 34, out noviX, out noviY);
                x.Add(noviX);
                y.Add(noviY);

                //kreiranje na mapi gde je sa tooltipovima
            }
            foreach (XmlNode node in nodeList)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 5;
                ellipse.Height = 5;
                ellipse.Fill = Brushes.Blue;

                sub.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                sub.Name = node.SelectSingleNode("Name").InnerText;
                sub.X = double.Parse(node.SelectSingleNode("X").InnerText);
                sub.Y = double.Parse(node.SelectSingleNode("Y").InnerText);

                ellipse.ToolTip = sub.Id + " , " + sub.Name;

                ToLatLon(sub.X, sub.Y, 34, out noviX, out noviY);

                noviX = getX(noviX, x.Min(), x.Max());
                noviY = getY(noviY, y.Max(), y.Min());
                pairs.Add(sub.Id, ellipse);
                Calculate(ellipse, sub.Id);

                //kreiranje na mapi gde je sa tooltipovima
            }
            #endregion
            x.Clear();
            y.Clear();
            #region Nodes
            NodeEntity nodeobj = new NodeEntity();

            nodeList = xmlDoc.DocumentElement.SelectNodes("/NetworkModel/Nodes/NodeEntity");

            foreach (XmlNode node in nodeList)
            {


                nodeobj.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                nodeobj.Name = node.SelectSingleNode("Name").InnerText;
                nodeobj.X = double.Parse(node.SelectSingleNode("X").InnerText);
                nodeobj.Y = double.Parse(node.SelectSingleNode("Y").InnerText);

                ToLatLon(nodeobj.X, nodeobj.Y, 34, out noviX, out noviY);
                x.Add(noviX);
                y.Add(noviY);
            }
            foreach (XmlNode node in nodeList)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 5;
                ellipse.Height = 5;
                ellipse.Fill = Brushes.Chocolate;

                nodeobj.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                nodeobj.Name = node.SelectSingleNode("Name").InnerText;
                nodeobj.X = double.Parse(node.SelectSingleNode("X").InnerText);
                nodeobj.Y = double.Parse(node.SelectSingleNode("Y").InnerText);

                ellipse.ToolTip = nodeobj.Id + " , " + nodeobj.Name;

                ToLatLon(nodeobj.X, nodeobj.Y, 34, out noviX, out noviY);


                noviX = getX(noviX, x.Min(), x.Max());
                noviY = getY(noviY, y.Max(), y.Min());

                pairs.Add(nodeobj.Id, ellipse);
                Calculate(ellipse, nodeobj.Id);
                //tacke sa svojim markerima tj tooltipovima
            }

            #endregion
            x.Clear();
            y.Clear();

            #region Switches
            SwitchEntity switchobj = new SwitchEntity();

            nodeList = xmlDoc.DocumentElement.SelectNodes("/NetworkModel/Switches/SwitchEntity");

            foreach (XmlNode node in nodeList)
            {

                switchobj.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                switchobj.Name = node.SelectSingleNode("Name").InnerText;
                switchobj.X = double.Parse(node.SelectSingleNode("X").InnerText);
                switchobj.Y = double.Parse(node.SelectSingleNode("Y").InnerText);
                switchobj.Status = node.SelectSingleNode("Status").InnerText;


                ToLatLon(switchobj.X, switchobj.Y, 34, out noviX, out noviY);
                x.Add(noviX);
                y.Add(noviY);
            }

            foreach (XmlNode node in nodeList)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 5;
                ellipse.Height = 5;
                ellipse.Fill = Brushes.Black;

                switchobj.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                switchobj.Name = node.SelectSingleNode("Name").InnerText;
                switchobj.X = double.Parse(node.SelectSingleNode("X").InnerText);
                switchobj.Y = double.Parse(node.SelectSingleNode("Y").InnerText);
                switchobj.Status = node.SelectSingleNode("Status").InnerText;

                ellipse.ToolTip = switchobj.Id + " , " + switchobj.Name;
                ToLatLon(switchobj.X, switchobj.Y, 34, out noviX, out noviY);


                noviX = getX(noviX, x.Min(), x.Max());
                noviY = getY(noviY, y.Max(), y.Min());
                Calculate(ellipse, switchobj.Id);
                pairs.Add(switchobj.Id, ellipse);
                //switch sa svojim tooltipoivima
                //MessageBox.Show(noviX.ToString() + "  ,  " + noviY.ToString());
            }
            //MessageBox.Show(counterX.ToString() + " , " + counterY.ToString());
            #endregion

            #region Linije

            LineEntity l = new LineEntity();
            List<KeyValuePair<long, long>> connections = new List<KeyValuePair<long, long>>();
            Dictionary<int, LineEntity> entities = new Dictionary<int, LineEntity>();
            int counter = 0;
            nodeList = xmlDoc.DocumentElement.SelectNodes("/NetworkModel/Lines/LineEntity");
            foreach (XmlNode node in nodeList)
            {
                l.Id = long.Parse(node.SelectSingleNode("Id").InnerText);
                l.Name = node.SelectSingleNode("Name").InnerText;
                if (node.SelectSingleNode("IsUnderground").InnerText.Equals("true"))
                {
                    l.IsUnderground = true;
                }
                else
                {
                    l.IsUnderground = false;
                }
                l.R = float.Parse(node.SelectSingleNode("R").InnerText);
                l.ConductorMaterial = node.SelectSingleNode("ConductorMaterial").InnerText;
                l.LineType = node.SelectSingleNode("LineType").InnerText;
                l.ThermalConstantHeat = long.Parse(node.SelectSingleNode("ThermalConstantHeat").InnerText);
                l.FirstEnd = long.Parse(node.SelectSingleNode("FirstEnd").InnerText);
                l.SecondEnd = long.Parse(node.SelectSingleNode("SecondEnd").InnerText);

                if (l.FirstEnd == l.SecondEnd)
                    continue;
                if (!container.ContainsKey(l.FirstEnd) || !container.ContainsKey(l.SecondEnd))
                    continue;
                if (connections.Contains(new KeyValuePair<long, long>(l.SecondEnd, l.FirstEnd)))
                    continue;
                connections.Add(new KeyValuePair<long, long>(l.FirstEnd, l.SecondEnd));
                entities.Add(counter++, l);
            }
            #endregion



            int brojac = 0;
            foreach (var item in connections)
            {
                Polyline linija = new Polyline();
                Point a = container[item.Key];
                Point b = container[item.Value];

                if (a.X == b.X && a.Y == b.Y)
                    continue;




                linija.StrokeThickness = 1;
                linija.Stroke = Brushes.Green;
                linija.ToolTip = entities[brojac].Id + " , " + entities[brojac].Name + " , " + item.Key + "  , " + item.Value;
                brojac++;

                #region LinesDraw
                if (a.X == b.X)
                {
                    if (a.Y > b.Y)
                    {
                        PointCollection pointts = new PointCollection();
                        pointts.Add(new System.Windows.Point(a.X + 2, a.Y - 5));
                        pointts.Add(new System.Windows.Point(b.X + 2, b.Y));
                        linija.Points = pointts;
                    }
                    else
                    {
                        PointCollection pointts = new PointCollection();
                        pointts.Add(new System.Windows.Point(a.X + 2, a.Y));
                        pointts.Add(new System.Windows.Point(b.X + 2, b.Y - 5));
                        linija.Points = pointts;
                    }

                }
                if (a.Y == b.Y)
                {
                    if (a.X > b.X)
                    {
                        PointCollection pointts = new PointCollection();
                        pointts.Add(new System.Windows.Point(a.X, a.Y - 2));
                        pointts.Add(new System.Windows.Point(b.X + 5, b.Y - 2));
                        linija.Points = pointts;
                    }
                    else
                    {
                        PointCollection pointts = new PointCollection();
                        pointts.Add(new System.Windows.Point(a.X + 5, a.Y - 2));
                        pointts.Add(new System.Windows.Point(b.X, b.Y - 2));
                        linija.Points = pointts;
                    }

                }

                if (a.X > b.X && a.Y > b.Y)
                {
                    PointCollection pointts = new PointCollection();
                    pointts.Add(new System.Windows.Point(a.X + 2, a.Y - 5));
                    pointts.Add(new System.Windows.Point(a.X + 2, b.Y - 2));
                    pointts.Add(new System.Windows.Point(b.X + 5, b.Y - 2));
                    linija.Points = pointts;
                }


                if (a.X > b.X && a.Y < b.Y)
                {
                    PointCollection pointts = new PointCollection();
                    pointts.Add(new System.Windows.Point(a.X, a.Y - 2));
                    pointts.Add(new System.Windows.Point(b.X + 2, a.Y - 2));
                    pointts.Add(new System.Windows.Point(b.X + 2, b.Y - 5));
                    linija.Points = pointts;

                }


                if (a.X < b.X && a.Y > b.Y)
                {
                    PointCollection pointts = new PointCollection();
                    pointts.Add(new System.Windows.Point(a.X + 5, a.Y - 2));
                    pointts.Add(new System.Windows.Point(b.X + 2, a.Y - 2));
                    pointts.Add(new System.Windows.Point(b.X + 2, b.Y));
                    linija.Points = pointts;

                }


                if (a.X < b.X && a.Y < b.Y)
                {
                    PointCollection pointts = new PointCollection();
                    pointts.Add(new System.Windows.Point(a.X + 2, a.Y));
                    pointts.Add(new System.Windows.Point(a.X + 2, b.Y - 2));
                    pointts.Add(new System.Windows.Point(b.X, b.Y - 2));
                    linija.Points = pointts;

                }
                #endregion
                linija.MouseRightButtonDown += Linija_MouseRightButtonDown; ;

                Check(linija);

            }


        }


        private void Check(Polyline line)
        {
 
            for (int i = 4392; i < canvas.Children.Count; i++)
            {

                Polyline pp = canvas.Children[i] as Polyline;
                if (pp == null)
                    continue;
                if (pp.Points.Count == 2 && line.Points.Count == 2)
                {
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Collinear))
                    {
                        if (pp.Points[0].Y == line.Points[0].Y)
                        {
                            Point pointt = new Point(line.Points[1].X, line.Points[1].Y);
                            line.Points.Remove(pointt);
                            line.Points.Add(new Point(line.Points[0].X, line.Points[0].Y - 10));
                            line.Points.Add(new Point(pointt.X, line.Points[0].Y - 10));
                            line.Points.Add(pointt);
                        }
                        else
                        {
                            Point pointt = new Point(line.Points[1].X, line.Points[1].Y);
                            line.Points.Remove(pointt);
                            line.Points.Add(new Point(line.Points[0].X + 10, line.Points[0].Y));
                            line.Points.Add(new Point(line.Points[0].X + 10, pointt.Y));
                            line.Points.Add(pointt);
                        }
                    }
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;

                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);

                    }

                }
                if (pp.Points.Count == 2 && line.Points.Count == 3)
                {
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Collinear))
                    {
                        if (pp.Points[0].Y > line.Points[0].Y)
                        {
                         
                            //line.Points.Insert(1,new Point(line.Points[0].X, line.Points[0].Y - 10));
                            //line.Points.Insert(2,new Point(pp.Points[0].X + 10, line.Points[0].Y - 10));
                            //line.Points.Insert(3,new Point(pp.Points[0].X + 10, line.Points[3].Y));
                            //line.Stroke = Brushes.Black;
                        }
                        else
                        {
                            //line.Points[1] = new Point(line.Points[0].X, line.Points[2].Y);
                        }
                        
                  
                    }
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[1], line.Points[2]).Equals(Intersception.Collinear))
                    {
                        //line.StrokeThickness = 30;
                     
                    }
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[1], line.Points[2]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[0], pp.Points[1], line.Points[1], line.Points[2]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }
                }
                if (pp.Points.Count == 3 && line.Points.Count == 2)
                {
                    //if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Collinear))
                    //{
                    //    coll = true;
                    //    counter++;
                    //    break;
                    //}
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);
                        canvas.Children.Add(rectangle);
                    }
                    //if (doIntersect(pp.Points[1], pp.Points[2], line.Points[0], line.Points[1]).Equals(Intersception.Collinear))
                    //{
                    //    coll = true;
                    //    counter++;
                    //    break;
                    //}
                    if (doIntersect(pp.Points[1], pp.Points[2], line.Points[0], line.Points[1]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[1], pp.Points[2], line.Points[0], line.Points[1]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }
                }
                if (pp.Points.Count == 3 && line.Points.Count == 3)
                {
                    //if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Collinear))
                    //{
                    //    coll = true;
                    //    counter++;
                    //    break;
                    //}
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[0], pp.Points[1], line.Points[0], line.Points[1]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }

                    //if (doIntersect(pp.Points[0], pp.Points[1], line.Points[1], line.Points[2]).Equals(Intersception.Collinear))
                    //{
                    //    coll = true;
                    //    counter++;
                    //    break;
                    //}
                    if (doIntersect(pp.Points[0], pp.Points[1], line.Points[1], line.Points[2]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[0], pp.Points[1], line.Points[1], line.Points[2]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }

                    //if (doIntersect(pp.Points[1], pp.Points[2], line.Points[0], line.Points[1]).Equals(Intersception.Collinear))
                    //{
                    //    coll = true; counter++;
                    //    break;
                    //}
                    if (doIntersect(pp.Points[1], pp.Points[2], line.Points[0], line.Points[1]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[1], pp.Points[2], line.Points[0], line.Points[1]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }

                    //if (doIntersect(pp.Points[1], pp.Points[2], line.Points[1], line.Points[2]).Equals(Intersception.Collinear))
                    //{
                    //    coll = true;
                    //    counter++;
                    //    break;
                    //}
                    if (doIntersect(pp.Points[1], pp.Points[2], line.Points[1], line.Points[2]).Equals(Intersception.Yes))
                    {
                        Point inter = Interscept(pp.Points[1], pp.Points[2], line.Points[1], line.Points[2]);
                        Rectangle rectangle = new Rectangle();
                        rectangle.Fill = Brushes.Gray;
                        rectangle.Width = 7;
                        rectangle.Height = 7;
                        Canvas.SetLeft(rectangle, inter.X - 3);
                        Canvas.SetTop(rectangle, inter.Y - 3);

                        canvas.Children.Add(rectangle);
                    }


                }


            }
            canvas.Children.Add(line);
        }

        private void Linija_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!clicked)
            {
                Polyline linija = (Polyline)sender;
                string[] data = linija.ToolTip.ToString().Split(',');
                helperA = long.Parse(data[2]);
                helperB = long.Parse(data[3]);


                Ellipse ee = pairs[helperA];
                Ellipse ee1 = pairs[helperB];

                if (ee.ToolTip.ToString().Contains("TSH"))
                {
                    element = Element.Substation;
                }
                if (ee.ToolTip.ToString().Contains("BUSNODE"))
                {
                    element = Element.Node;
                }
                if (ee.ToolTip.ToString().Contains("disconn") || ee.ToolTip.ToString().Contains("loadbreaker"))
                {
                    element = Element.Switch;
                }

                if (ee1.ToolTip.ToString().Contains("TSH"))
                {
                    element1 = Element.Substation;
                }
                if (ee1.ToolTip.ToString().Contains("BUSNODE"))
                {
                    element1 = Element.Node;
                }
                if (ee1.ToolTip.ToString().Contains("disconn") || ee1.ToolTip.ToString().Contains("loadbreaker"))
                {
                    element1 = Element.Switch;
                }
                ee.Fill = Brushes.Azure;
                ee1.Fill = Brushes.Azure;

                canvas.Children.Remove(ee);
                canvas.Children.Remove(ee1);

                canvas.Children.Add(ee);
                canvas.Children.Add(ee1);
                clicked = true;
            }
            else
            {
                Polyline linija = (Polyline)sender;
                string[] data = linija.ToolTip.ToString().Split(',');
                helperA = long.Parse(data[2]);
                helperB = long.Parse(data[3]);

                Ellipse ee = pairs[helperA];
                Ellipse ee1 = pairs[helperB];

                if (element == Element.Switch)
                {
                    ee.Fill = Brushes.Black;
                }
                if (element == Element.Node)
                {
                    ee.Fill = Brushes.Chocolate;
                }
                if (element == Element.Substation)
                {
                    ee.Fill = Brushes.Blue;
                }

                if (element1 == Element.Switch)
                {
                    ee1.Fill = Brushes.Black;
                }
                if (element1 == Element.Node)
                {
                    ee1.Fill = Brushes.Chocolate;
                }
                if (element1 == Element.Substation)
                {
                    ee1.Fill = Brushes.Blue;
                }


                canvas.Children.Remove(ee);
                canvas.Children.Remove(ee1);

                canvas.Children.Add(ee);
                canvas.Children.Add(ee1);
                clicked = false;
            }

        }


        #region Lines cross
        private double Slope(Point p1, Point p2)
        {
            double _slope = 1e+10;
            if ((p2.X - p1.X) != 0)
                _slope = (p2.Y - p1.Y) / (p2.X - p1.X);
            return _slope;
        }
        private Point Interscept(Point p1, Point p2, Point q1, Point q2)
        {
            double a1 = p1.Y - Slope(p1, p2) * p1.X;
            double a2 = q1.Y - Slope(q1, q2) * q1.X;

            double x = (a1 - a2) / (Slope(q1, q2) - Slope(p1, p2));
            double y = a2 + Slope(q1, q2) * x;
            return new Point(Math.Floor(x), Math.Floor(y));
        }
        #endregion

        #region Interscept

        // Given three collinear points p, q, r, the function checks if
        // point q lies on line segment 'pr'
        static Boolean onSegment(System.Windows.Point p, System.Windows.Point q, System.Windows.Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;

            return false;
        }

        // To find orientation of ordered triplet (p, q, r).
        // The function returns following values
        // 0 --> p, q and r are collinear
        // 1 --> Clockwise
        // 2 --> Counterclockwise
        static int orientation(System.Windows.Point p, System.Windows.Point q, System.Windows.Point r)
        {
            // See https://www.geeksforgeeks.org/orientation-3-ordered-points/
            // for details of below formula.
            int val = (int)((q.Y - p.Y) * (r.X - q.X) -
                    (q.X - p.X) * (r.Y - q.Y));

            if (val == 0) return 0; // collinear

            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        // The main function that returns true if line segment 'p1q1'
        // and 'p2q2' intersect.
        static Intersception doIntersect(System.Windows.Point p1, System.Windows.Point q1, System.Windows.Point p2, System.Windows.Point q2)
        {
            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            // General case
            if (o1 != o2 && o3 != o4)
                return Intersception.Yes;

            // Special Cases
            // p1, q1 and p2 are collinear and p2 lies on segment p1q1
            if (o1 == 0 && onSegment(p1, p2, q1)) return Intersception.Collinear;

            // p1, q1 and q2 are collinear and q2 lies on segment p1q1
            if (o2 == 0 && onSegment(p1, q2, q1)) return Intersception.Collinear;

            // p2, q2 and p1 are collinear and p1 lies on segment p2q2
            if (o3 == 0 && onSegment(p2, p1, q2)) return Intersception.Collinear;

            // p2, q2 and q1 are collinear and q1 lies on segment p2q2
            if (o4 == 0 && onSegment(p2, q1, q2)) return Intersception.Collinear; ;

            return Intersception.No; // Doesn't fall in anY of the above cases
        }


        #endregion


        #region Coordinates
        private double getX(double x, double minLon, double maxLon)
        {
            var position = (x - minLon) / (maxLon - minLon);
            return Math.Floor(1000 * position);
        }
        private double getY(double y, double maxLat, double minLat)
        {
            var position = (y - minLat) / (maxLat - minLat);
            return Math.Floor(1000 * position);
        }
        //From UTM to Latitude and longitude in decimal
        public static void ToLatLon(double utmX, double utmY, int zoneUTM, out double latitude, out double longitude)
        {
            bool isNorthHemisphere = true;

            var diflat = -0.00066286966871111111111111111111111111;
            var diflon = -0.0003868060578;

            var zone = zoneUTM;
            var c_sa = 6378137.000000;
            var c_sb = 6356752.314245;
            var e2 = Math.Pow((Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)), 0.5) / c_sb;
            var e2cuadrada = Math.Pow(e2, 2);
            var c = Math.Pow(c_sa, 2) / c_sb;
            var x = utmX - 500000;
            var y = isNorthHemisphere ? utmY : utmY - 10000000;

            var s = ((zone * 6.0) - 183.0);
            var lat = y / (c_sa * 0.9996);
            var v = (c / Math.Pow(1 + (e2cuadrada * Math.Pow(Math.Cos(lat), 2)), 0.5)) * 0.9996;
            var a = x / v;
            var a1 = Math.Sin(2 * lat);
            var a2 = a1 * Math.Pow((Math.Cos(lat)), 2);
            var j2 = lat + (a1 / 2.0);
            var j4 = ((3 * j2) + a2) / 4.0;
            var j6 = ((5 * j4) + Math.Pow(a2 * (Math.Cos(lat)), 2)) / 3.0;
            var alfa = (3.0 / 4.0) * e2cuadrada;
            var beta = (5.0 / 3.0) * Math.Pow(alfa, 2);
            var gama = (35.0 / 27.0) * Math.Pow(alfa, 3);
            var bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
            var b = (y - bm) / v;
            var epsi = ((e2cuadrada * Math.Pow(a, 2)) / 2.0) * Math.Pow((Math.Cos(lat)), 2);
            var eps = a * (1 - (epsi / 3.0));
            var nab = (b * (1 - epsi)) + lat;
            var senoheps = (Math.Exp(eps) - Math.Exp(-eps)) / 2.0;
            var delt = Math.Atan(senoheps / (Math.Cos(nab)));
            var tao = Math.Atan(Math.Cos(delt) * Math.Tan(nab));

            longitude = ((delt * (180.0 / Math.PI)) + s) + diflon;
            latitude = ((lat + (1 + e2cuadrada * Math.Pow(Math.Cos(lat), 2) - (3.0 / 2.0) * e2cuadrada * Math.Sin(lat) * Math.Cos(lat) * (tao - lat)) * (tao - lat)) * (180.0 / Math.PI)) + diflat;
        }


        #region Calculating
        private void Calculate(UIElement element, long id)
        {
            double broj = noviX;
            if (broj < 100)
            {
                noviX *= 10;
            }
            if (broj >= 100 && broj < 200)
            {
                noviX *= 10;

            }
            if (broj >= 200 && broj < 300)
            {
                noviX *= 10;
            }
            if (broj >= 300 && broj < 400)
            {
                noviX *= 10;
            }
            if (broj >= 400 && broj < 500)
            {
                noviX *= 10;
            }
            if (broj >= 500 && broj < 600)
            {
                noviX *= 10;
            }
            if (broj >= 600 && broj < 700)
            {
                noviX *= 10;
            }
            if (broj >= 700 && broj < 800)
            {
                noviX *= 10;
            }
            if (broj >= 800 && broj < 900)
            {
                noviX *= 10;
            }
            if (broj >= 900 && broj < 1000)
            {
                noviX *= 10;
            }

            broj = noviY;

            if (broj < 100)
            {
                noviY *= 10;
            }
            if (broj >= 100 && broj < 200)
            {
                noviY *= 10;
            }
            if (broj >= 200 && broj < 300)
            {
                noviY *= 10;
            }
            if (broj >= 300 && broj < 400)
            {
                noviY *= 10;
            }
            if (broj >= 400 && broj < 500)
            {
                noviY *= 10;
            }
            if (broj >= 500 && broj < 600)
            {
                noviY *= 10;
            }
            if (broj >= 600 && broj < 700)
            {
                noviY *= 10;
            }
            if (broj >= 700 && broj < 800)
            {
                noviY *= 10;
            }
            if (broj >= 800 && broj < 900)
            {
                noviY *= 10;
            }
            if (broj >= 900 && broj < 1000)
            {
                noviY *= 10;
            }

            dicitonary.Add(element, new Point(noviY, noviX));
            container.Add(id, new Point(noviY, 10000 - noviX)); 

            if (array[(int)noviX, (int)noviY] == 1)
            {
                AddNear();
            }
            array[(int)noviX, (int)noviY] = 1;
            elementss.Add(new KeyValuePair<int, int>((int)noviX, (int)noviY), element);
            Canvas.SetLeft(element, noviY);
            Canvas.SetBottom(element, noviX);
            canvas.Children.Add(element);
        }
        private void AddNear()
        {
            int count = 0;
            while (array[(int)noviX, (int)noviY] == 1)
            {
                count %= 8;
                switch (count)
                {
                    case 0:
                        {
                            noviX += 30;
                            break;
                        }
                    case 1:
                        {
                            noviY += 30;
                            break;
                        }
                    case 2:
                        {
                            noviX -= 30;
                            break;
                        }
                    case 3:
                        {
                            noviX -= 30;
                            break;
                        }

                    case 4:
                        {
                            noviY -= 30;
                            break;
                        }
                    case 5:
                        {
                            noviY -= 30;
                            break;
                        }
                    case 6:
                        {

                            noviY -= 30;
                            break;
                        }
                    case 7:
                        {
                            noviX += 30;
                            break;
                        }

                }
                count++;
            }
        }
        #endregion
        #endregion

        #endregion
    }
}
