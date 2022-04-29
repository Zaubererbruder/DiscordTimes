using Assets.Game.Core.OnMap;
using Assets.Game.Core.Pathfinding;
using Assets.Game.Models.MapModels;
using Assets.Game.Models.MapModels.Spawners;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid2D
{
    public Grid2DSize Size { get; set; }
    public GridTilemaps Tilemaps { get; set; }
    public Vector3 WorldBottomLeft { get; private set; }

    public Grid2D(Grid2DSize size, GridTilemaps tilemaps)
    {
        Size = size;
        Tilemaps = tilemaps;
        WorldBottomLeft = size.WorldBottomLeft;
    }

    public Vector2Int GridPositionFromWorldPoint(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x + (Size.GridWorldWidth / 2));
        int y = Mathf.FloorToInt(worldPosition.y + (Size.GridWorldHeight / 2));
        return new Vector2Int(x, y);
    }

    public Vector3 WorldPointFromGridPosition(Vector2Int gridPoint)
    {
        return WorldPointFromGridPosition(gridPoint.x, gridPoint.y);
    }

    public Vector3 WorldPointFromGridPosition(int x, int y)
    {
        return WorldBottomLeft + new Vector3(x, y) * Size.NodeDiameter + new Vector3(Size.NodeRadius, Size.NodeRadius);
    }

}
