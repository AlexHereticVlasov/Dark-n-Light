using System;
using System.Collections.Generic;
using UnityEngine;

public class PictureHandler : MonoBehaviour
{
    [SerializeField] private Sprite _first;
    [SerializeField] private Sprite _second;
    [SerializeField] private int _scaleFactor = 4;

    private void Start()
    {
        GetDifferences();
    }

    public void GetDifferences()
    {
        if (SizeIsEquel() == false)
        {
            throw new Exception($"Pictures has different size {_first.texture.width} x {_first.texture.height}" +
                $" and {_second.texture.width} x {_second.texture.height}");
        }

        int width = _first.texture.width;
        int height = _first.texture.height;
        bool[,] pixels = GetArray(width, height);

        width /= _scaleFactor;
        height /= _scaleFactor;

        List<Difference> differences = new List<Difference>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (pixels[x, y])
                {
                    Difference difference = new Difference(pixels);
                    differences.Add(difference);
                    difference.Seek(x, y);
                    pixels = difference.GetPixels();
                }
            }
        }

        foreach (var difference in differences)
        {
            difference.Print();
        }
    }

    private bool[,] GetArray(int width, int height)
    {
        bool[,] pixels = new bool[width / _scaleFactor, height / _scaleFactor];

        for (int x = 0; x < width; x += _scaleFactor)
            for (int y = 0; y < height; y += _scaleFactor)
                if (PixelsIsDiffrent(x, y))
                    pixels[x / _scaleFactor, y / _scaleFactor] = true;
        return pixels;
    }

    private bool PixelsIsDiffrent(int x, int y) => _first.texture.GetPixel(x, y) != _second.texture.GetPixel(x, y);

    private bool SizeIsEquel() => _first.texture.width == _second.texture.width && _first.texture.height == _second.texture.height;
}

public class Difference
{
    private Vector2Int[] _directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    private bool[,] _pixels;

    private readonly int _width;
    private readonly int _height;

    private int _xSum;
    private int _ySum;
    private int _counter;

    private int _minX = int.MaxValue;
    private int _maxX;
    private int _minY = int.MaxValue;
    private int _maxY;

    public bool[,] GetPixels() => _pixels;

    public Difference(bool[,] pixels)
    {
        _pixels = pixels;
        _width = pixels.GetLength(0);
        _height = pixels.GetLength(1);
    }

    public void Seek(int x, int y)
    {
        _pixels[x, y] = false;
        _counter++;
        _xSum += x;
        _ySum += y;

        foreach (var direction in _directions)
        {
            int newX = x + direction.x;
            int newY = y + direction.y;

            if (newX >= 0 && newX < _width &&
                newY >= 0 && newY < _height)
            {
                if (_pixels[newX, newY])
                {
                    UpdateValues(newX, newY);
                    Seek(newX, newY);
                }
            }
        }
    }

    private void UpdateValues(int x, int y)
    {
        if (x > _maxX)
            _maxX = x;
        if (y > _maxY)
            _maxY = y;
        if (x < _minX)
            _minX = x;
        if (y < _minY)
            _minY = y;
    }

    public void Print()
    {
        float x = (float)Math.Round(_xSum / (double)_counter / _width, 2);
        float y = (float)Math.Round(_ySum / (double)_counter / _height, 2);

        Debug.Log($"{x}, {y}");
        //Debug.Log($"{_counter}");

        float scaleX = (float)(_maxX - _minX) / _width;
        float scaleY = (float)(_maxY - _minY) / _height;
        Vector2 scale = new Vector2(scaleX, scaleY);
        
        Debug.Log(scale);
    }
}
