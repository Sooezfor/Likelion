using UnityEngine;

public interface IDropItem
{
    void Grab(Transform grabpos); // ������ �ݱ�
    void Use(); // ������ ����ϱ�
    void Drop(); // ������ ������
}
