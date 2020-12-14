﻿using System;

namespace ConsoleEngine.Maths
{
    public readonly struct Rectangle : IEquatable<Rectangle>
    {
        #region Constructors
        public Rectangle(in Vector2Int topLeftAngle, in Vector2Int size)
        {
            TopLeftAngle = topLeftAngle;
            Size = size;
        }
        #endregion

        #region Properties
        public readonly Vector2Int TopLeftAngle { get; init; }
        public readonly Vector2Int TopRightAngle => TopLeftAngle.AddToX(Size.X - 1);
        public readonly Vector2Int BottomLeftAngle => TopLeftAngle.AddToY(Size.Y - 1);
        public readonly Vector2Int BottomRightAngle => TopLeftAngle + Size - 1;
        public readonly Vector2Int Size { get; init; }
        #endregion

        #region Operators
        public static bool operator ==(in Rectangle a, in Rectangle b) => a.Equals(b);
        public static bool operator !=(in Rectangle a, in Rectangle b) => a.Equals(b) == false;
        #endregion

        #region StaticMethods
        public static Rectangle Create(in Vector2Int topLeftAngle, in Vector2Int bottomRightAngle) =>
                                    new Rectangle(topLeftAngle, bottomRightAngle - topLeftAngle + 1);
        #endregion 

        #region Methods
        public readonly bool Contains(in Vector2Int point) => TopLeftAngle <= point && BottomRightAngle >= point;

        public readonly override bool Equals(object obj) => obj is Rectangle rectangle && Equals(rectangle);
        public readonly bool Equals(Rectangle other) => TopLeftAngle.Equals(other.TopLeftAngle) && Size.Equals(other.Size);

        public readonly override int GetHashCode() => HashCode.Combine(TopLeftAngle, Size);

        public readonly override string ToString() => $"TLA:{TopLeftAngle}, Sz:{Size}";
        #endregion
    }
}
