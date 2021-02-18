using UnityEngine;

public class RollAround : MonoBehaviour
{
    [SerializeField] private float speedRotation;

    void Update()
    {
        transform.Rotate(new Vector3(0f, speedRotation * Time.deltaTime, 0f));
    }
}
