using SkiaSharp;
using System;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Hello, Browser!");

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World XYZ! Greetings from {GetHRef()}";
        Console.WriteLine(text);
        TestCrash();
        return text;
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();

    public static void TestCrash()
    {
        for (int i = 0; i < 10000; i++)
        {
            Console.WriteLine($"TestCrash {i}");
            using (var strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = new SKColor((uint)0),
                StrokeWidth = (float)1,
                IsAntialias = true,
                PathEffect = null,
            })
            {
                //No-op, just trigger dispose
            }
        }
    }
}
