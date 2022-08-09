using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// The motion packet gives physics data for all the cars being driven. There is additional data for the car being driven with the goal of being able to drive a motion platform setup.
    /// N.B.For the normalised vectors below, to convert to float values divide by 32767.0f – 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
    /// Frequency: Rate as specified in menus
    /// Size: 1464 bytes
    /// Version: 1
    /// </summary>
    public class MotionPacket : F1Packet
    {
        public override int PacketSize => 1464;

        public CarMotionData CarMotionData;

        /// <summary>
        /// RL, RR, FL, FR
        /// </summary>
        public float[] SuspensionVelocity;
        /// <summary>
        /// RL, RR, FL, FR
        /// </summary>
        public float[] SuspensionAcceleration;
        /// <summary>
        /// Speed of each wheel
        /// </summary>
        public float[] WheelSpeed;
        /// <summary>
        /// Slip ratio for each wheel
        /// </summary>
        public float[] WheelSlip;
        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float LocalVelocityX;
        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float LocalVelocityY;
        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float LocalVelocityZ;
        /// <summary>
        /// Angular velocity x-component
        /// </summary>
        public float AngularVelocityX;
        /// <summary>
        /// Angular velocity y-component
        /// </summary>
        public float AngularVelocityY;
        /// <summary>
        /// Angular velocity z-component
        /// </summary>
        public float AngularVelocityZ;
        /// <summary>
        /// Angular velocity x-component
        /// </summary>
        public float AngularAccelerationX;
        /// <summary>
        /// Angular velocity y-component
        /// </summary>
        public float AngularAccelerationY;
        /// <summary>
        /// Angular velocity z-component
        /// </summary>
        public float AngularAccelerationZ;
        /// <summary>
        /// Current front wheels angle in radians
        /// </summary>
        public float FrontWheelsAngle;

        public MotionPacket(HeaderPacket header) : base(header) { }

        public MotionPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarMotionData",
                Type = typeof(CarMotionData),
                Children = new PacketItem[]
                {
                    new PacketItem {Name="WorldPositionX",Type = typeof(float)},
                    new PacketItem {Name="WorldPositionY",Type = typeof(float)},
                    new PacketItem {Name="WorldPositionZ",Type = typeof(float)},
                    new PacketItem {Name="WorldVelocityX",Type = typeof(float)},
                    new PacketItem {Name="WorldVelocityY",Type = typeof(float)},
                    new PacketItem {Name="WorldVelocityZ",Type = typeof(float)},
                    new PacketItem {Name="WorldForwardDirX",Type = typeof(short)},
                    new PacketItem {Name="WorldForwardDirY",Type = typeof(short)},
                    new PacketItem {Name="WorldForwardDirZ",Type = typeof(short)},
                    new PacketItem {Name="WorldRightDirX",Type = typeof(short)},
                    new PacketItem {Name="WorldRightDirY",Type = typeof(short)},
                    new PacketItem {Name="WorldRightDirZ",Type = typeof(short)},
                    new PacketItem {Name="GForceLateral",Type = typeof(float)},
                    new PacketItem {Name="GForceLongitudinal",Type = typeof(float)},
                    new PacketItem {Name="GForceVertical",Type = typeof(float)},
                    new PacketItem {Name="Yaw",Type = typeof(float)},
                    new PacketItem {Name="Pitch",Type = typeof(float)},
                    new PacketItem {Name="Roll",Type = typeof(float)}
                }
            },
            new PacketItem {Name="SuspensionVelocity",Type = typeof(float),Count=4},
            new PacketItem {Name="SuspensionAcceleration",Type = typeof(float),Count=4},
            new PacketItem {Name="WheelSpeed",Type = typeof(float),Count=4},
            new PacketItem {Name="WheelSlip",Type = typeof(float),Count=4},
            new PacketItem {Name="LocalVelocityX",Type = typeof(float)},
            new PacketItem {Name="LocalVelocityY",Type = typeof(float)},
            new PacketItem {Name="LocalVelocityZ",Type = typeof(float)},
            new PacketItem {Name="AngularVelocityX",Type = typeof(float)},
            new PacketItem {Name="AngularVelocityY",Type = typeof(float)},
            new PacketItem {Name="AngularVelocityZ",Type = typeof(float)},
            new PacketItem {Name="AngularAccelerationX",Type = typeof(float)},
            new PacketItem {Name="AngularAccelerationY",Type = typeof(float)},
            new PacketItem {Name="AngularAccelerationZ",Type = typeof(float)},
            new PacketItem {Name="FrontWheelsAngle",Type = typeof(float)}
        };
    }

    public class CarMotionData
    {
        /// <summary>
        /// World space X position
        /// </summary>
        public float WorldPositionX;
        /// <summary>
        /// World space Y position
        /// </summary>
        public float WorldPositionY;
        /// <summary>
        /// World space Z position
        /// </summary>
        public float WorldPositionZ;
        /// <summary>
        /// Velocity in World space X
        /// </summary>
        public float WorldVelocityX;
        /// <summary>
        /// Velocity in World space Y
        /// </summary>
        public float WorldVelocityY;
        /// <summary>
        /// Velocity in World space Z
        /// </summary>
        public float WorldVelocityZ;
        /// <summary>
        /// World space forward X direction (normalised)
        /// </summary>
        public short WorldForwardDirX;
        /// <summary>
        /// World space forward Y direction (normalised)
        /// </summary>
        public short WorldForwardDirY;
        /// <summary>
        /// World space forward Z direction (normalised)
        /// </summary>
        public short WorldForwardDirZ;
        /// <summary>
        /// World space right X direction (normalised)
        /// </summary>
        public short WorldRightDirX;
        /// <summary>
        /// World space right Y direction (normalised)
        /// </summary>
        public short WorldRightDirY;
        /// <summary>
        /// World space right Z direction (normalised)
        /// </summary>
        public short WorldRightDirZ;
        /// <summary>
        /// Lateral G-Force component
        /// </summary>
        public float GForceLateral;
        /// <summary>
        /// Longitudinal G-Force component
        /// </summary>
        public float GForceLongitudinal;
        /// <summary>
        /// Vertical G-Force component
        /// </summary>
        public float GForceVertical;
        /// <summary>
        /// Yaw angle in radians
        /// </summary>
        public float Yaw;
        /// <summary>
        /// Pitch angle in radians
        /// </summary>
        public float Pitch;
        /// <summary>
        /// Roll angle in radians
        /// </summary>
        public float Roll;
    }
}
