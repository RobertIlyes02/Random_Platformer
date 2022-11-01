using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string name;
    int strength;
    int agility;

    public Player(string name, int strength, int agility)
    {
        this.name = name;
        this.strength = strength;
        this.agility = agility;
    }

    public void stats()
    {
        Debug.Log(this.name);
        Debug.Log(this.strength);
        Debug.Log(this.agility);
    }

}
