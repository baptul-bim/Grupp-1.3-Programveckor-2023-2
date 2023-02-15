using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class findigboss : MonoBehaviour
{
    public Animator animator;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x-5 < player.transform.position.x)
        {
            animator.SetTrigger("vakna");
        }
    }
    void cutscene()
    {
        SceneManager.LoadScene("");
    }

}
