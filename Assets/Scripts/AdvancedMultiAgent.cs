using UnityEngine;

public class AdvancedMultiAgent : MonoBehaviour
{
    public Transform player;

    public float speed = 2f;

    public float retreatDistance = 3f;


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < retreatDistance)
        {


            Vector2 direction = (transform.position - player.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime); 
        }

        else
        {


            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime); 
        }
    }
}
