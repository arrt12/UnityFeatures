/// <summary>
/// ���� ����Ʈ�� ���� ��带 ǥ���ϴ� Ŭ����.
/// </summary>
public class Node
{
    /// <summary>��忡 ����� ������.</summary>
    public int Data { get; private set; }

    /// <summary>���� ��带 ����Ű�� ����.</summary>
    public Node Next { get; set; }

    /// <summary>
    /// �� ��带 �����մϴ�.
    /// </summary>
    /// <param name="data">��忡 ������ ������ ��.</param>
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}
