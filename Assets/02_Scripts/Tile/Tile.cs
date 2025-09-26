using UnityEngine;

public enum TileType
{
    Road,
    Railway,
    Trail,
    Water,
    Initial
}

/// <summary>
/// 맵을 구성하는 타일 한 칸의 기본 클래스
/// </summary>
public abstract class Tile : MonoBehaviour
{
    [SerializeField] TileType _tileType;

    public abstract TileType TileType { get; }

    public abstract void Initialize();
}