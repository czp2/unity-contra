using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Canvas canvas;
    public Collider2D cd;
    public int Hp=1;
    public double bs=1;
    private Animator ani;
    private Rigidbody2D rbody;
    private int Horizontal;
    private int Vertical;
    private bool isGround=false;

    private float timer=0;
    public Transform enemy;
    public Transform enemy1;
    public GameObject BulletPre;
    public GameObject EnemyPre;
    public Transform right;
    public Transform rdown;
    public Transform r_up;
    public Transform r_down;
    public Transform up;
    public Transform left;
    public Transform ldown;
    public Transform l_up;
    public Transform l_down;
    public Transform down;

    void Start()
    {
        bs=1;
        ani = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Hp<1){return;}
        if(Input.GetKey(KeyCode.D)){
            Horizontal = 1;
        }else if(Input.GetKey(KeyCode.A)){
            Horizontal = -1;
        }else{
            Horizontal = 0;
        }
        if(Input.GetKey(KeyCode.W)){
            Vertical=1;
        }else if(Input.GetKey(KeyCode.S)){
            Vertical=-1;
        }else{
            Vertical=0;
        }

        ani.SetFloat("vertical",Vertical);
        //移动
        if(Horizontal!=0){
            ani.SetBool("isRun",true);
            transform.Translate(Vector2.right*1f*Time.deltaTime*Horizontal);
            GetComponent<SpriteRenderer>().flipX=Horizontal>0?false:true;
        }else{
            ani.SetBool("isRun",false);
        }
        //跳跃
        if(Input.GetKeyDown(KeyCode.K)&&isGround==true&&Vertical<0){
            cd.gameObject.SetActive(false);
            cd.gameObject.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.K)&&isGround==true){
            rbody.AddForce(Vector2.up*180);
        }
            
        //发射子弹
        timer+=Time.deltaTime;
        if(Input.GetKey(KeyCode.J)){
            if(timer>bs*0.2f){
                timer=0;
                Shoot();
            }
        }
        //出现敌人
        if(timer>2.5f){
            timer=0;
            Enemy();
        }
    }
    //出现敌人的函数
    void Enemy(){
        GameObject.Instantiate(EnemyPre,enemy.position,enemy.rotation);
        GameObject.Instantiate(EnemyPre,enemy1.position,enemy1.rotation);
    }
    //发射子弹的函数
    void Shoot(){
        AudioManager.Instance.PlaySound("gun_m");
        Transform trans;
        if(GetComponent<SpriteRenderer>().flipX==false){
            if(Vertical>0&&Horizontal>0){
                trans=r_up;
            }else if(Vertical>0){
                trans=up;
            }else if(Vertical<0&&Horizontal>0){
                trans=r_down;
            }else if(Vertical<0&&isGround==false){
                trans=down;
            }else if(Vertical<0){
                trans=rdown;
            }else{
                trans=right;
            }
        }else{
            if(Vertical>0&&Horizontal<0){
                trans=l_up;
            }else if(Vertical>0){
                trans=up;
            }else if(Vertical<0&&Horizontal<0){
                trans=l_down;
            }else if(Vertical<0&&isGround==false){
                trans=down;
            }else if(Vertical<0){
                trans=ldown;
            }else{
                trans=left;
            }
        }
        GameObject.Instantiate(BulletPre,trans.position,trans.rotation);
    }
    //接触
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag=="Ground"&&GetComponent<Rigidbody2D>().velocity.y<=0){
            isGround=true;
            ani.SetBool("isJump",false);
            AudioManager.Instance.PlaySound("jump");
        }
        if(collision.collider.tag=="enemy"||collision.collider.tag=="DeathLine"){
            Hp=0;
            AudioManager.Instance.PlaySound("GameOver");
            canvas.gameObject.SetActive(true);
            Time.timeScale=0;
        }
        if(collision.collider.tag=="award"){
            bs=0.5;
        }
    }
    //离开地面
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.collider.tag=="Ground"&&GetComponent<Rigidbody2D>().velocity.y>0){
            isGround=false;
            ani.SetBool("isJump",true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Bullet"||collision.tag=="Bullet1"){
            Destroy(collision.gameObject);
            Hp=0;
            AudioManager.Instance.PlaySound("GameOver");
            canvas.gameObject.SetActive(true);
            Time.timeScale=0;
        }
    }
}
