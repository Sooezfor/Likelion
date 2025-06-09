using UnityEngine;

public class StudyRandom : MonoBehaviour
{
    private void OnEnable()
    {
        int ranNumber = Random.Range(0, 100);

        Debug.Log(ranNumber);
    }
}
