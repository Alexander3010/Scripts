using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHelth : MonoBehaviour
{
    [SerializeField] private GameObject deathScene;

    [SerializeField] private TMP_Text hpText;
    [SerializeField] [Range (0,100)] private int basePlayerHP;
    private int playerHP;

    public int PlayerHP{
        get{
            return playerHP;
        }
        set{
            playerHP = value;
            hpText.text = playerHP.ToString();

            // changing player stats by changing player hp
            if(playerHP<20){
                changePlayerStats(2, 1);
            }
            else if(playerHP<40){
                changePlayerStats(3, 1);
            }
            else if(playerHP<60){
                changePlayerStats(4, 2);
            }
            else if(playerHP<80){
                changePlayerStats(5, 3);
            }
            else if(playerHP<100){
                changePlayerStats(8, 4);
            }
            else{
                changePlayerStats(10, 10);
            }
        }
    }

    private int playerDamage;
    public int PlayerDamage{
        get{
            return playerDamage;
        }
        set{}
    }

    private int bulletCost;
    public int BulletCost{
        get{
            return bulletCost;
        }
        set{}
    }

    private void Start() {
        PlayerHP = basePlayerHP;
        hpText.text = playerHP.ToString();
    }

    private void Update() {
        if(playerHP <= 0){
            deathScene.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
    }
    
    private void changePlayerStats(int damage, int cost){
        playerDamage = damage;
        bulletCost = cost;
    }
}
