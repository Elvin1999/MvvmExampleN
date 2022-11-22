using MvvmExampleN.Commands;
using MvvmExampleN.Models;
using MvvmExampleN.Repositories;
using MvvmExampleN.Views;
using MvvmExampleN.Views.UC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmExampleN.ViewModels
{
    public class AppViewModel:BaseViewModel
    {
        public FakeRepo PrinterRepository { get; set; }

        public ObservableCollection<Printer> Printers { get; set; }

        private Printer printer;

        public Printer Printer
        {
            get { return printer; }
            set { printer = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }

        public RelayCommand AddUserControlsCommand { get; set; }

        public AppViewModel()
        {
            PrinterRepository = new FakeRepo();
            Printers = new ObservableCollection<Printer>(PrinterRepository.GetAll());

            AddUserControlsCommand = new RelayCommand((myPanel) =>
            {
                //var uc1 = new SpecialUC();
                //var uc2 = new SpecialUC();
                var panel = myPanel as WrapPanel;

                //panel.Children.Add(uc1);
                //panel.Children.Add(uc2);


                foreach (var printer in Printers)
                {
                    var vm = new SpecialUCViewModel();
                    vm.PrinterModel = printer.Model;

                    var uc = new SpecialUC();
                    uc.DataContext = vm;

                    panel.Children.Add(uc);

                }



            });


            SelectedCommand = new RelayCommand((p) =>
            {
                var printer = p as Printer;
                Printer = printer;
            });

            AddCommand = new RelayCommand((p) =>
            {
                Printers.Add(new Printer { Color = "Black", Model = "FF-400", Vendor = "Samsung" });
                MessageBox.Show("Printer added successfully");
            });

            EditCommand = new RelayCommand((p) =>
            {
                EditWindow editWindow = new EditWindow();
                var editVM = new EditViewModel();

                editVM.EditPrinter = Printer;

                editWindow.DataContext = editVM;

                editWindow.ShowDialog();
            }, (p) =>
            {
                if (Printer == null) return false;
                    return true;
            });
        }

    }
}
