using UnityEngine;

public class AimCharacterToMob : MonoBehaviour
{
    [SerializeField] private int _numberLayerCharacter = 9;
    private const int maxRaycastDistance = 100;

    void Update()
    {
        Ray rayToMob = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(rayToMob, out RaycastHit hit, Mathf.Infinity, _numberLayerCharacter))
        {
            if (hit.transform.CompareTag("Mob"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.gameObject);
                hit.transform.localScale = new Vector3(5, 5, 5);
            }
        }
    }
}
