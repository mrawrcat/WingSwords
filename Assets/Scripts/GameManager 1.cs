//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager manager;

//    public float character;
//    public float tileMoveSpeed;
//    public float deathTimer, canbehurtTimer;
//    public float score, highscore, exp, actualExp, level, star;
//    public bool dead, moving, canbehurt;
//    public int movePoint;
//    public List<Quest> listQuestList = new List<Quest>();
//    public int listIndex;
//    public bool QuestComplete;
//    public string dsfds;
    
//    private Scene thisScene;

//    public float roundStar;
    
//    private void Awake()
//    {
//        if (manager == null)
//        {
//            manager = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else if (manager != this)
//        {
//            Destroy(gameObject);
//        }
//        LoadData();
//        dead = true;
//        exp = 0;
//        actualExp = 0;
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        canbehurtTimer -= Time.deltaTime;
//        if(canbehurtTimer <= 0)
//        {
//            canbehurt = true;
//        }
//        else
//        {
//            canbehurt = false;
//        }
//        if(score > highscore)
//        {
//            highscore = score;
//        }
//        if (!dead && thisScene.name == "EndlessRunner")
//        {
//            score += ((1 * Time.deltaTime) * tileMoveSpeed);
            
//        }
//        else if (dead)
//        {
//            //FindObjectOfType<Player>().bodyControl = false;
//            tileMoveSpeed = 0;
//            SaveData();
//            deathTimer -= Time.deltaTime;
           
//        }

//        if (!QuestComplete)
//        {
//            dsfds = listQuestList[listIndex].title;
//        }
//        else if (QuestComplete)
//        {
//            dsfds = listQuestList[listIndex].title + " Complete!";
//        }

//        //exp = Mathf.Lerp(exp, actualExp, 1 * Time.deltaTime);

//        thisScene = SceneManager.GetActiveScene();
//    }

//    public void Replay()
//    {
//        //FindObjectOfType<Player>().bodyControl = true;
//        SceneManager.LoadScene(thisScene.name);
//        score = 0;
//        roundStar = 0;
//        tileMoveSpeed = 15;
//        dead = false;
//        QuestComplete = false;
//        LoadData();
//        Time.timeScale = 1;
//        canbehurt = true;
//        //prevExp = actualExp;

//    }

//    public void SaveData()
//    {
//        SaveSystem.SaveGameData(this);
//        Debug.Log("saved data");
//    }
//    public void LoadData()
//    {
//        GameData data = SaveSystem.loadData();
//        highscore = data.highscore;
//        star = data.star;
//        actualExp = data.actualExp;
        
//        level = data.level;
//    }

//    public void CollectCoins()
//    {
//        if (listQuestList[GameManager.manager.listIndex].isActive)
//        {
//            listQuestList[GameManager.manager.listIndex].questGoal.CoinCollected();
//            //if (listQuestList[GameManager.manager.listIndex].questGoal.isReached())
//            //{
//            //    listQuestList[GameManager.manager.listIndex].Complete();
                
//            //    Debug.Log("Quest complete");
//            //}
//        }
//    }
//    public void reRandomize()
//    {
//        listIndex = Random.Range(0, listQuestList.Count);
//    }
//    public void acceptthequest()
//    {
//        listIndex = Random.Range(0, listQuestList.Count);
//        listQuestList[listIndex].isActive = true;
//        //quest = listQuestList[listIndex];
//    }
    
    
//}
