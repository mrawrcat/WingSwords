using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public Text score, highscore;
    public GameObject deadPanel;
    public GameObject startTile, tilesets;

    public GameObject player, lvlGen;
    void Start()
    {
        GameManager.manager.highscore = PlayerPrefs.GetFloat("highscore");
        player.transform.position = lvlGen.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.manager.score + " Points";
        highscore.text = GameManager.manager.highscore + " Points";

        if (GameManager.manager.dead)
        {
            deadPanel.SetActive(true);

        }
        else
        {
            deadPanel.SetActive(false);
        }
    }

    public void resetGame()
    {
        FindObjectOfType<StarsLikeMovement>().transform.position = new Vector3(-3.5f,0,0);
        GameManager.manager.dead = false;
        startTile.transform.position = new Vector2(0, 0);

        foreach(Transform child in tilesets.transform)
        {
            child.gameObject.SetActive(false);
        }

    }
}
