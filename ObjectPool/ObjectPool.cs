using System.Collections.Generic;
using UnityEngine;

#region Class: ObjectPool
/// <summary>
/// PooledObject를 관리하는 오브젝트 풀 시스템
/// 초기 크기만큼 인스턴스를 생성하고, Get/Release로 활성화/비활성화를 처리합니다.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pool Settings")]
    public PooledObject prefab;    // 풀에 사용할 프리팹
    public int initialSize = 10;   // 초기 생성할 오브젝트 개수
    #endregion

    #region State
    private Stack<PooledObject> pool = new Stack<PooledObject>();  // 재사용 가능한 오브젝트 스택
    #endregion

    #region Unity Callbacks
    /// <summary>
    /// 시작 시 초기 크기만큼 PooledObject 인스턴스를 생성하여 비활성화 후 스택에 저장
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
    /// 풀에서 오브젝트를 꺼내 활성화하여 반환
    /// 스택이 비어 있으면 새 인스턴스를 생성
    /// </summary>
    public PooledObject Get()
    {
        PooledObject obj = pool.Count > 0 ? pool.Pop() : Instantiate(prefab, transform);
        obj.Activate();
        return obj;
    }

    /// <summary>
    /// 사용이 끝난 오브젝트를 비활성화하고 다시 풀에 반환
    /// </summary>
    public void Release(PooledObject obj)
    {
        obj.Deactivate();
        pool.Push(obj);
    }
    #endregion
}
#endregion
