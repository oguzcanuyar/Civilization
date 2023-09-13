using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager 
{
    public static int Gold;

    internal static void resetData()
    {
        Gold = 0;
    }
}

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        DataManager.resetData();
    }

    private void Update()
    {
        Debug.Log(DataManager.Gold);
    }
}
