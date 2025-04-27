using UnityEngine;

/// <summary>
/// ���α׷� ������ ����ϴ� Ŭ����.
/// LinkedList�� �׽�Ʈ�մϴ�.
/// </summary>
public class Program : MonoBehaviour
{
    private LinkedList list;

    private void Start()
    {
        list = new LinkedList();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Debug.Log("����Ʈ ���:");
        list.PrintAll();

        Debug.Log("\n20 ã��:");
        Debug.Log(list.Find(20) ? "ã��" : "�� ã��");

        Debug.Log("\n�ʱ�ȭ �� ���:");
        list.Clear();
        list.PrintAll();
    }
}