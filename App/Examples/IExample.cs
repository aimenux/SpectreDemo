﻿namespace App.Examples;

public interface IExample
{
    string Description { get; }
    string Style { get; }
    void Run();
}