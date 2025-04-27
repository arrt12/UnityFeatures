using System.Collections;
using UnityEngine;

#region Class: AreaCircleSpawner
/// <summary>
/// 지정된 반지름 내 원 형태로 주기적으로 오브젝트를 스폰하는 클래스
/// </summary>
public class AreaCircleSpawner : MonoBehaviour
{
    #region Serialized Fields
    [Header("Spawn Settings")]
    [Tooltip("스폰할 프리팹")]
    public GameObject spawnPrefab;

    [Tooltip("스폰 주기(초)")]
    public float spawnTime = 5f;

    [Tooltip("원의 반지름")]
    public float radius = 5f;

    [Tooltip("원의 중심 위치(X,Z)")]
    public Vector2 circleCenter = Vector2.zero;
    #endregion

    #region State
    private float timer = 0f;  // 스폰 타이머
    #endregion

    #region Unity Callbacks
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Spawn();
            timer = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        // 에디터에서 원형 스폰 영역 시각화
        Gizmos.color = Color.red;
        Vector3 center3D = new Vector3(circleCenter.x, 0f, circleCenter.y);
        Gizmos.DrawWireSphere(center3D, Mathf.Max(radius, 0f));
    }
    #endregion

    #region Helper Methods
    /// <summary>
    /// 원의 둘레 상 임의 위치를 계산하여 프리팹을 인스턴스
    /// </summary>
    private void Spawn()
    {
        float angleRad = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float x = circleCenter.x + radius * Mathf.Cos(angleRad);
        float z = circleCenter.y + radius * Mathf.Sin(angleRad);

        Vector3 spawnPos = new Vector3(x, 0f, z);
        Instantiate(spawnPrefab, spawnPos, Quaternion.identity);
    }
    #endregion
}
#endregion
