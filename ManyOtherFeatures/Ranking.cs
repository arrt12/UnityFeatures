using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

#region Class: RankingData
/// <summary>
/// ��ŷ ������ ���� �̸��� �ð� ����� ��� ������ Ŭ�����Դϴ�.
/// </summary>
[Serializable]
public class RankingData
{
    public List<string> names = new();
    public List<string> times = new();
}
#endregion

#region Class: Ranking
/// <summary>
/// ��ŷ �����͸� JSON���� �ε�/�����ϰ�, UI�� ���� 5������ ǥ���ϴ� �Ŵ��� Ŭ����
/// </summary>
public class Ranking : MonoBehaviour
{
    #region Singleton
    public static Ranking Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion

    #region Serialized Fields
    [Header("UI Elements")]
    public Text rankingText;

    [Header("Player Info")]
    public string playerName;
    public float playerTime;
    #endregion

    #region Data
    private const int MaxEntries = 5;
    public RankingData data;
    #endregion

    #region Unity Callbacks
    private void Start() => LoadData();
    #endregion

    #region Data Persistence
    /// <summary>
    /// persistentDataPath�� Ranking.json�� �о� ��ŷ �����͸� �ε�
    /// </summary>
    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "Ranking.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<RankingData>(json);
            // �̸�/�ð� ����Ʈ ���� ����ȭ
            int count = Math.Min(data.names.Count, data.times.Count);
            data.names = data.names.Take(count).ToList();
            data.times = data.times.Take(count).ToList();
        }
        else
        {
            data = new RankingData();
        }
        UpdateUI();
    }

    /// <summary>
    /// ���� playerName/playerTime�� �߰��ϰ� ���� 5���� ���� �� JSON���� ����
    /// </summary>
    public void SaveData()
    {
        data.names.Add(playerName);
        data.times.Add(playerTime.ToString());
        SortData();
        // �ִ� �׸� �� ����
        if (data.names.Count > MaxEntries)
        {
            data.names.RemoveAt(MaxEntries);
            data.times.RemoveAt(MaxEntries);
        }
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, "Ranking.json");
        File.WriteAllText(path, json);
        UpdateUI();
    }
    #endregion

    #region UI Update
    /// <summary>
    /// ��ŷ �ؽ�Ʈ�� �����Ͽ� ���� 5������ ���
    /// </summary>
    private void UpdateUI()
    {
        rankingText.text = string.Empty;
        int displayCount = Math.Min(MaxEntries, data.names.Count);

        for (int i = 0; i < MaxEntries; i++)
        {
            if (i < displayCount && float.TryParse(data.times[i], out float secs))
            {
                int min = Mathf.FloorToInt(secs / 60f);
                int sec = Mathf.FloorToInt(secs % 60f);
                rankingText.text += $"{i + 1}��: {data.names[i]}   {min:00}:{sec:00}\n";
            }
            else
            {
                rankingText.text += $"{i + 1}��: �Էµ� ������ ����\n";
            }
        }
    }
    #endregion

    #region Data Sorting
    /// <summary>
    /// �̸��� �ð��� (name, time) Ʃ�÷� ���� �ð� ������ ����
    /// </summary>
    private void SortData()
    {
        var entries = new List<(string name, float time)>();
        for (int i = 0; i < data.names.Count; i++)
        {
            if (float.TryParse(data.times[i], out float t))
                entries.Add((data.names[i], t));
        }
        var top = entries.OrderBy(e => e.time).Take(MaxEntries).ToList();
        data.names = top.Select(e => e.name).ToList();
        data.times = top.Select(e => e.time.ToString()).ToList();
    }
    #endregion
}
#endregion
