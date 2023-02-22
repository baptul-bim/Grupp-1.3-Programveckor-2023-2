using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Albin
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
        if (transform.position.x-5 < player.transform.position.x)//om spelaren �r inom visst avst�nd till bossen vaknar den
        {
            animator.SetTrigger("vakna");
        }
    }
    void cutscene()
    {
        SceneManager.LoadScene("bosscutscene", LoadSceneMode.Single);//ladda bosscutscenen
    }

}
