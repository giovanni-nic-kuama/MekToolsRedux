> Build Windows App
> dotnet publish --configuration Release --self-contained --framework "net7.0-windows10.0.19041.0"


> Build Exe with bundled runtime 
> dotnet publish -f net7.0-windows10.0.19041.0 -c Release -p:WindowsPackageType=None -p:WindowsAppSDKSelfContained=true