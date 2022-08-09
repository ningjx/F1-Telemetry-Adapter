namespace F1_Telemetry_Adapter.Models
{
    public class Bytes
    {
        public byte[] ByteData;
        public int Index;

        public Bytes(byte[] byteData, int index = 0)
        {
            ByteData = byteData;
            Index = index;
        }
    }
}
