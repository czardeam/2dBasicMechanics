using UnityEngine;

public class Enemy : MonoBehaviour
{

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage()
    {
        sr.color = Color.red;

        Invoke("TurnWhite", 3);
    }


    private void TurnWhite()
    {
        sr.color = Color.white;
    }
}
