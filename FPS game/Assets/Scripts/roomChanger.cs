using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomChanger : MonoBehaviour
{
    [SerializeField] private AudioSource teleportationSound;

    [SerializeField] private GameObject activeRoom;
    [SerializeField] private GameObject disactiveRoom;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishPoint;

    private bool teleportation = false;
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("player") && !teleportation){
            teleportation = true;
            
            StartCoroutine(teleportationStart());
        }
    }
    private IEnumerator teleportationStart(){
        teleportationSound.Play();

        yield return new WaitForSeconds(0.3f);

        activeRoom.SetActive(true);

        playerTransform.position = finishPoint.position;

        disactiveRoom.SetActive(false);
    }
}
