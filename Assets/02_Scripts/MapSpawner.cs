using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Tile을 이용해서 맵을 생성하는 클래스
/// </summary>
public class MapSpawner : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] GameObject[] _tilePrefabs; // 생성할 타일 프리팹들

    [SerializeField] GameObject[] _trailObstacles; // Trail 타일에 생성할 장애물 프리팹들
    [SerializeField] int _minTrailObstacleCount = 3; // Trail 타일에 생성할 장애물의 최소 개수
    [SerializeField] int _maxTrailObstacleCount = 10; // Trail 타일에 생성할 장애물의 최대 개수

    [Header("Settings")]
    [SerializeField] int _initialLines = 20; // 초기 생성할 타일 라인 수
    [SerializeField] int _count; // 한 줄에 생성할 타일의 개수

    Dictionary<TileType, GameObject> _tilePrefabDict = new Dictionary<TileType, GameObject>();

    public void Initialize(Vector3 heroPos)
    {
        // 딕셔너리 초기화
        foreach (var tilePrefab in _tilePrefabs)
        {
            Tile tile = tilePrefab.GetComponent<Tile>();
            if (tile != null && !_tilePrefabDict.ContainsKey(tile.TileType))
            {
                _tilePrefabDict.Add(tile.TileType, tilePrefab);
            }
        }

        // 초기 타일 라인 생성
        // 처음에 영웅 뒤쪽으로 10줄, 앞쪽으로 _initialLines - 10줄 생성
        for (int i = -10; i < _initialLines - 10; i++)
        {
            if (i != 0)
            {
                CreateLine(TileType.Trail, new Vector3(0, 0, heroPos.z + i));
            }
            else
            {
                CreateLine(TileType.Initial, new Vector3(0, 0, heroPos.z + i));
            }
        }
    }

    /// <summary>
    /// 타일 타입과 현재 영웅 위치를 받아 한 줄의 타일을 생성하는 함수
    /// </summary>
    /// <param name="tileType"></param>
    /// <param name="heroPos">영웅의 위치</param>
    public void CreateLine(TileType tileType, Vector3 heroPos)
    {
        Vector3 position = new Vector3(heroPos.x - _count / 2, heroPos.y, heroPos.z); // 타일의 중앙 정렬을 위해 위치 조정

        for (int i = 0; i < _count; i++)
        {
            Vector3 tilePosition = position + new Vector3(i, 0, 0); // 타일을 가로로 배치
            CreateTile(tileType, tilePosition);
        }

        switch (tileType)
        {
            case TileType.Road:
                break;
            case TileType.Railway:
                break;
            case TileType.Trail:
                int randomCount = UnityEngine.Random.Range(_minTrailObstacleCount, _maxTrailObstacleCount + 1);

                List<int> indices = Enumerable.Range(0, _count).ToList();
                indices = indices.OrderBy(x => UnityEngine.Random.value).ToList(); // 랜덤 섞기

                for (int i = 0; i < randomCount; i++)
                {
                    int randomIndex = indices[i];
                    Vector3 obstaclePosition = position + new Vector3(randomIndex, 0, 0);
                    CreateTrailObject(obstaclePosition);
                }
                break;
            case TileType.Water:
                break;
            case TileType.Initial:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 타일의 타입과 위치를 받아 딕셔너리로부터 프리팹을 찾아 해당 타일을 생성하는 함수
    /// </summary>
    /// <param name="tileType"></param>
    /// <param name="position"></param>
    public void CreateTile(TileType tileType, Vector3 position)
    {
        if (_tilePrefabDict.TryGetValue(tileType, out GameObject tilePrefab))
        {
            Instantiate(tilePrefab, position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogWarning($"Tile prefab for type {tileType} not found!");
        }
    }

    /// <summary>
    /// TrailObstacles 배열에서 랜덤으로 하나를 선택해 입력받은 위치에 장애물을 하나 생성하는 함수
    /// </summary>
    /// <param name="position"></param>
    public void CreateTrailObject(Vector3 position)
    {
        if (_trailObstacles.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, _trailObstacles.Length);
            Instantiate(_trailObstacles[randomIndex], position, Quaternion.identity, transform);
        }
    }
}
