using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossControl : MonoBehaviour
{
    public Canvas canvas;
    public int HP=50;
    
    void Start()
    {
        Time.timeScale=1;
    }
    void Update()
    {
        if(HP<1){
            return;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"){
            Destroy(collision.gameObject);
            HP=HP-1;
            if(HP<1){
                canvas.gameObject.SetActive(true);
                AudioManager.Instance.PlaySound("Win");
                Destroy(GetComponent<Collider>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(gameObject,1f);
                GetComponent<Animator>().SetBool("isHdie",true);
                Time.timeScale=0;
            }
        }
    }
}
