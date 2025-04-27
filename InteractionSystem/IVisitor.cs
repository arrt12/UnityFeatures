/// <summary>
/// 방문자(Visitor) 인터페이스.
/// 특정 IVisitable 객체를 방문하여 작업을 수행
/// </summary>
public interface IVisitor
{
    void Visit<T>(T visitable) where T : IVisitable;
}

/// <summary>
/// 방문 가능(Visitable) 인터페이스.
/// 방문자(Visitor)가 이 객체를 방문할 수 있도록 Accept 메서드를 제공
/// </summary>
public interface IVisitable
{
    void Accept(IVisitor visitor);
}
