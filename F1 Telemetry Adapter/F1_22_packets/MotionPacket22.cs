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
        public override int Length => 1464;

        public CarMotionData22[] CarMotionData;

        /// <summary>
        /// RL, RR, FL, FR
        /// </summary>
        public float[] SuspensionPosition;
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

        public MotionPacket22(HeaderPacket header, Bytes bys) : base(header, bys) { }

        public MotionPacket22() { }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarMotionData",
                Type = typeof(CarMotionData22),
                Count = 22,
                Children = new PacketField[]
                {
                    new PacketField {Name="WorldPositionX",TypeName = "float"},
                    new PacketField {Name="WorldPositionY",TypeName = "float"},
                    new PacketField {Name="WorldPositionZ",TypeName = "float"},
                    new PacketField {Name="WorldVelocityX",TypeName = "float"},
                    new PacketField {Name="WorldVelocityY",TypeName = "float"},
                    new PacketField {Name="WorldVelocityZ",TypeName = "float"},
                    new PacketField {Name="WorldForwardDirX",TypeName = "int16"},
                    new PacketField {Name="WorldForwardDirY",TypeName = "int16"},
                    new PacketField {Name="WorldForwardDirZ",TypeName = "int16"},
                    new PacketField {Name="WorldRightDirX",TypeName = "int16"},
                    new PacketField {Name="WorldRightDirY",TypeName = "int16"},
                    new PacketField {Name="WorldRightDirZ",TypeName = "int16"},
                    new PacketField {Name="GForceLateral",TypeName = "float"},
                    new PacketField {Name="GForceLongitudinal",TypeName = "float"},
                    new PacketField {Name="GForceVertical",TypeName = "float"},
                    new PacketField {Name="Yaw",TypeName = "float"},
                    new PacketField {Name="Pitch",TypeName = "float"},
                    new PacketField {Name="Roll",TypeName = "float"}
                }
            },
            new PacketField {Name="SuspensionPosition",TypeName = "float",Count=4},
            new PacketField {Name="SuspensionVelocity",TypeName = "float",Count=4},
            new PacketField {Name="SuspensionAcceleration",TypeName = "float",Count=4},
            new PacketField {Name="WheelSpeed",TypeName = "float",Count=4},
            new PacketField {Name="WheelSlip",TypeName = "float",Count=4},
            new PacketField {Name="LocalVelocityX",TypeName = "float"},
            new PacketField {Name="LocalVelocityY",TypeName = "float"},
            new PacketField {Name="LocalVelocityZ",TypeName = "float"},
            new PacketField {Name="AngularVelocityX",TypeName = "float"},
            new PacketField {Name="AngularVelocityY",TypeName = "float"},
            new PacketField {Name="AngularVelocityZ",TypeName = "float"},
            new PacketField {Name="AngularAccelerationX",TypeName = "float"},
            new PacketField {Name="AngularAccelerationY",TypeName = "float"},
            new PacketField {Name="AngularAccelerationZ",TypeName = "float"},
            new PacketField {Name="FrontWheelsAngle",TypeName = "float"}
        };
    }

    public class CarMotionData22
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
