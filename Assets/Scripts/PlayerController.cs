using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {

        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, moveY, 0).normalized;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleShooting()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Shoot();
        }

    }

    void Shoot()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fireDirection = (mousePosition - firePoint.position).normalized;
        Quaternion fireRotation = Quaternion.LookRotation(Vector3.forward, fireDirection);

        Instantiate(projectilePrefab, firePoint.position, fireRotation);
    }

}
