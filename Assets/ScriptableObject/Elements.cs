using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "elements", menuName = "ScriptableObjects/Elements", order = 1)]
public class Elements : ScriptableObject
{
    public int id;
    public string name;
    public List<int> Strong;
    public List<int> weak;
    public float crit;
}
