using UnityEngine;

[CreateAssetMenu]
public class Avatar : ScriptableObject
{
    public int avatarID;
    public string avatarName;
    public string AvatarQuote;
    public Sprite avatarIllustration;
    public Sprite paddleIllustration;
    public Sprite ballIllustration;

    public PhysicsMaterial2D ballMaterial;
    [Tooltip("0-1 value of movement Speed")]
    public float movementSpeed;
    [Tooltip("the damage it inflicts to blocks")]
    public int damageModifier;


    //TODO I encapsulate stuff with private setters


}

