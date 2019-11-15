using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private SpriteRenderer sprite;
    public bool magnetized;
    //private Transform playerTransform;
    private GameHelper gamehelp;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gamehelp = FindObjectOfType<GameHelper>();
        //playerTransform = FindObjectOfType<Player>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(magnetized == true)
        {
            //Vector2 target = playerTransform.position;
            //transform.position = Vector2.MoveTowards(transform.position, target, 20 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            magnetized = false;
            GetComponentInParent<TurnCollectableOn>().timer = 5;
            transform.position = GetComponentInParent<TurnCollectableOn>().transform.position;
            GameManager.manager.score += 1;
            
            gameObject.SetActive(false);

            //if (GameManager.manager.listQuestList[GameManager.manager.listIndex].isActive == true)
            //{
            //    GameManager.manager.listQuestList[GameManager.manager.listIndex].questGoal.CoinCollected();
            //    if (GameManager.manager.listQuestList[GameManager.manager.listIndex].questGoal.isReached())
            //    {
            //        GameManager.manager.actualExp += GameManager.manager.listQuestList[GameManager.manager.listIndex].rewardXP;
            //        GameManager.manager.star += GameManager.manager.listQuestList[GameManager.manager.listIndex].rewardCoins;
            //        GameManager.manager.listQuestList[GameManager.manager.listIndex].Complete();
            //        GameManager.manager.QuestComplete = true;

            //    }
            //}

        }

        if (collision.tag == "MagnetAura")
        {
            Debug.Log("touched magnet");
            magnetized = true;
        }
    }
}
