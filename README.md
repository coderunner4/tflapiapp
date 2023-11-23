# TFLApi Client App
This is c# console application to get road information from TFP API

****
## How to configure
Please configure your TPF API key in the application, here are steps to do that: 
1. Find file `\RoadStatus\Const.cs`
2. Change `TFL_API_KEY` with your api_key
``` 
public readonly static string TFL_API_KEY = "your_api_key";
public readonly static string TFL_API_HOST = "https://api.tfl.gov.uk";        
```

## How to build the code
Here is how to build, please ensure to run command from main directory where you find `.sln` file

` dotnet build`

## How to run the output
Here is how to run

` dotnet run --project RoadStatus A40`

If everything is configured, you should see following output:
```
Get Road by Id A40
The status of the A40 is as follows
         Road Status is Good
         Road Status Description is No Exceptional Delays
```

Now, test by provinding an invalid road id such as `A333`

` dotnet run --project RoadStatus A333`

If everything is configured, you should see following output:
```
Get Road by Id A333
Error: A333 is not a valid road
```

## How to run any tests that you have written
Here is how to test

` dotnet test`

If everything is configured, you should see following output:
```
Passed!  - Failed:     0, Passed:     5, Skipped:     0, Total:     5, Duration: 1 s - RoadStatusTest.dll (net7.0)
```

## Assumptions
It is assumed that you dotnet core 7.0 installed and have registered for a developer key from: https://api-portal.tfl.gov.uk/ 

## Main Libraries Used
The code use following external packages,
-  Newtonsoft.Json
-  Microsoft.NET.Test.Sdk (Unit testing with MSTest)

These should already been downloaded by dotnet run commands. However, if you find issues, please download manually 

