using UnityEngine;

/// <summary>
/// 프로그램 시작을 담당하는 클래스.
/// LinkedList를 테스트합니다.
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

        Debug.Log("리스트 출력:");
        list.PrintAll();

        Debug.Log("\n20 찾기:");
        Debug.Log(list.Find(20) ? "찾음" : "못 찾음");

        Debug.Log("\n초기화 후 출력:");
        list.Clear();
        list.PrintAll();
    }
}