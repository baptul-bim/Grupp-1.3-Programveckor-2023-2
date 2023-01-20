using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class bosshealth : MonoBehaviour
{
    public Image health;
    public float currenthealth;
    public float maxhealth = 90f;

    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Image>();
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = currenthealth / maxhealth;

        
        if (currenthealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}