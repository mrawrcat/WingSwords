//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveTowards : MonoBehaviour
//{
//    [SerializeField]
//    private Transform player;
//    // Start is called before the first frame update
//    private Rigidbody2D rb2d;
//    public CamShake camshake;

//    //public float knockTime, thrust;
//    void Start()
//    {
//        player = FindObjectOfType<Player>().transform;
//        rb2d = GetComponent<Rigidbody2D>();
//        camshake = FindObjectOfType<CamShake>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//        transform.position = Vector2.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
//        RotateTowards(player.position);
//        if (GameManager.manager.dead)
//        {
//            gameObject.SetActive(false);
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if(collision.collider.tag == "Shield")
//        {
//            //Destroy(gameObject);
//            Vector2 difference = transform.position - collision.collider.transform.position;
//            difference = difference.normalized * GameManager.manager.thrust;
//            //transform.position = new Vector2((transform.position.x + difference.x) *2, (transform.position.y + difference.y)*2);
//            rb2d.AddForce(difference, ForceMode2D.Impulse);
//            StartCoroutine("KnockCo", rb2d);
//            camshake.shakeDuration = 0.3f;
//        }
//        if (collision.collider.tag == "Sword")
//        {
//            camshake.shakeDuration = 0.01f;
//            //Destroy(gameObject);
//            gameObject.SetActive(false);
//        }
//        if (collision.collider.tag == "Player")
//        {
//            camshake.shakeDuration = 0.01f;
//            if(GameManager.manager.playerHealth > 0)
//            {
//                GameManager.manager.playerHealth--;
//            }

//            //Destroy(gameObject);
//            gameObject.SetActive(false);
//        }
//        if (collision.collider.tag == "Bullet")
//        {
//            camshake.shakeDuration = 0.01f;
//            //Destroy(gameObject);
//            gameObject.SetActive(false);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.tag == "Bullet")
//        {
//            camshake.shakeDuration = 0.01f;
//            //Destroy(gameObject);
//            gameObject.SetActive(false);
//        }
//    }
//    private IEnumerator KnockCo(Rigidbody2D enemy)
//    {
//        yield return new WaitForSeconds(GameManager.manager.knockTime);
//        enemy.velocity = Vector2.zero;
//    }

//    private void RotateTowards(Vector2 target)
//    {
//        var offset = 270f;
//        Vector2 direction = target - (Vector2)transform.position;
//        direction.Normalize();
//        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
//    }
//}
  