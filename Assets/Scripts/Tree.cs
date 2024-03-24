using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private float speed = 10.0f;
    void Update()
    {
        if(GameLogic.gameRun==true)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
            if (transform.position.z < -1)
            {
                GameLogic.Score += 1;
                Destroy(this.GameObject());
            }
        }
        else
        {
            Destroy(this.GameObject());
        }
    }
}
