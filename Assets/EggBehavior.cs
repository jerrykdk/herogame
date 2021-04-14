using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    public const float kEggSpeed = 40f;
  //  private const int kLifeTime = 300;
   // private int mLifeCount = 0;

//public Text mEggCountText = null;

    //
    //public float damageToEnemy = 0.25f;


   
 private GameController mGameGameController = null;
    // Start is called before the first frame update
    void Start()
    {
         mGameGameController = FindObjectOfType<GameController>();
      //  mLifeCount = kLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
        

       //mLifeCount--;
       // if(mLifeCount <= 0)
       // {
       //     Destroy(transform.gameObject);
       // }
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            Debug.Log("En Touched here");
            enemy.PowerDecrease();
            Destroy(gameObject);
        }

    }

    void OnBecameInvisible()
    {
        mGameGameController.DecreaseEggCounter();
        Destroy(gameObject);
    }
}
