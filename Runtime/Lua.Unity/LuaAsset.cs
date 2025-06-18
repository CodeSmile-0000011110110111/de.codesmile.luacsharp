using System;
using UnityEditor;
using UnityEngine;

namespace Lua.Unity
{
	public sealed class LuaAsset : ScriptableObject
	{
		[SerializeField] internal String text;
		public String Text => text;
	}
}
