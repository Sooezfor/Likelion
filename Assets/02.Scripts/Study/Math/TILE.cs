using UnityEngine;

public class TILE : MonoBehaviour
{
    public GameObject[] turretPrefab;

        private void OnMouseDown()
    {
        Instantiate(turretPrefab[SetTile.turretIndex], transform.position, Quaternion.identity);
    }
}
