using Frank.Brewery.Entities;
using Frank.Brewery.Enums;
using Frank.Brewery.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Frank.Brewery.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IYeastService _yeastService;

        public List<Yeast> Yeasts { get; set; }
        public Amount AlchoholTolerance { get; set; }

        public MainWindow(IYeastService yeastService)
        {
            _yeastService = yeastService;
            InitializeComponent();

            Yeasts = _yeastService.GetAll().Result;
        }
    }
}
