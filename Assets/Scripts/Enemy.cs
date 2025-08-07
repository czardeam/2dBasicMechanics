using UnityEngine;

public class Enemy : MonoBehaviour
{

    private SpriteRenderer sr;
    [SerializeField] float redColorDuration = 3f;
    public float currentTimeInGame;
    public float lastTimeWasDamaged;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        ChangeColorWhenNeeded();
        
    }


    public void TakeDamage()
    {
        sr.color = Color.red;
        
        lastTimeWasDamaged = Time.time;
       

    }


    private void ChangeColorWhenNeeded()
    {
         currentTimeInGame = Time.time;

        if (currentTimeInGame > lastTimeWasDamaged + redColorDuration)
        {
            if (sr.color != Color.white)
             sr.color = Color.white;
        }
    }
}
