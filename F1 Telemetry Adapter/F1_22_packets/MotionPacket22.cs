using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
{
    /// <summary>
    /// The motion packet gives physics data for all the cars being driven. There is additional data for the car being driven with the goal of being able to drive a motion platform setup.
    /// N.B.For the normalised vectors below, to convert to float values divide by 32767.0f – 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
    /// Frequency: Rate as specified in menus
    /// Size: 1464 bytes
    /// Version: 1
    /// </summary>
    public class MotionPacket22 : F1Packet
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

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarMotionData",
                Type = typeof(CarMotionData),
                Children = new PacketItem[]
                {
                    new PacketItem {Name="WorldPositionX",TypeName = "float"},
                    new PacketItem {Name="WorldPositionY",TypeName = "float"},
                    new PacketItem {Name="WorldPositionZ",TypeName = "float"},
                    new PacketItem {Name="WorldVelocityX",TypeName = "float"},
                    new PacketItem {Name="WorldVelocityY",TypeName = "float"},
                    new PacketItem {Name="WorldVelocityZ",TypeName = "float"},
                    new PacketItem {Name="WorldForwardDirX",TypeName = "int16"},
                    new PacketItem {Name="WorldForwardDirY",TypeName = "int16"},
                    new PacketItem {Name="WorldForwardDirZ",TypeName = "int16"},
                    new PacketItem {Name="WorldRightDirX",TypeName = "int16"},
                    new PacketItem {Name="WorldRightDirY",TypeName = "int16"},
                    new PacketItem {Name="WorldRightDirZ",TypeName = "int16"},
                    new PacketItem {Name="GForceLateral",TypeName = "float"},
                    new PacketItem {Name="GForceLongitudinal",TypeName = "float"},
                    new PacketItem {Name="GForceVertical",TypeName = "float"},
                    new PacketItem {Name="Yaw",TypeName = "float"},
                    new PacketItem {Name="Pitch",TypeName = "float"},
                    new PacketItem {Name="Roll",TypeName = "float"}
                }
            },
            new PacketItem {Name="SuspensionVelocity",TypeName = "float",Count=4},
            new PacketItem {Name="SuspensionAcceleration",TypeName = "float",Count=4},
            new PacketItem {Name="WheelSpeed",TypeName = "float",Count=4},
            new PacketItem {Name="WheelSlip",TypeName = "float",Count=4},
            new PacketItem {Name="LocalVelocityX",TypeName = "float"},
            new PacketItem {Name="LocalVelocityY",TypeName = "float"},
            new PacketItem {Name="LocalVelocityZ",TypeName = "float"},
            new PacketItem {Name="AngularVelocityX",TypeName = "float"},
            new PacketItem {Name="AngularVelocityY",TypeName = "float"},
            new PacketItem {Name="AngularVelocityZ",TypeName = "float"},
            new PacketItem {Name="AngularAccelerationX",TypeName = "float"},
            new PacketItem {Name="AngularAccelerationY",TypeName = "float"},
            new PacketItem {Name="AngularAccelerationZ",TypeName = "float"},
            new PacketItem {Name="FrontWheelsAngle",TypeName = "float"}
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
