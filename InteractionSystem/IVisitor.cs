/// <summary>
/// �湮��(Visitor) �������̽�.
/// Ư�� IVisitable ��ü�� �湮�Ͽ� �۾��� ����
/// </summary>
public interface IVisitor
{
    void Visit<T>(T visitable) where T : IVisitable;
}

/// <summary>
/// �湮 ����(Visitable) �������̽�.
/// �湮��(Visitor)�� �� ��ü�� �湮�� �� �ֵ��� Accept �޼��带 ����
/// </summary>
public interface IVisitable
{
    void Accept(IVisitor visitor);
}
