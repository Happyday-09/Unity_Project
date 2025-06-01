using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            GameManager.instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
