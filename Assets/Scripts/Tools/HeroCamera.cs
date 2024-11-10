using UnityEngine;

public class HeroCamera : MonoBehaviour
{
    [SerializeField] private Hero player;

    private Vector3 position;

    private void LateUpdate()
    {
        position = player.transform.position;
        position.z = -10;

        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }

}
