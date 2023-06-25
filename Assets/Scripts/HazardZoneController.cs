using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardZoneController : MonoBehaviour
{
    float lastHurtTime;
    public int damagePerSecond = 20;

    private void OnTriggerStay2D(Collider2D other)
    {
        SecondHealth healthManager = other.GetComponent<SecondHealth>();
        Debug.Log(other);
        if (healthManager != null)
        {
            if(Time.time - lastHurtTime < 1f)return;
            // int damage = Mathf.RoundToInt(damagePerSecond * Time.deltaTime);
            healthManager.HurtPlayer(damagePerSecond);
            lastHurtTime = Time.time;
        }
    }
} 
