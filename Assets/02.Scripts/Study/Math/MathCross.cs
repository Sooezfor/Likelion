using UnityEngine;

public class MathCross : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    private void Start()
    {
        Vector3 result = Vector3.Cross(vecA, vecB);

        Debug.Log($"벡터의 외적 : {result}");

        Vector3 result2 = Vector3.Reflect(vecA, vecB);//괄호 안ㅇㅔ 입사각ㄱㅘ 법서ㄴ 벡ㅌㅓㄱㅏ 들ㅇㅓㄱㅏㅁ
    }
}
