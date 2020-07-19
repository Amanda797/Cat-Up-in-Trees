using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if(instance != null &&  instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public List<GameObject> enemiesInScene;

    public bool isAlive;
    public GameObject Player;

    private void Start()
    {
        isAlive = true;
        Player.GetComponent<Pawn>().lastCheckpoint = Player.transform;
    }
    private void Update()
    {
        CheckWin();
        CheckLose();

    }
    //Win: Kill hedgehog

    void CheckWin()
    {
        if(enemiesInScene.Count == 0)
        {
            SceneManager.LoadScene("Victory");
        }

    }

    void CheckLose()

    {
        if(isAlive == false)
        {
            SceneManager.LoadScene("Fail Screen");
        }
    }

   public void respawn()
    {
        
        Player.transform.position = Player.GetComponent<Pawn>().lastCheckpoint.position;
    }
}
