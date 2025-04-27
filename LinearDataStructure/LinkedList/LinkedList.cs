using System;

/// <summary>
/// 단순 연결 리스트(Linked List) 클래스
/// 노드를 추가, 검색, 출력, 초기화
/// </summary>
public class LinkedList
{
    private Node head;

    /// <summary>
    /// 리스트 끝에 새 데이터를 추가
    /// </summary>
    /// <param name="data">추가할 데이터 값.</param>
    public void Add(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.Next != null)
            current = current.Next;

        current.Next = newNode;
    }

    /// <summary>
    /// 리스트에 있는 모든 데이터를 출력
    /// </summary>
    public void PrintAll()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    /// <summary>
    /// 특정 데이터가 리스트에 존재하는지 확인
    /// </summary>
    /// <param name="data">찾을 데이터 값.</param>
    /// <returns>데이터가 존재하면 true, 없으면 false.</returns>
    public bool Find(int data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == data)
                return true;

            current = current.Next;
        }
        return false;
    }

    /// <summary>
    /// 리스트를 초기화하여 모든 노드를 제거
    /// </summary>
    public void Clear() => head = null;
}
