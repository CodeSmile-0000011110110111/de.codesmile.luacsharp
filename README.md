# de.codesmile.luacsharp
[LuaCSharp](https://github.com/nuskey8/Lua-CSharp) wrapped as a Unity package, installable with Unity PackageManager instead of NuGetForUnity.

I just don't like having NuGet installed _into_ my projects. ;)

# Installation

- Open Package Manager
- Choose **Install package from Git URL...**
- Enter this URL: `https://github.com/CodeSmile-0000011110110111/de.codesmile.luacsharp`

Beats NuGet every time when you know what you want!

# Changes

I intend to add a few "quality of service" changes. This is what's different compared to the NuGet package:

- Version 0.5-dev already available (consider it preview, use the '0.4.2' tag if you want the latest official version)
  - 0.5 provides a [significant speed bump](https://github.com/nuskey8/Lua-CSharp/issues/156) when calling Lua functions from C#. 
- Both Debug and Release DLLs are included. Debug DLL is automatically used when making a "Development Build" ie when the `DEBUG` symbol is defined.
- PDB files included for debugging sessions
- Folder structure changed to adhere to Unity's package structure

# More Lua goodies ...

My goal is to use Lua in Unity for everything. 

### Call me crazy - I call it [Luny! :D](https://lunyscript.com/)

For the retro feelings, I also provide packages of the other two Unity Lua frameworks:

- [MoonSharp 2.0.0 Unity package](https://github.com/CodeSmile-0000011110110111/de.codesmile.moonsharp)
- [NLua 1.7.5 Unity package](https://github.com/CodeSmile-0000011110110111/de.codesmile.nlua)
