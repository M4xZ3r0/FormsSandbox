using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSandbox
{
	public partial class MainView : Form
	{
		private MainViewModel viewModel;

		public MainView()
		{
			InitializeComponent();
			Start();
		}

		private void Start()
		{
			viewModel = new MainViewModel(new MainModel());

			textBox1.DataBindings.Add("Text", viewModel, "Counter");

			button1.Click += new EventHandler(
				async (object sender, EventArgs e) 
				=> await viewModel.IncreaseCounter().ConfigureAwait(true));

			button1.DataBindings.Add("Enabled", viewModel, "CanClick");
		}

	}
}
