using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpBehavior : MonoBehaviour
{
   private Rigidbody2D rigb; 
   public Text mEnemyCountText = null;


   public Text mControlMode = null;

    public float speed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; //90 degrees in 2 seconds
    public bool mFollowMousePosition = true;
    private int mPlanesTouched = 0;

    public float eggFrequency = 0.2f;
    private float eggTimestamp;

    ///////
   // public float maxSpeed = 10f;
  //  public float acceleration = 0.01f;

    //
//public float speedIncrement = 0.9f;
//public float maximumSpeed = 7f;
    
    
   private GameController mGameGameController = null;

    // Start is called before the first frame update
    void Start()
    {
         mControlMode.text = "Control Mode: mouse";
         rigb = GetComponent<Rigidbody2D>();
         rigb.velocity = transform.up * speed;
         mGameGameController = FindObjectOfType<GameController>();



    }

    // Update is called once per frame
       void Update()
    {


        if(Input.GetKeyDown(KeyCode.M))
        {
            
            if(mFollowMousePosition == false)
            {
                mControlMode.text = "Control Mode: mouse";
            }
            else
            {
                mControlMode.text = "Control Mode: keyboard";
            }
            
            mFollowMousePosition = !mFollowMousePosition;
        }

        Vector3 pos = transform.position;

        if(mFollowMousePosition)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             
            mControlMode.text = "Control Mode: mouse";
           // Debug.Log("Position is " + pos);
            pos.z = 0f;
        }

        else
        {
       
        if (Input.GetKey(KeyCode.W))
        {
            
            speed = speed + 0.9f;
           // if(speed < maxSpeed)
           // {
           //     pos += ((speed + acceleration * Time.smoothDeltaTime) * transform.up);
           // }
          
           //pos += ((speed * Time.smoothDeltaTime) * transform.up);
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed = speed - 0.9f;
            
            //pos -= ((speed * Time.smoothDeltaTime) * transform.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
        }
        
        }
        rigb.velocity = transform.up * speed;
        pos += ((speed * Time.smoothDeltaTime) * transform.up);
        
        
        
        if (Input.GetKey(KeyCode.Space) && Time.time >= eggTimestamp)
        {
            mGameGameController.AddEggCounter();
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
            e.transform.localPosition = transform.localPosition;
            e.transform.rotation = transform.rotation;
            eggTimestamp = Time.time + eggFrequency;
            Debug.Log("Spawn Eggs:" + e.transform.localPosition);
        }

        transform.position = pos;
    
    
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy.tag == "Enemy")
        {
            EnemyBehavior enemyKill = collision.gameObject.GetComponent<EnemyBehavior>();
            Debug.Log("ON COLLISION");
            mPlanesTouched = mPlanesTouched + 1;
            mEnemyCountText.text = "Planes touched = " + mPlanesTouched;
            Destroy(collision.gameObject);
            mGameGameController.EnemyDestroyed();
        }
    }
    

     private void OnTriggerStay2D(Collider2D collision) 
    {
        Debug.Log("Here x Plane: OnTriggerStay2D");
    }

}
