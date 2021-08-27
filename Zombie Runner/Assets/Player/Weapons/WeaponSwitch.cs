using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] weapons = null;
    
    int currentWeaponIndex = 0;

    void Start()
    {
        SetWeaponActive();
    }

    void SetWeaponActive()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if(i == currentWeaponIndex)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

}
