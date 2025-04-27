/// <summary>
/// 연결 리스트의 단일 노드를 표현하는 클래스.
/// </summary>
public class Node
{
    /// <summary>노드에 저장된 데이터.</summary>
    public int Data { get; private set; }

    /// <summary>다음 노드를 가리키는 참조.</summary>
    public Node Next { get; set; }

    /// <summary>
    /// 새 노드를 생성합니다.
    /// </summary>
    /// <param name="data">노드에 저장할 데이터 값.</param>
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}
