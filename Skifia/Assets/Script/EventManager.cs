using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action Create;
    public static event Action CreateFalse;
    public static event Action Delete;
    public static event Action<Color, Color> changeColor;
    public static event Action<Color> changeColorBlack;
    public static void DoCreate()
    {
        Create?.Invoke();
    }
    public static void DoCreateFalse()
    {
        CreateFalse?.Invoke();
    }
    public static void DoDelete()
    {
        Delete?.Invoke();
    }
    public static void DoChangeColor(Color ColorHorizontal, Color ColorDiagonal)
    {
        changeColor?.Invoke(ColorHorizontal, ColorDiagonal);
    }
    public static void DochangeColorBlack(Color ColorBlack)
    {
        changeColorBlack?.Invoke(ColorBlack);
    }
}
