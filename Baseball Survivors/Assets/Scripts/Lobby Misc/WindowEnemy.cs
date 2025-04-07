using UnityEngine;

public class WindowEnemy : MonoBehaviour
{
    private WindowSpawner windowSpawner;

    private void Awake()
    {
        windowSpawner = GetComponentInParent<WindowSpawner>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, windowSpawner.endPoint.transform.position, 1f * Time.deltaTime);

        if(transform.position.x <= windowSpawner.endPoint.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
