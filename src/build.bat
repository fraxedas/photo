Echo "Upgrade to the latest version of NuGet.exe"
.nuget\NuGet Update -self

Echo "Create and buils the NuGet Package"
cd photo.exif
..\.nuget\NuGet Pack photo.exif.csproj -Prop Platform=AnyCPU
..\.nuget\NuGet Pack photo.exif.csproj -Symbols -Prop Platform=AnyCPU
cd ..

Echo "Publish your package"
cd photo.exif
..\.nuget\NuGet Push photo.exif.*.nupkg
cd ..
