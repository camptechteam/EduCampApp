using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalabrasStorage: MonoBehaviour
{
    public string[] palabras = {};

    public int get_diferent_index(int index)
    {
        int newIndex = index;

        while(newIndex == index)
        {
            newIndex = Random.Range(0, palabras.Length);
        }
        
        return newIndex;
    }
}