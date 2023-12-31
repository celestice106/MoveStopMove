using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] List<WeaponItem> weaponItems;

    public List<WeaponItem> WeaponItems => weaponItems;

    public WeaponItem GetWeaponItem(WeaponType weaponType)
    {
        return WeaponItems.Single(q => q.type == weaponType);
    }
    public WeaponType PrevType(WeaponType weaponType)
    {
        int index = weaponItems.FindIndex(q => q.type == weaponType);
        index = index - 1 < 0 ? weaponItems.Count - 1 : index - 1;
        return weaponItems[index].type;
    }
    public WeaponType NextType(WeaponType weaponType)
    {
        int index = weaponItems.FindIndex(q => q.type == weaponType);
        index = index + 1 >= weaponItems.Count ? 0 : index + 1;
        return weaponItems[index].type;
    }
}

[System.Serializable]
public class WeaponItem
{
    public string name;
    public WeaponType type;
    public int cost;
    public int ads;
}
