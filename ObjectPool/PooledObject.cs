using UnityEngine;

#region Class: PooledObject
/// <summary>
/// ObjectPool �ý��ۿ��� ���Ǵ� Ǯ�� ������Ʈ
/// Activate() �� Deactivate()�� Ȱ��ȭ/��Ȱ��ȭ�� ����
/// </summary>
public class PooledObject : MonoBehaviour
{
    #region Public Methods
    /// <summary>
    /// ������Ʈ�� Ȱ��ȭ
    /// </summary>
    public void Activate()
        => gameObject.SetActive(true);

    /// <summary>
    /// ������Ʈ�� ��Ȱ��ȭ
    /// </summary>
    public void Deactivate()
        => gameObject.SetActive(false);
    #endregion
}
#endregion
