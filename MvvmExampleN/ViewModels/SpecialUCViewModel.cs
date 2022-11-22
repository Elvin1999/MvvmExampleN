using MvvmExampleN.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmExampleN.ViewModels
{
    public class SpecialUCViewModel:BaseViewModel
    {
		private string printerModel;

		public string PrinterModel
		{
			get { return printerModel; }
			set { printerModel = value; }
		}

		public RelayCommand SelectUCCommand { get; set; }

		public SpecialUCViewModel()
		{
			SelectUCCommand = new RelayCommand((s) =>
			{
				MessageBox.Show(PrinterModel);
			});
		}
	}
}
