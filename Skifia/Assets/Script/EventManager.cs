using System;
using UnityEngine;

public class EventManager
{
    public static event Action Create;
    public static event Action CreateFalse;
    public static event Action DeleteDembroidery;
    public static event Action<bool> Turn;
    public static event Action<Color, Color> ChangeColorRB;
    public static event Action<Color> ChangeColorBlack; 
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
        DeleteDembroidery?.Invoke();
    }
    public static void DoTurn(bool isTurn)
    {
        Turn?.Invoke(isTurn);
    }
    public static void DoChangeColorRB(Color ColorRed, Color ColorBlack)
    {
        ChangeColorRB?.Invoke(ColorRed, ColorBlack);
    }
    public static void DochangeColorBlack(Color ColorBlack)
    {
        ChangeColorBlack?.Invoke(ColorBlack);
    }
}
