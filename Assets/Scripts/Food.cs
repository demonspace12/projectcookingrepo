using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "food", menuName = "Scriptable Object/new food", order = 1)]
public class Food : ScriptableObject
{
    public string foodname;

    public Sprite foodicon;

    public string Food_material_1;
    public string Food_material_2;
    public string Food_material_3;
    public string Food_material_4;

    public Image Pic_material_1;
    public Image Pic_material_2;
    public Image Pic_material_3;
    public Image Pic_material_4;

}
