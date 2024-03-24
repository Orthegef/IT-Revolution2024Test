using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private Vector3 movement;
    private float deltaX = 0;
    private GameLogic gameLogic;
    private void Start()
    {
        gameLogic = Camera.main.GetComponent<GameLogic>();
        CarStart();
    }
    public void CarStart()
    {
        transform.position = new Vector3(0,0,0);
        deltaX = 0;
    }
    public void CarLeft()
    {
        CarMove(-1);
    }
    public void CarRight()
    {
        CarMove(1);
    }
    private void CarMove(int i)
    {
        deltaX += i*1.4f;
        if (deltaX>3 || deltaX<-3)
        {
            deltaX -= i * 1.4f;
        }
        movement = new Vector3(deltaX, 0, 0);
        transform.position = movement;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameLogic.StopGame();
    }
}
