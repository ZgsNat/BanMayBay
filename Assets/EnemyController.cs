using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float hp = 5;
    private bool isActive = false;
    private bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoActive()
    {
        isActive = true;
    }
    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                if (hp == 0)
                {
                    ScoreScript.instance.AddPoint();
                    isDestroyed = true;
                    Destroy(gameObject);
                    return;
                }
                hp--;
            }
        }
    }

}
