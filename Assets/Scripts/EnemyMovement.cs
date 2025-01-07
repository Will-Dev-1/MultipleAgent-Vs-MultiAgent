using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;  


    public float moveSpeed = 3f;  

    void Update()
    {

        if (player != null)
        {


            // Move towards player
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

    }


}
