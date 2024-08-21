using System;
using System.Collections.Generic;
using System.Linq;
using AbilityMadness.Code.Infrastructure.UI.Factory;

namespace AbilityMadness.Infrastructure.UI
{
	public class UIService : IUIService
	{
		private readonly Dictionary<Type, Window> windows = new();
		private IUIFactory _uiFactor;

		public UIService(IUIFactory uiFactory)
		{
			_uiFactor = uiFactory;
		}

		public T Get<T>() where T : Window
		{
			MakeSureWindowIsNotNull();

			Window window;

			if (!windows.ContainsKey(typeof(T)))
			{
				window = _uiFactor.CreateWindow<T>();
				windows.Add(typeof(T), window);
			}

			window = windows[typeof(T)];

			return window as T;
		}

		public void Open<T>() where T : Window
		{
			var window = Get<T>();
			window.Open();
		}

		public void Close<T>() where T : Window
		{
			var window = Get<T>();
			window.Close();
		}

		private void MakeSureWindowIsNotNull()
		{
			for (int i = windows.Count - 1; i >= 0; i--)
			{
				var elementAt = windows.ElementAt(i);
				Window window = elementAt.Value;

				if (window == null)
					windows.Remove(elementAt.Key);
			}
		}
	}
}
