using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetrieveMoveInput();

    public abstract bool RetrieveRangedAttackInput();

    public abstract bool RetrieveJumpInput();
}

