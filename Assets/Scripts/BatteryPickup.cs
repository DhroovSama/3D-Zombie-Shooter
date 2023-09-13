using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    public AudioSource batteryPickup;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            if (!batteryPickup.isPlaying)
            {
                batteryPickup.Play();
            }

            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle); 
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(addIntensity);  
            Destroy(gameObject);           
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
