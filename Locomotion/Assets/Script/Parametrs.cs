using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Parametrs
{
    private static Parametrs instance;
    public int sizePopulation;
    public int sizeGen;
    public int countCross;
    public int maximumLife;
    public int countMutationEntity;
    public int countMutationGen;
    public int countElite;

    private Parametrs() { }

    public static Parametrs getInstance()
    {
        if (instance == null)
        {
            instance = JsonUtility.FromJson<Parametrs>(File.ReadAllText("Assets/Files/parameters.json"));
        }
        return instance;
    }

}
