using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FormsSandbox
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private bool _canClick;
		private MainModel _model;
		public MainViewModel(MainModel model)
		{
			_model = model;
			CanClick = true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public bool CanClick
		{
			get { return _canClick; }
			set
			{
				_canClick = value;
				NotifyPropertyChanged(nameof(CanClick));
			}
		}

		public int Counter
		{
			get { return _model.Counter; }
			private set
			{
				_model.Counter = value;
				NotifyPropertyChanged(nameof(Counter));
			}
		}
		public void Execute(object sender, object parameter)
		{
			((ICommand)sender).Execute(parameter);
		}

		public async Task IncreaseCounter()
		{
			CanClick = false;
			await Task.Run(() => System.Threading.Thread.Sleep(1000));
			Counter++;
			CanClick = true;
		}

		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}