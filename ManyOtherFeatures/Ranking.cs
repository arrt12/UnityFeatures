using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

#region Class: RankingData
/// <summary>
/// 랭킹 저장을 위한 이름과 시간 목록을 담는 데이터 클래스입니다.
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
/// 랭킹 데이터를 JSON으로 로드/저장하고, UI에 상위 5위까지 표시하는 매니저 클래스
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
    /// persistentDataPath의 Ranking.json을 읽어 랭킹 데이터를 로드
    /// </summary>
    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "Ranking.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<RankingData>(json);
            // 이름/시간 리스트 길이 동기화
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
    /// 현재 playerName/playerTime을 추가하고 상위 5개만 남긴 뒤 JSON으로 저장
    /// </summary>
    public void SaveData()
    {
        data.names.Add(playerName);
        data.times.Add(playerTime.ToString());
        SortData();
        // 최대 항목 수 유지
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
    /// 랭킹 텍스트를 포맷하여 상위 5위까지 출력
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
                rankingText.text += $"{i + 1}위: {data.names[i]}   {min:00}:{sec:00}\n";
            }
            else
            {
                rankingText.text += $"{i + 1}위: 입력된 정보가 없음\n";
            }
        }
    }
    #endregion

    #region Data Sorting
    /// <summary>
    /// 이름과 시간을 (name, time) 튜플로 묶어 시간 순으로 정렬
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
