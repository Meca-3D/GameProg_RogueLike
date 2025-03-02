using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Character Card")]
public class CharacterInfo : ScriptableObject
{
    public string name;
    public string ability;
    public string weapon;
    public string passive;
}
