﻿using System;
using Spectre.Console;

namespace App.Examples;

public class Example1 : AbstractExample
{
    public override string Description => $"{GetType().Name} is about rendering exceptions (formats, styles)";

    public override void Run()
    {
        try
        {
            ThrowSomeException();
        }
        catch (Exception ex)
        {
            BasicExceptionWriting(ex);
            FormattedExceptionWriting(ex);
            StyledExceptionWriting(ex);
        }
    }

    private static void BasicExceptionWriting(Exception ex)
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[underline green]Basic exception writing :[/]");
        AnsiConsole.WriteException(ex);
    }

    private static void FormattedExceptionWriting(Exception ex)
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[underline green]Formatted exception writing :[/]");
        AnsiConsole.WriteException(ex,
            ExceptionFormats.ShortenPaths | ExceptionFormats.ShortenTypes |
            ExceptionFormats.ShortenMethods | ExceptionFormats.ShowLinks);
    }

    private static void StyledExceptionWriting(Exception ex)
    {
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[underline green]Styled exception writing :[/]");
        AnsiConsole.WriteException(ex, new ExceptionSettings
        {
            Format = ExceptionFormats.ShortenEverything | ExceptionFormats.ShowLinks,
            Style = new ExceptionStyle
            {
                Exception = new Style().Foreground(Color.Grey),
                Message = new Style().Foreground(Color.White),
                NonEmphasized = new Style().Foreground(Color.Cornsilk1),
                Parenthesis = new Style().Foreground(Color.Cornsilk1),
                Method = new Style().Foreground(Color.Red),
                ParameterName = new Style().Foreground(Color.Cornsilk1),
                ParameterType = new Style().Foreground(Color.Red),
                Path = new Style().Foreground(Color.Red),
                LineNumber = new Style().Foreground(Color.Cornsilk1),
            }
        });

        AnsiConsole.WriteLine();
    }

    private static void ThrowSomeException()
    {
        throw new ArgumentException("An error has occured!");
    }
}