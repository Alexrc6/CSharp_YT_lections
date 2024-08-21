

namespace Devices2
{
    public interface IDeviceSwitch
    {
        bool IsOn { get; set; }
        bool On();
        bool Off();
    }
    public class Device : IDeviceSwitch
    {
        public bool IsOn { get; set; } = false;
        public bool On() => IsOn = true;
        public bool Off() => IsOn = false;
    }
    public class Devices
    {
        public List<IDeviceSwitch> deviceList { get; init; }
        public Devices()
        {
            deviceList =
            [
        new Device(),
        new Device(),
        new Device(),
        new Device(),
        new Device(),
        new Device(),
        new Device(),
        new Device()
        ];
        }

        public void TurnOnOff(Bits bits)
        {
            for (byte i = 0; i < deviceList.Count; i++)
            {
                if (deviceList[i].IsOn && !bits[i])
                    deviceList[i].Off();
                else if (!deviceList[i].IsOn && bits[i])
                    deviceList[i].On();
            }
        }

        public override string ToString()
        {
            return string.Join("", deviceList.Select(s => s.IsOn ? "1" : "0"));
        }


    }
}
