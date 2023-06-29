using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "PantData", menuName = "ScriptableObjects/PantData", order = 1)]

public class PantData : ScriptableObject
{
    [SerializeField] Material[] materials;

    public Material GetPant(PantType pantType)
    {
        return materials[(int)pantType];
    }
}
