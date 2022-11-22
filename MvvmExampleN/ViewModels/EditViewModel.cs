using MvvmExampleN.Commands;
using MvvmExampleN.Models;
using MvvmExampleN.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmExampleN.ViewModels
{
    public class EditViewModel:BaseViewModel
    {
		private Printer editPrinter;

		public Printer EditPrinter
        {
			get { return editPrinter; }
			set { editPrinter = value; OnPropertyChanged(); }
		}

		public ObservableCollection<Printer> Printers { get; set; }

		public RelayCommand AddCommand { get; set; }

		public RelayCommand SaveCommand { get; set; }

		public EditViewModel()
		{
			SaveCommand = new RelayCommand((w) =>
			{
				var window = w as EditWindow;
				window.Close();
			});

			AddCommand = new RelayCommand((a) =>
			{
				var printer = new Printer
				{
					Color = EditPrinter.Color,
					Model = EditPrinter.Model,
					Vendor = EditPrinter.Vendor
				};
				Printers.Add(printer);
				MessageBox.Show("New Printer addedd successfully");
			});

		}
	}
}
