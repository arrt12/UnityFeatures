using UnityEngine;

#region Class: PooledObject
/// <summary>
/// ObjectPool 시스템에서 사용되는 풀링 오브젝트
/// Activate() 및 Deactivate()로 활성화/비활성화를 제어
/// </summary>
public class PooledObject : MonoBehaviour
{
    #region Public Methods
    /// <summary>
    /// 오브젝트를 활성화
    /// </summary>
    public void Activate()
        => gameObject.SetActive(true);

    /// <summary>
    /// 오브젝트를 비활성화
    /// </summary>
    public void Deactivate()
        => gameObject.SetActive(false);
    #endregion
}
#endregion
