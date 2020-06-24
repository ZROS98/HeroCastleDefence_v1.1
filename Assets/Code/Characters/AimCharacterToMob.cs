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

            }
        }
    }
}
