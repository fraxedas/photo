Echo "Upgrade to the latest version of NuGet.exe"
.nuget\NuGet Update -self

Echo "Create and buils the NuGet Package"
cd photo.exif
DEL /F /S /Q /A *.nupkg
..\.nuget\NuGet Pack photo.exif.csproj -Prop Platform=AnyCPU
cd ..

Echo "Publish your package"
cd photo.exif
REM ..\.nuget\NuGet Push photo.exif.*.nupkg
copy *.nupkg C:\Nuget
cd ..


Echo "Create and buils the NuGet Package"
cd photo.exif.unit.test
DEL /F /S /Q /A *.nupkg
..\.nuget\NuGet Pack photo.exif.unit.test.csproj -Prop Platform=AnyCPU
cd ..

Echo "Publish your package"
cd photo.exif.unit.test
REM ..\.nuget\NuGet Push photo.exif.*.nupkg
copy *.nupkg C:\Nuget
cd ..
