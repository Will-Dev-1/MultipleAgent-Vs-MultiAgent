using UnityEngine;


public class Multi_Agent : MonoBehaviour
{
    public Transform player;

    public float speed = 2f;

    public float groupRadius = 5f;

    void Update()
    {

        Collider2D[] group = Physics2D.OverlapCircleAll(transform.position, groupRadius);
        if (group.Length > 3)
        {

            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }


    }

}
