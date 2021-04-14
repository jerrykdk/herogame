using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public int eggCounter = 0;
    private int maxPlanes = 10;
    private int numberOfPlanes = 0;
private int planesDestroyed = 0;
    public Text EnemyCountCurrent = null;
    public Text EnemyCountDestroyed = null;
    public Text mEggCountText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
         if (numberOfPlanes < maxPlanes)
        {
            
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
            Vector3 pos;
        pos.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
            pos.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
            pos.z = 0;
            e.transform.localPosition = pos;
            ++numberOfPlanes;
            EnemyCountCurrent.text = "Current Enemy Count: " + numberOfPlanes;
        }
    }
        public void DecreaseEggCounter() 
        {
          eggCounter--; 
          mEggCountText.text = "Egg Current Total: " + eggCounter;
        } 

        public void AddEggCounter()
        {
        eggCounter++;
        mEggCountText.text = "Egg Current Total: " + eggCounter;
        }
       
        public void EnemyDestroyed() 
        {
          planesDestroyed++;
         --numberOfPlanes;
        EnemyCountDestroyed.text = "Enemy Destroyed: " + planesDestroyed;
        } 

}
