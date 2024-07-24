using System;
using UnityEngine;

namespace AbilityMadness.Editor.Utilities
{
	public abstract class EditorScope : IDisposable
	{
		private bool _disposed;

		protected abstract void CloseScope();

		~EditorScope()
		{
			if (this._disposed)
				return;
			Debug.LogError((object)"Scope was not disposed! You should use the 'using' keyword or manually call Dispose.");
			this.Dispose();
		}

		public void Dispose()
		{
			if (this._disposed)
				return;
			this._disposed = true;
			this.CloseScope();
		}
	}
	
	public class ColorScope : EditorScope
	{
		private readonly Color _prevBackground;
		private readonly Color _prevContent;
		private readonly Color _prevMain;

		public ColorScope(Color? background, Color? content = null, Color? main = null)
		{
			this._prevBackground = GUI.backgroundColor;
			this._prevContent = GUI.contentColor;
			this._prevMain = GUI.color;
			if (background.HasValue)
				GUI.backgroundColor = background.Value;
			if (content.HasValue)
				GUI.contentColor = content.Value;
			if (!main.HasValue)
				return;
			GUI.color = main.Value;
		}

		protected override void CloseScope()
		{
			GUI.backgroundColor = this._prevBackground;
			GUI.contentColor = this._prevContent;
			GUI.color = this._prevMain;
		}
	}
}