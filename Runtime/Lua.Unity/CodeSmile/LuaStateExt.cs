// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Lua.Unity
{
	public static class LuaStateExt
	{
		public static ValueTask<LuaValue[]> DoStringAsync(this LuaState state, String source, String chunkName,
			LuaTable arguments, CancellationToken cancellationToken = default) =>
			state.RootAccess.DoStringAsync(source, chunkName, arguments, cancellationToken);

		public static ValueTask<LuaValue[]> DoBytesAsync(this LuaState state, ReadOnlySpan<Byte> source, String chunkName,
			LuaTable arguments, CancellationToken cancellationToken = default) =>
			state.RootAccess.DoBytesAsync(source, chunkName, arguments, cancellationToken);

		public static ValueTask<LuaValue[]> DoFileAsync(this LuaState state, String path, LuaTable arguments,
			CancellationToken cancellationToken = default) => state.RootAccess.DoFileAsync(path, arguments, cancellationToken);
	}
}
