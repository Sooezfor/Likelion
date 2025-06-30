using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public enum MoveType {  Horizontal, Vertical }
    public MoveType moveType;
    public float theta;
    public float power = 0.1f;
    public float speed = 1f;

    Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;

        if (moveType == MoveType.Horizontal)
            transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
        else if (moveType == MoveType.Vertical)
            transform.position = new Vector3(initPos.x, initPos.y + power * Mathf.Sin(theta), initPos.z);        
            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
