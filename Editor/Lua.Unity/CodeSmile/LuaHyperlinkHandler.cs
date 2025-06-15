// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Lua.Unity.Editor
{
	internal static class LuaHyperlinkHandler
	{
		[InitializeOnLoadMethod]
		private static void OnLoad()
		{
			EditorGUI.hyperLinkClicked += OnHyperlinkClicked;
		}

		private static void OnHyperlinkClicked(EditorWindow window, HyperLinkClickedEventArgs evt)
		{
			Debug.Log($"hyperlink clicked in {window?.name}: {evt} - {evt.hyperLinkData.Count}");
			foreach (var kvp in evt.hyperLinkData)
				Debug.Log($"\t{kvp.Key}: {kvp.Value}");

			if (evt.hyperLinkData != null && evt.hyperLinkData.TryGetValue("href", out var href) && href.EndsWith(".lua"))
			{
				var line = 1;
				var column = 1;
				if (evt.hyperLinkData.TryGetValue("line", out var lineStr))
					Int32.TryParse(lineStr, out line);
				if (evt.hyperLinkData.TryGetValue("column", out var columnStr))
					Int32.TryParse(columnStr, out column);

				//InternalEditorUtility.OpenFileAtLineExternal()

			}
		}
	}
}
