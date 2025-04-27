using System.Collections;
using UnityEngine;

#region Class: AreaCircleSpawner
/// <summary>
/// ������ ������ �� �� ���·� �ֱ������� ������Ʈ�� �����ϴ� Ŭ����
/// </summary>
public class AreaCircleSpawner : MonoBehaviour
{
    #region Serialized Fields
    [Header("Spawn Settings")]
    [Tooltip("������ ������")]
    public GameObject spawnPrefab;

    [Tooltip("���� �ֱ�(��)")]
    public float spawnTime = 5f;

    [Tooltip("���� ������")]
    public float radius = 5f;

    [Tooltip("���� �߽� ��ġ(X,Z)")]
    public Vector2 circleCenter = Vector2.zero;
    #endregion

    #region State
    private float timer = 0f;  // ���� Ÿ�̸�
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
        // �����Ϳ��� ���� ���� ���� �ð�ȭ
        Gizmos.color = Color.red;
        Vector3 center3D = new Vector3(circleCenter.x, 0f, circleCenter.y);
        Gizmos.DrawWireSphere(center3D, Mathf.Max(radius, 0f));
    }
    #endregion

    #region Helper Methods
    /// <summary>
    /// ���� �ѷ� �� ���� ��ġ�� ����Ͽ� �������� �ν��Ͻ�
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
