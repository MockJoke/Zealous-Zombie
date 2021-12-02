using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    public GameObject can, Success, Fail, Pause, star, ScoreBoard;
    public int score, MaxLevel, LevelNo, ZombieCount, StarCount, BulletCount;
    bool isGameover, isGamePause;
    Zombie zombie;
    public Text ScoreCard; 

    // Start is called before the first frame update
    void Start()
    {
        zombie = FindObjectOfType<Zombie>();
        score = zombie.score;

        score = PlayerPrefs.GetInt("score");

        LevelNo = PlayerPrefs.GetInt("LevelNo", 1);
        MaxLevel = PlayerPrefs.GetInt("MaxLevel", 0);

        BulletCount = PlayerPrefs.GetInt("BulletCount");

    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Zombie").Length == 0 && isGameover ==false)
        {
            isGameover = true;
            Success.SetActive(true); 
            //Instantiate(Success);

            Time.timeScale = 0; 

            can.GetComponent<CanvasGroup>().interactable = false;

        }

        //ScoreCard.text = "SCORE:" + score; 

        if(isGameover==true && BulletCount == 1)
        {
            StarCount = 3;
        }
        else if (isGameover == true && 2 <= BulletCount && BulletCount <= 3)
        {
            StarCount = 2; 
        }
        else
        {
            StarCount = 1; 
        }

    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitBtn()
    {
        SceneManager.LoadScene("Levels");
    }

    public void RetryBtn()
    {
        //Destroy(Success);
        Success.SetActive(false);
        //Destroy(Fail);
        Fail.SetActive(false);
        //Destroy(Pause);
        Pause.SetActive(false);

        //can.GetComponent<CanvasGroup>().interactable = true;
        SceneManager.LoadScene("Play" + LevelNo);
    }

    public void ResumeBtn()
    {
        Pause.SetActive(false);
        SceneManager.LoadScene("Play" + LevelNo);
    }

    public void NextBtn()
    {
        Success.SetActive(false);

        LevelNo++;
        PlayerPrefs.SetInt("LevelNo", LevelNo); 

        SceneManager.LoadScene("Play" + LevelNo);
    }

    public void PauseBtn()
    {
        if (isGamePause == false)
        {
            isGamePause = true;
            Pause.SetActive(true);
            //Instantiate(Pause);
        } 
    }

    public void GenStar()
    {
        float posX = 0.53f;
        for (int i = 0; i < StarCount; i++)
        {

            Vector3 pos = new Vector3(posX, 1.33f, -2.233913f);
            GameObject cartridge = Instantiate(star, pos, Quaternion.identity);
            cartridge.transform.SetParent(ScoreBoard.transform);
            //cartridge.transform.position = Ammos.transform.position;
            cartridge.tag = "star";
            GameObject[] STARs = GameObject.FindGameObjectsWithTag("star");
            posX += 0.4f;
        }
    }

}
