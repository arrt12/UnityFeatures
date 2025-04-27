using System;

/// <summary>
/// �ܼ� ���� ����Ʈ(Linked List) Ŭ����
/// ��带 �߰�, �˻�, ���, �ʱ�ȭ
/// </summary>
public class LinkedList
{
    private Node head;

    /// <summary>
    /// ����Ʈ ���� �� �����͸� �߰�
    /// </summary>
    /// <param name="data">�߰��� ������ ��.</param>
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
    /// ����Ʈ�� �ִ� ��� �����͸� ���
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
    /// Ư�� �����Ͱ� ����Ʈ�� �����ϴ��� Ȯ��
    /// </summary>
    /// <param name="data">ã�� ������ ��.</param>
    /// <returns>�����Ͱ� �����ϸ� true, ������ false.</returns>
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
    /// ����Ʈ�� �ʱ�ȭ�Ͽ� ��� ��带 ����
    /// </summary>
    public void Clear() => head = null;
}
