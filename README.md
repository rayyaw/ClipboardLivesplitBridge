## To install
Download the dll file and put it in the LiveSplit/Components folder where your LiveSplit is installed

## Why use this?

Some games (like Flash games, or games running in a VM) cannot use HTTP output, named pipes, or API calls due to security boundaries enforced by the platform. Instead, the clipboard is used to share data back.

## build with:
& "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe"     ".\ClipboardLivesplitBridge.csproj"

## License
You are free to distribute the compiled binary (.dll) as you wish. While source code contributions are welcome, the source code of this project has all rights reserved for now. Copyright (c) rayyaw, 2026.