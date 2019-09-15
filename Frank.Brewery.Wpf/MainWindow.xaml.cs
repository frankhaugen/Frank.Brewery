using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Entities;
using Frank.Brewery.Enums;
using Frank.Brewery.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Frank.Brewery.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IYeastService _yeastService;
        private readonly IEnumService _enumService;
        private readonly IMapper _mapper;

        public List<Yeast> Yeasts { get; set; }
        public Amount AlchoholTolerance { get; set; }

        public MainWindow(IYeastService yeastService, IEnumService enumService, IMapper mapper)
        {
            _yeastService = yeastService;
            _enumService = enumService;
            _mapper = mapper;
            InitializeComponent();
            AmountsDropdown.ItemsSource = _mapper.Map<List<ComboBoxItem>>(_enumService.Amounts());
            FermentableTypesDropdown.ItemsSource = _mapper.Map<List<ComboBoxItem>>(_enumService.FermentableTypes());
            BeerCategoriesDropdown.ItemsSource = _mapper.Map<List<ComboBoxItem>>(_enumService.BeerCategories());
            BeerTypesDropdown.ItemsSource = _mapper.Map<List<ComboBoxItem>>(_enumService.BeerTypes());
            //Yeasts = _yeastService.GetAll().Result;

        }

        private void ExperimentalButton_OnClick(object sender, RoutedEventArgs e)
        {
            var list = new List<EnumDto>()
            {
                _mapper.Map<EnumDto>(AmountsDropdown.SelectedItem),
                _mapper.Map<EnumDto>(FermentableTypesDropdown.SelectedItem),
                _mapper.Map<EnumDto>(BeerCategoriesDropdown.SelectedItem),
                _mapper.Map<EnumDto>(BeerTypesDropdown.SelectedItem),
            };
            MessageBox.Show(JsonConvert.SerializeObject(list, Formatting.Indented));

        }
    }
}
