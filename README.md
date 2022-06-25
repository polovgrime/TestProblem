# TestProblem
Test problem for a job interview

The user should be able to enter a dollar and cents amount (no currency symbols or commas are required for the input) which is less than 2 billion dollars. ie. A number between zero and 2 billion with 2 decimal places.

The application will output the English words that express the number as a string of word (dollars and cents). 

To run the application you need to have .NET 6.0 runtime

To build the application, install .NET 6.0 SDK

You can get those here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

To build the application, run this command in the terminal while in project root folder (where CurrencyInput.sln is located) 
```
dotnet build
```

And if build is successful, executable will be located in: 
>\CurrencyInput\bin\Debug\net6.0\

Relative to project directory

Test problem questions: 

> 1. Why did you approach the exercise the way you did?
>
> Maybe, I could simplify the logic. I could definetely use libraries liek Humanizer and solve the problem in ten lines of code. But I chose this way, so I can show that
> I have some experience and knowledge of this platform in a fast way. I tried to keep it as simple as I could with time I had 
>
> 2. If you had more time, what might you do differently?
> 
> If I had more time, I would make it in Windows Forms or some kind of web-service, instead of console application. And sourely I would try to simplify the logic more.
