﻿using System;
using System.Diagnostics;
using System.Globalization;

namespace Comet
{
    [DebuggerDisplay("X={X}, Y={Y}")]
    public struct PointF
    {
        public float X { get; set; }

        public float Y { get; set; }

        public static PointF Zero = new PointF();

        public override string ToString()
        {
            return $"{{X={X.ToString(CultureInfo.InvariantCulture)} Y={Y.ToString(CultureInfo.InvariantCulture)}}}";
        }

        public PointF(float x, float y) : this()
        {
            X = x;
            Y = y;
        }

        public PointF(SizeF sz) : this()
        {
            X = sz.Width;
            Y = sz.Height;
        }

        public override bool Equals(object o)
        {
            if (!(o is PointF))
                return false;

            return this == (PointF)o;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y.GetHashCode() * 397);
        }

        public PointF Offset(float dx, float dy)
        {
            PointF p = this;
            p.X += dx;
            p.Y += dy;
            return p;
        }

        public PointF Round()
        {
            return new PointF((float)Math.Round(X), (float)Math.Round(Y));
        }

        public bool IsEmpty => X == 0 && Y == 0;

        public static explicit operator SizeF(PointF pt)
        {
            return new SizeF(pt.X, pt.Y);
        }

        public static PointF operator +(PointF pt, SizeF sz)
        {
            return new PointF(pt.X + sz.Width, pt.Y + sz.Height);
        }

        public static PointF operator -(PointF pt, SizeF sz)
        {
            return new PointF(pt.X - sz.Width, pt.Y - sz.Height);
        }

        public static bool operator ==(PointF ptA, PointF ptB)
        {
            return ptA.X == ptB.X && ptA.Y == ptB.Y;
        }

        public static bool operator !=(PointF ptA, PointF ptB)
        {
            return ptA.X != ptB.X || ptA.Y != ptB.Y;
        }

        public float Distance(PointF other)
        {
            return (float)Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        public void Deconstruct(out float x, out float y)
        {
            x = X;
            y = Y;
        }
    }
}
