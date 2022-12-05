using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using adventofcode2022.Day1;
using adventofcode2022.Day2;
using adventofcode2022.Day3;
using adventofcode2022.Day4;
using adventofcode2022.Day5;
using adventofcode2022.Helpers;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IReadInputFile, ReadInputFile>()
            // TODO: Update new day here!
            .AddTransient<Day5>())
    .Build();

var serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;


// TODO: Update new day here!
var dayNum = 5;
var currentDay = provider.GetRequiredService<Day5>();
var resultPart1 = currentDay.Part1();

var resultPart2 = currentDay.Part2();

Console.WriteLine($"Day {dayNum} Part 1:");
Console.WriteLine(resultPart1);

Console.WriteLine($"Day {dayNum} Part 2:");
Console.WriteLine(resultPart2);





