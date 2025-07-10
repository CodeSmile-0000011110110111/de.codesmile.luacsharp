// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using Lua.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Lua.Unity
{
	public static class LuaThreadAccessExt
	{
		public static ValueTask<LuaValue[]> DoStringAsync(this LuaThreadAccess access, String source, String chunkName,
			LuaTable arguments, CancellationToken cancellationToken = default)
		{
			access.ThrowIfInvalid();
			var closure = access.State.Load(source, chunkName ?? source);
			return DoClosureAsync(access, closure, arguments, cancellationToken);
		}

		public static ValueTask<LuaValue[]> DoBytesAsync(this LuaThreadAccess access, ReadOnlySpan<Byte> source,
			String chunkName, LuaTable arguments, CancellationToken cancellationToken = default)
		{
			access.ThrowIfInvalid();
			var closure = access.State.Load(source, chunkName);
			return DoClosureAsync(access, closure, arguments, cancellationToken);
		}

		public static async ValueTask<LuaValue[]> DoFileAsync(this LuaThreadAccess access, String path, LuaTable arguments,
			CancellationToken cancellationToken = default)
		{
			access.ThrowIfInvalid();
			var closure = await access.State.LoadFileAsync(path, "bt", null, cancellationToken);
			return await DoClosureAsync(access, closure, arguments, cancellationToken);
		}

		public static async ValueTask<LuaValue[]> DoClosureAsync(this LuaThreadAccess access, LuaClosure closure,
			LuaTable arguments, CancellationToken cancellationToken = default)
		{
			access.ThrowIfInvalid();
			access.Thread.Stack.Push(arguments);
			var count = await access.RunAsync(closure, 1, cancellationToken);
			using var results = access.ReadTopValues(count);
			return results.AsSpan().ToArray();
		}
	}
}
