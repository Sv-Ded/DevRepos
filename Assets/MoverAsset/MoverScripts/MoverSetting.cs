using UnityEngine;

[CreateAssetMenu(fileName = " new MoverSetting", menuName = "Mover Setting", order = 53)]
public class MoverSetting : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }    
    [field: SerializeField] public float JumpForce { get; private set; }    
    [field: SerializeField] public float JumpCooldown { get; private set; }
    [field: SerializeField] public float AirMultiplier { get; private set; }
    [field: SerializeField] public float RunSpeed { get; private set; }    
    [field: SerializeField] public float CrouchSpeed { get; private set; }    
    [field: SerializeField] public float CrouchScaleMultiplier { get; private set; }    
    [field: SerializeField] public float XRotateSpeed { get; private set; }    
    [field: SerializeField] public float YRotateSpeed { get; private set; }    
    [field: SerializeField] public float YOffset { get; private set; }    
    [field: SerializeField] public float Drag { get; private set; }
    [field: SerializeField] public float DragInAir { get; private set; }
    [field: SerializeField] public float MaxSlopeAngle { get; private set; }   
    [field: SerializeField] public LayerMask GroundMask { get; private set; }   
}
