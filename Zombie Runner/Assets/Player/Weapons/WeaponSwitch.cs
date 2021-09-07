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

    void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;

        ProcessKeyInput();
        ProcessScrollInput();

        if(previousWeaponIndex != currentWeaponIndex)
        {
            SetWeaponActive();
        }
    }

    void SetWeaponActive()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if(i == currentWeaponIndex)
            {
                weapons[i].SetActive(true);

                Weapon weapon = weapons[i].GetComponent<Weapon>();
            }
            else
            {
                weapons[i].SetActive(false);

                WeaponZoom weaponZoom = weapons[i].GetComponent<WeaponZoom>();
                if(weaponZoom != null)
                {
                    weaponZoom.OnUnscoped();
                }
            }
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
        }
    }

    void ProcessScrollInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeaponIndex >= weapons.Length - 1) //if we are at last weapon and scroll up, we loop back to weapon 1. -1 is because array length doesnt start with 0
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex++;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeaponIndex <= 0) //if we are at last weapon and scroll down, we loop back to weapon max.
            {
                currentWeaponIndex = weapons.Length - 1; //the index of the weapon max ist 1 less than the length because index starts at 0
            }
            else
            {
                currentWeaponIndex--;
            }
        }
    }

}
