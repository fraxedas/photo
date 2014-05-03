Echo "Upgrade to the latest version of NuGet.exe"
.nuget\NuGet Update -self

Echo "Store the API Key"
.nuget\NuGet SetApiKey b6fd4d0a-c0c3-4b83-9723-5074b975dc53

Echo "Create and buils the NuGet Package"
cd photo.exif
#..\.nuget\NuGet spec 
..\.nuget\NuGet Pack photo.exif.csproj
cd ..

Echo "Publish your package"
#.nuget\NuGet Push YourPackage.nupkg