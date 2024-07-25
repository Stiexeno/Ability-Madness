using System.Linq;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace AbilityMadness
{
	public class EntityRootDropdownItem : AdvancedDropdownItem
	{
		public EntityRootDropdownItem(string name) : base(name)
		{
		}

		public override int CompareTo(object o)
		{
			var item = (AdvancedDropdownItem)o;

			var difference = children.Count() - item.children.Count();
			return difference;
		}
	}
}
