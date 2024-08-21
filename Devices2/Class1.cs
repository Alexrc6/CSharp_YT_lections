namespace Devices2
{
    public interface IGetBitsFromNum
    {
        bool GetBitByIndex(byte index);
        void SetBitByIndex(byte index, bool value);
    }

    public class Bits : IGetBitsFromNum
    {

        public byte Value { get; private set; }

        public Bits(byte value)
        {
            Value = value;
        }

        public bool GetBitByIndex(byte index)
        {
            return (Value & (byte)(1 << index)) != 0;
        }

        public void SetBitByIndex(byte index, bool value)
        {
            if (value)
            {
                Value |= (byte)(1 << index);
            }
            else
            {
                Value &= (byte)~(1 << index);
            }
        }

        public bool this[byte index]
        {
            get => GetBitByIndex(index);
            set => SetBitByIndex(index, value);
        }

        public static implicit operator Bits(int value) => new Bits((byte)value); // Реализуйте операторы неявного приведения из int в Bits.

        public static implicit operator Bits(long value) => new Bits((byte)value); // Реализуйте операторы неявного приведения из long в Bits.

        public static implicit operator byte(Bits bits) => bits.Value;
        public static explicit operator Bits(byte value) => new(value);




    }


}
