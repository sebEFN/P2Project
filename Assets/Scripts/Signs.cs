using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Signs", menuName = "Scriptable Objects/Signs")]
public class Signs : ScriptableObject
{
    public string signName;
    public bool sleep;
    public Sprite signImage;
    public int damage;
    

    
}
