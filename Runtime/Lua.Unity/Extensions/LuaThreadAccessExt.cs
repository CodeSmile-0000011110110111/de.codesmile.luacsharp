// Copyright (C) 2021-2025 Steffen Itterheim
// Refer to included LICENSE file for terms and conditions.

using Lua;
using Lua.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSmile.Luny
{
	public static class LuaThreadAccessExt
	{

		public static ValueTask<LuaValue[]> DoStringAsync(this LuaThreadAccess access, string source, string? chunkName, LuaTable environment, CancellationToken cancellationToken = default)
		{
			access.ThrowIfInvalid();
			var closure = access.State.Load(source, chunkName ?? source, environment);
			return access.DoClosureAsync(closure, cancellationToken);
		}
	}
}
