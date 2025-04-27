using System.Collections.Generic;
using UnityEngine;

#region Class: ObjectPool
/// <summary>
/// PooledObject�� �����ϴ� ������Ʈ Ǯ �ý���
/// �ʱ� ũ�⸸ŭ �ν��Ͻ��� �����ϰ�, Get/Release�� Ȱ��ȭ/��Ȱ��ȭ�� ó���մϴ�.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pool Settings")]
    public PooledObject prefab;    // Ǯ�� ����� ������
    public int initialSize = 10;   // �ʱ� ������ ������Ʈ ����
    #endregion

    #region State
    private Stack<PooledObject> pool = new Stack<PooledObject>();  // ���� ������ ������Ʈ ����
    #endregion

    #region Unity Callbacks
    /// <summary>
    /// ���� �� �ʱ� ũ�⸸ŭ PooledObject �ν��Ͻ��� �����Ͽ� ��Ȱ��ȭ �� ���ÿ� ����
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            PooledObject obj = Instantiate(prefab, transform);
            obj.Deactivate();
            pool.Push(obj);
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Ǯ���� ������Ʈ�� ���� Ȱ��ȭ�Ͽ� ��ȯ
    /// ������ ��� ������ �� �ν��Ͻ��� ����
    /// </summary>
    public PooledObject Get()
    {
        PooledObject obj = pool.Count > 0 ? pool.Pop() : Instantiate(prefab, transform);
        obj.Activate();
        return obj;
    }

    /// <summary>
    /// ����� ���� ������Ʈ�� ��Ȱ��ȭ�ϰ� �ٽ� Ǯ�� ��ȯ
    /// </summary>
    public void Release(PooledObject obj)
    {
        obj.Deactivate();
        pool.Push(obj);
    }
    #endregion
}
#endregion
