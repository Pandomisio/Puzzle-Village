using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Building
{
    public string Name;
    public int Level;
    public bool Builded;
    public int CostInWood;
    public int CostInRock;
    public int CostInGold;
    public Building()
    {
        Name = "Default";
    }
    public Building(string name, int level, bool builded, int costInWood, int costInRock, int costInGold)
    {
        this.Name = name;
        this.Level = level;
        this.Builded = builded;
        this.CostInWood = costInWood;
        this.CostInRock = costInRock;
        this.CostInGold = costInGold;
    }
    
}

public class Forge : Building
{
    public Forge()
    {
        this.Name = "Forge";
        this.Level = 1;
        this.Builded = false;
        this.CostInWood = 150;
        this.CostInRock = 20;
        this.CostInGold = 30;
    }
    public void LevelUpBuilding(){
        this.Level++;
        Debug.Log(this.Level);
    }
    public void ShowForge()
    {
        Debug.Log(this.Name);
        Debug.Log(this.Level);
        Debug.Log(this.Builded);
        Debug.Log(this.CostInWood);
        Debug.Log(this.CostInRock);
        Debug.Log(this.CostInGold);
    }
}
