using UnityEngine;
using System.Collections;

public class GrapeBullet : MonoBehaviour
{
    private float attackDamage;
    private GameObject player;
    public float hitBoxSize;
    private Transform playerTransform;


    public void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject playerObj = other.gameObject;
            PlayerController pc = playerObj.GetComponent<PlayerController>();
            if (pc == null) return;

            pc.SetCurrentHealth(pc.GetCurrentHealth() - attackDamage);
            Destroy(gameObject);
            Debug.Log($"Bullet attacked player for {attackDamage} damage.");
        }
    }
    
    public void SetAttackDamage(float damage)
    {
        attackDamage = damage;
    }

    public float getAttackDamage()
    {
        return attackDamage;
    }

    void Update()
    {
        Vector2 playerPosition = playerTransform.position;
        Vector2 objectPosition = transform.position;

       
        
        float distance = Vector2.Distance(playerPosition, objectPosition);

       
        
        if (distance < hitBoxSize)
        {
            //damage player
            damagePlayer();
        }

    }


    void Awake()
    {
        StartCoroutine(DestroyAfterTime(5f));  
        player = GameObject.FindGameObjectWithTag("Player");

         if (player != null)
        {
              playerTransform = player.GetComponent<Transform>();
        }
            
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void damagePlayer()
    {
        PlayerController pc = player.GetComponent<PlayerController>();
            if (pc == null) return;
        pc.SetCurrentHealth(pc.GetCurrentHealth() - attackDamage);
        Destroy(gameObject);
    }
   
}
