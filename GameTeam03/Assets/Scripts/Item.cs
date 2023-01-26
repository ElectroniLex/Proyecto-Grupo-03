using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public int ID;
   public string type;
   public string descripcion;
   public Sprite icon;


   [HideInInspector]
   public bool pickedUp;

   [HideInInspector]
   public bool equipped;
   
   [HideInInspector]
   public GameObject weapon;

   [HideInInspector]
   public GameObject weaponManager;

   public bool playersWeapon;



   private void Start()
   {
        weaponManager = GameObject.FindWithTag("WeaponManager");

        if (!playersWeapon)
        {
            int allweapons = weaponManager.transform.childCount;

            for (int i = 0; i < allweapons; i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID==ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }

            }
        }
   }



   private void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                equipped = false;
            }

            if (equipped == false)
            {
                gameObject.SetActive(false);
            }
        }


    }

   public void ItemUsage()
    {
        if (type=="Weapon")
        {
            weapon.SetActive(true);

            weapon.GetComponent<Item>().equipped = true;
        }
    }





}
