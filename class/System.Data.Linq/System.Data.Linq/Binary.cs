using System.IO;

namespace System.Data.Linq
{
    public sealed class Binary : IEquatable<Binary>
    {
        #region .ctor
        public Binary(byte[] bytes, int offset, int length)
        {
        }

        public Binary(byte[] bytes, bool copy)
        {
            if (bytes == null)
                throw ArgumentNullException("bytes");

            if (copy)
            {
                this.bytes = new byte[bytes.Length];
                Array.Copy(bytes, this.bytes, bytes.Length);
            }
            else
            {
                this.bytes = bytes;
            }
        }
        #endregion

        #region Fields
        private byte[] bytes;

        private static Binary emptyBin;
        #endregion

        #region Properties
        public int Length
        {
            get { return bytes.Length; }
        }

        public byte this[int index]
        {
            get { return bytes[index]; }
        }

        public static Binary Empty
        {
            get
            {
                if (emptyBin == null)
                    emptyBin = new Binary(new byte[0], 0, 0);
                return emptyBin;
            }
        }
        #endregion

        #region Operators
        public static bool operator ==(Binary binary1, Binary binary2)
        {
            if (binary1 == null && binary2 == null)
                return true;
            if (binary1 == null && binary2 != null)
                return false;
            return binary1.Equals(binary2);
        }

        public static bool operator !=(Binary binary1, Binary binary2)
        {
            return !(binary1 == binary2);
        }

        public static implicit operator Binary(byte[] bytes)
        {
            return new Binary(bytes);
        }
        #endregion

        #region Public Methods

        public bool Equals(Binary other)
        {
            return Equals(other);
        }

        public override bool Equals(object obj)
        {
            //TODO:
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            //TODO:
            return base.GetHashCode();
        }

        public void CopyTo(int position, byte[] buffer, int offset, int length)
        {
            Array.Copy(this.bytes, position, buffer, offset, length);
        }

        public byte[] ToArray()
        {
            return (byte[])bytes.Clone();
        }

        public Stream ToStream()
        {
            return new MemoryStream(bytes, false);
        }

        public override string ToString()
        {
            //TODO:
            return base.ToString();
        }
        #endregion
    }
}