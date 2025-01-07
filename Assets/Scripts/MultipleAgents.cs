using UnityEngine;

public class MultipleAgents : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Update()
    {

        if (player != null)
        {

            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }


    }

}
