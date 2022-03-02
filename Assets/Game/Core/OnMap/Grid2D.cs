using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Models.MapModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid2D
{
    private Vector2 _gridWorldSize;
    private float _nodeRadius;
    private Tilemap _pathfindingMap;
    private Vector3 _worldBottomLeft;
    private float nodeDiameter;
    private int gridSizeX, gridSizeY;

    public void Init(float nodeRadius, Tilemap pathfindingMap, Vector2Int gridWorldSize)
    {
        _gridWorldSize = gridWorldSize;
        _nodeRadius = nodeRadius;
        _pathfindingMap = pathfindingMap;

        nodeDiameter = _nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(_gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(_gridWorldSize.y / nodeDiameter);
    }

    public Vector2Int GridPositionFromWorldPoint(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x + (gridSizeX / 2));
        int y = Mathf.FloorToInt(worldPosition.y + (gridSizeY / 2));
        return new Vector2Int(x, y);
    }

    public Vector3 WorldPointFromGridPosition(Vector2Int gridPoint)
    {
        return _worldBottomLeft + new Vector3(gridPoint.x, gridPoint.y) * nodeDiameter + new Vector3(0.5f,0.5f);
    }

    public MapCell[,] ReadMapCells()
    {
        var cells = new MapCell[gridSizeX, gridSizeY];
        _worldBottomLeft = Vector3.zero - Vector3.right * _gridWorldSize.x / 2 - Vector3.up * _gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = _worldBottomLeft + Vector3.right * (x * nodeDiameter + _nodeRadius) + Vector3.up * (y * nodeDiameter + _nodeRadius);
                Vector2Int gridPoint = new Vector2Int(x, y);
                var tile = _pathfindingMap.GetTile<ExtendedTile>(_pathfindingMap.WorldToCell(worldPoint));
                if (tile != null)
                    cells[x, y] = new MapCell(x, y, tile.Cost);
            }
        }

        return cells;
    }
}
