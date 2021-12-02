using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GunController : MonoBehaviour
{
    public GameObject Fail, Success, Pause, bullet, GunPoint, ammo, Bullets, Ammos;

    public int FiredBullet, i, BulletCount = 0;

    Zombie zombie;
    Play play;
    public GameObject can;
    bool isGameover=false, isGamePause=false;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        GenAmmo();

        play = FindObjectOfType<Play>();

        //isGameover = play.isGameover;
        //isGamePause = play.isGamePause;

        zombie = FindObjectOfType<Zombie>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        Vector3 GunPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(MousePos.x - GunPos.x, MousePos.y - GunPos.y);
         angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (isGamePause == false)
                {

                    if (BulletCount < 5)
                    {
                        Fire();
                    }
                    else
                    {
                        if (isGameover == false)
                        {
                            isGameover = true;
                            can.GetComponent<CanvasGroup>().interactable = false;
                            Fail.SetActive(true);
                            //Instantiate(fail);
                        }
                    }

                }
            }
            

        }
    }

    public void Fire()
    {
        Vector3 BulletDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject genBullet = Instantiate(bullet, GunPoint.transform.position, Quaternion.identity);
        genBullet.transform.SetParent(Bullets.transform);
        Vector2 newDir = new Vector2(BulletDir.x,BulletDir.y);
        genBullet.GetComponent<Rigidbody2D>().AddForce(newDir*1000);
        Destroy(genBullet, 5f);
        genBullet.transform.rotation = Quaternion.Euler(0,0,angle);
        GameObject[] AMMOs = GameObject.FindGameObjectsWithTag("ammo");
        Destroy(AMMOs[i]);

        BulletCount += 1;
        PlayerPrefs.SetInt("BulletCount", BulletCount); 
 
    }

    public void GenAmmo()
    {
        float posX = -7.321f;
        for (int i = 0; i < 5; i++)
        {
  
            Vector3 pos = new Vector3(posX , 4.337f, 0f);
            GameObject cartridge = Instantiate(ammo, pos, Quaternion.identity);
            cartridge.transform.SetParent(Ammos.transform);
            //cartridge.transform.position = Ammos.transform.position;
            cartridge.tag = "ammo";
            GameObject[] AMMOs = GameObject.FindGameObjectsWithTag("ammo");
            posX += 0.4f;
        }
    }
}
