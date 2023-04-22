using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    [SerializeField] private GameObject activeMenu;
    [SerializeField] private GameObject disactiveRoom;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player")){
            activeMenu.SetActive(true);
            disactiveRoom.SetActive(false);

            Time.timeScale = 0f;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
