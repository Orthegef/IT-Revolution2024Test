using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private Text TextScore, ResultScore;
    [SerializeField] private GameObject ResultWindow,buttonLeft,buttonRight, StartWindow;
    private int[] forest = new int[5];
    private GameObject _tree;
    static public int Score = 0;
    static public bool gameRun = false;
    private void NewLineForest()
    {
        if(gameRun==true)
        {
            for (int i = 0; i < 5; i++)
            {
                if (forest[i] == 0)
                {
                    _tree = Instantiate(tree);
                    _tree.transform.position = new Vector3(1.4f * (-2 + i), 0, 30);
                }
            }
        }
    }
    private IEnumerator RandomForest()
    {
        while(true)
        {
            int sum = 0;
            for(int i=0;i< 5; i++)
            {
                forest[i] = Random.Range(0, 2);
                sum += forest[i];
            }
            if(sum==0)
            {
                forest[Random.Range(0, 5)] = 1;
            }
            NewLineForest();
            TextScore.text = ("Score: " + Score);
            yield return new WaitForSeconds(1.0f);
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Score = 0;
        gameRun = true;
        buttonLeft.SetActive(true);
        buttonRight.SetActive(true);
        StartWindow.SetActive(false);
        ResultWindow.SetActive(false);
        StartCoroutine(RandomForest());
    }
    public void StopGame()
    {
        gameRun = false;
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
        StopAllCoroutines();
        ResultWindow.SetActive(true);
        ResultScore.text = ("Score: " + Score);
    }
}
