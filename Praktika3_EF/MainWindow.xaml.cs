using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Praktika3_EF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UNLV_IncEntities context = new UNLV_IncEntities();
        public MainWindow()
        {
            InitializeComponent();
            VivodTablic();
        }

        private void VivodTablic()
        {
            var orderDetails = from o in context.Orders
                               join c in context.Clients on o.ID_Client equals c.ID_Client
                               join g in context.Goods on o.ID_Good equals g.ID_Good
                               select new OrderDetail
                               {
                                   FirstNameClient = c.FirstNameClient,
                                   SurNameClient = c.SurNameClient,
                                   MiddleNameClient = c.MiddleNameClient,
                                   PasportSeriya = c.PasportSeriya,
                                   PasportNumber = c.PasportNumber,
                                   NameGood = g.NameGood,
                                   GoodNumber = g.GoodNumber,
                                   GoodCost = g.GoodCost,
                                   GoodNalichie = g.GoodNalichie,
                                   Quantity = o.Quantity,
                                   OrderDate = o.OrderDate
                               };
            FullTablica.ItemsSource = orderDetails.ToList();
        }
        public class OrderDetail
        {
            public string FirstNameClient { get; set; }
            public string SurNameClient { get; set; }
            public string MiddleNameClient { get; set; }
            public int PasportSeriya { get; set; }
            public int PasportNumber { get; set; }
            public string NameGood { get; set; }
            public int GoodNumber { get; set; }
            public decimal GoodCost { get; set; }
            public int GoodNalichie { get; set; }
            public int Quantity { get; set; }
            public DateTime OrderDate { get; set; }
        }
    };
}

