using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    
    public int playerMaxHealth;
    public int playerCurrentHealth;
    private bool isPlayerDead = false;
    private SpriteRenderer sprite;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        messageText.text = "";
        playerCurrentHealth = playerMaxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth <= 0 && !isPlayerDead)
        {
            isPlayerDead = true;
            weapon.SetActive(false);
            sprite.enabled = false;
            messageText.text = "TACIZE UGRADIN";
            messageText.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterDelay(3.0f));
            
        }

         if(playerCurrentHealth > 0 && messageText.gameObject.activeSelf == true)
        {
            messageText.gameObject.SetActive(false);
        }
    }
    
    IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false);
        isPlayerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HurtPlayer(int  damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        playerCurrentHealth  = playerMaxHealth;
    }
}
