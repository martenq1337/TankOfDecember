using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIconManager : MonoBehaviour
{
    public int SelectedWeaponID;

    private int _PreviousSelectedID;
    private WeaponImageContainer _WeaponImageContainer;

    private void Awake()
    {
        _WeaponImageContainer = gameObject.GetComponent<WeaponImageContainer>();
        _PreviousSelectedID = SelectedWeaponID;

        SetDefaultIcons();
    }

    public void ChangeIcon(int weaponID)
    {
        //if change weapon to other
        if(weaponID != SelectedWeaponID)
        {
            _PreviousSelectedID = SelectedWeaponID; //set previous id to actual
            SelectedWeaponID = weaponID; //update selected with ne

            ChangeSelectedIcon();
        }
    }

    private void ChangeSelectedIcon()
    {
        if (_PreviousSelectedID == 0)
        {
            _WeaponImageContainer.SelectedPush.gameObject.SetActive(false);
            _WeaponImageContainer.NotSelectedPush.gameObject.SetActive(true);
        }
        else if (_PreviousSelectedID == 1)
        {
            _WeaponImageContainer.SelectedPull.gameObject.SetActive(false);
            _WeaponImageContainer.NotSelectedPull.gameObject.SetActive(true);
        }
        else if (_PreviousSelectedID == 2)
        {
            _WeaponImageContainer.SelectedConfusion.gameObject.SetActive(false);
            _WeaponImageContainer.NotSelectedConfusion.gameObject.SetActive(true);
        }

        if(SelectedWeaponID == 0)
            _WeaponImageContainer.SelectedPush.gameObject.SetActive(true);
        else if (SelectedWeaponID == 1)
            _WeaponImageContainer.SelectedPull.gameObject.SetActive(true);
        else if(SelectedWeaponID == 2)
            _WeaponImageContainer.SelectedConfusion.gameObject.SetActive(true);

    }

    private void SetDefaultIcons()
    {
        _WeaponImageContainer.SelectedPush.gameObject.SetActive(true);
        _WeaponImageContainer.NotSelectedPull.gameObject.SetActive(true);
        _WeaponImageContainer.NotSelectedConfusion.gameObject.SetActive(true);
    }
}
