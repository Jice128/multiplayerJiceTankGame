using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{

    //this viriables will be "tranfsformed tothe network"
    public Vector2 MovementInput;
    public float RotationInput;

    public NetworkBool FireButtonPressed;

}
