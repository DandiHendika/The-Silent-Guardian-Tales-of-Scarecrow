using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntrance : MonoBehaviour
{
    public GameObject boss;
    public GameObject cage;
    public GameObject cameraBoss;
    public GameObject cameraPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            boss.SetActive(true);
            cage.SetActive(true);
            cameraPlayer.SetActive(false);
            cameraBoss.SetActive(true);
        }
    }
}
