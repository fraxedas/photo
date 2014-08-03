Photo Exif  
===============
Available on nuget: https://www.nuget.org/packages/photo.exif
```Batchfile
    Install-Package photo.exif
```
Description  
===
Extract Exchangeable image file format (Exif) from images


File path sample  
===
```c#
    var data = _parser.Parse(_path);
    data.ToList().ForEach(Console.WriteLine);
```

Stream sample 
===
```c#
    var data = _parser.Parse(new FileStream(_path,FileMode.Open));
    data.ToList().ForEach(Console.WriteLine);
```

Result
===
Both samples will generate the same result:  
```
    256 - ImageWidth = 3264  
    257 - ImageHeight = 2448  
    271 - EquipMake = SAMSUNG  
```
