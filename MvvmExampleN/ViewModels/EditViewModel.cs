using MvvmExampleN.Commands;
using MvvmExampleN.Models;
using MvvmExampleN.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public RelayCommand SaveCommand { get; set; }

		public EditViewModel()
		{
			SaveCommand = new RelayCommand((w) =>
			{
				var window = w as EditWindow;
				window.Close();
			});
		}
	}
}
