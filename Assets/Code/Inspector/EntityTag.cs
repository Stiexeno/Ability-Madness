using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class EntityTag : PropertyAttribute
{
	public string tag;

	public EntityTag(string tag)
	{
		this.tag = tag;
	}
}