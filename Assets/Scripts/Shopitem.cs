using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "shopmenu",menuName ="Scriptable Object/new Shop item",order =1)]
public class Shopitem : ScriptableObject
{
    public string title;
    public int cost;
    public Sprite icon;
}
