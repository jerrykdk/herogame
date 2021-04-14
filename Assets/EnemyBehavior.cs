using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float power = 1.0f;
    private GameController mGGameController = null;
    // Start is called before the first frame update
    void Start()
    {
        mGGameController = FindObjectOfType<GameController>();
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void UpdateColor()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        const float delta = 0.25f;
        c.r -= delta;
        c.a -= delta;
        s.color = c;
        Debug.Log("Plane: Color = " + c);

        if (c.a <= 0.0f)
        {
            Sprite t = Resources.Load<Sprite>("Textures/Egg");   // File name with respect to "Resources/" folder
            s.sprite = t;
            s.color = Color.white;
        }
    }

    public void PowerDecrease()
    {
        power = power - 0.25f;
        Debug.Log("HITTT");
        UpdateColor();
        if(power == 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Destroyed"); 
            mGGameController.EnemyDestroyed();
            
        }

    }



}
