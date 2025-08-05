using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player ;

    private void Awake()
    {
       player = GetComponentInParent<Player>();
    }


    public void DamageEnemies() => DamageEnemies();
    private void DisableMovementAndJump() => player.EnableMovementAndJump(false);

    private void EnableMovementAndJumo()  => player.EnableMovementAndJump(true);


   
 
}
