// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using Lua;
using Lua.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace CodeSmile.Luny
{
	public static class LuaStateExt
	{
		public static ValueTask<LuaValue[]> DoStringAsync(this LuaState state, String source, String? chunkName,
			LuaTable arguments, CancellationToken cancellationToken = default)
		{
			var access = state.RootAccess;
			access.ThrowIfInvalid();
			var closure = access.State.Load(source, chunkName ?? source);
			access.Thread.Stack.Push(arguments);
			return access.DoClosureAsync(closure, 1, cancellationToken);
		}

		public static async ValueTask<LuaValue[]> DoClosureAsync(this LuaThreadAccess access, LuaClosure closure,
			Int32 argumentCount, CancellationToken cancellationToken = default)
		{
			access.ThrowIfInvalid();
			var count = await access.RunAsync(closure, argumentCount, cancellationToken);
			using var results = access.ReadReturnValues(count);
			return results.AsSpan().ToArray();
		}
	}
}
