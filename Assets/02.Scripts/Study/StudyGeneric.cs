using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    private void Start()
    {
        Factory<MonsterClass> factory = new Factory<MonsterClass>();
    }

}
