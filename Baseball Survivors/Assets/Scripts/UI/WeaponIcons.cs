using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcons : MonoBehaviour
{
    public static WeaponIcons instance;

    [Header("Icon Sprites")]
    [SerializeField] private Sprite baseballSprite;
    [SerializeField] private Sprite flyingBatSprite;
    [SerializeField] private Sprite frozenPopSprite;
    [SerializeField] private Sprite areaOfEffectSprite;
    [SerializeField] private Sprite ballLauncherSprite;

    [Header("List of Slots")]
    [SerializeField] private List<GameObject> weaponSlots;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public void AddWeaponIcon(WeaponIcon _weaponIcon)
    {
        for(int i = 0; i < weaponSlots.Count; i++)
        {
            if(weaponSlots[i].GetComponent<Image>().sprite == null)
            {
                switch(_weaponIcon)
                {
                    case WeaponIcon.baseball:
                        weaponSlots[i].GetComponent<Image>().sprite = baseballSprite;
                        break;
                    case WeaponIcon.flyingBat:
                        weaponSlots[i].GetComponent<Image>().sprite = flyingBatSprite;
                        break;
                    case WeaponIcon.frozenPop:
                        weaponSlots[i].GetComponent<Image>().sprite = frozenPopSprite;
                        break;
                    case WeaponIcon.areaOfEffect:
                        weaponSlots[i].GetComponent<Image>().sprite = areaOfEffectSprite;
                        break;
                    case WeaponIcon.ballLauncher:
                        weaponSlots[i].GetComponent<Image>().sprite = ballLauncherSprite;
                        break;
                }

                weaponSlots[i].GetComponent<Image>().color = Color.white;
                return;
            }
        }
    }
}

public enum WeaponIcon
{
    baseball,
    flyingBat,
    frozenPop,
    areaOfEffect,
    ballLauncher
}
