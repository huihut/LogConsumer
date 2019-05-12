# LogConsumer

A simple thread-safe log module that uses producer-consumer mode.

It can be used in **.NET Framework** and **.Net Core**.

## Use LogConsumer in your project

1. Add [LogConsumer.cs](https://github.com/huihut/LogConsumer/blob/master/LogConsumer/LogConsumer.cs) to your project
2. Modify the `logFileName` in `LogConsumer.cs` to your path and file name
2. Use it where you need to output the log
    ```cs
    HuiHut.LogConsumer.LogConsumer.Instance.Write("your log content");
    ```

## Build & Run this project

* Command
    ```
    dotnet build
    dotnet .\LogConsumer\bin\Debug\netcoreapp2.1\LogConsumer.dll
    ```
* Visual Studio  
    1. Open `LogConsumer.sln` with Visual Studio  
    2. Build & Run

## Log file example

<details><summary>LogConsumer-20190510.txt</summary>

```
Data       Time      Namespace          Class           Method    LogContent
----------------------------------------------------------------------------------
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 0
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 1
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 2
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 3
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 4
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 5
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 6
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 7
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 5 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 8
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 2 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 3 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 6 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 7 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] index = 9
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 0 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 1 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 9 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 8 ] Thread is finished.
2019-05-10 01:50:09  HuiHut.LogConsumer:LogConsumerTest.WriteLog  [ 4 ] Thread is finished.
```

</details>
