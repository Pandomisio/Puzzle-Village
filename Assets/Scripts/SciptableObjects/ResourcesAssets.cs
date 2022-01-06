using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecourcesAssets", menuName = "ScriptableObjects/RecourcesAssets", order = 3)]
class ResourcesAssets : ScriptableObject
{
    public SpriteWithValues[] _resources;

    [Serializable]
    public struct SpriteWithValues
    {
        public AllResources _enumType;
        public Sprite _icon;
        public int _sellValue;
        public int _buyValue;
    }

    // Przenie�c mo�e tutaj wszystko co z nimi zwi�zane poza zarz�dzaniem
    // i mean warto�� sprzeda�y np typy czyli enum z ResourceManagera wyciagn�� itp

    public enum AllResources
    {
        coins,
        glory,
        crystals,
        grass,
        wheat,
        chicken,
        pig,
        carrot,
        tree,
        dirt,
        iron,
        stone,
        coal,
        gold,
        silver,
        diamond
    };

}
