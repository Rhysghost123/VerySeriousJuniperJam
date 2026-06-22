using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] private float moveSpeed = 5f;

    private Transform player;

    //find the player object
    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found");
        }
    }

    //follows the player object
    private void Update()
    {
        if (player == null) return;

        Vector3 targetPos = player.position;
        targetPos.z = transform.position.z;

        float distance = Vector3.Distance(transform.position, targetPos);

        if (distance > 1)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
        }
    }
}