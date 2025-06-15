@echo off
xcopy "..\Lua-CSharp-Official\src\Lua\bin\Debug\netstandard2.1\*.*" "Runtime\LuaCSharp\lib\netstandard2.1\Debug" /Y /V
xcopy "..\Lua-CSharp-Official\src\Lua\bin\Release\netstandard2.1\*.*" "Runtime\LuaCSharp\lib\netstandard2.1\Release" /Y /V
pause

