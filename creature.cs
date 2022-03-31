using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    private Rigidbody2D rb;
    private float thrust = 2;
    private bool goingRight;
    private float t;

    private GameObject mng;

    private void Start(){
        mng = GameObject.FindGameObjectWithTag("Manager");
        rb = GetComponent<Rigidbody2D>();
        t = Random.Range(1f, 0.6f);
        thrust = Random.Range(2f, 3f);
        StartCoroutine(Move());
    }

    private void Update(){
        ColisionDetect();
    }

    private void ColisionDetect(){
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.26f);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.26f);
        if(hitRight.collider != null){
            goingRight = false;
        }
        else if(hitLeft.collider != null){
            goingRight = true;
        }
    }

    IEnumerator Move(){
        while(true){
            if(goingRight){
                rb.AddForce(new Vector2(1,1) * thrust, ForceMode2D.Impulse);
                yield return new WaitForSeconds(t);
            }else if(!goingRight){
                rb.AddForce(new Vector2(1,-1) * -thrust, ForceMode2D.Impulse);
                yield return new WaitForSeconds(t);
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        thrust = 0;
        mng.GetComponent<Manager>().count +=1;
    }

    //Death
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Danger"){
            StartCoroutine(Death());
        }
    }

    void OnBecameInvisible()
    {
        StartCoroutine(Death());
    }

    IEnumerator Death(){
        mng.GetComponent<Manager>().death = true;
        GetComponent<ParticleSystem>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled= false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
