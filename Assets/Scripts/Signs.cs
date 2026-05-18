using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Signs", menuName = "Scriptable Objects/Signs")]
public class Signs : ScriptableObject
{
    public string signName;
    public bool sleep;
    public RenderTexture signImage;
    public int damage;
    public int healing;
    public int block;

    
}
