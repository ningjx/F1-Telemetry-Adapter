﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NingSoft.F1TelemetryAdapter.Tests
{
    [TestClass()]
    public class F1DecoderTests
    {
        //[TestMethod()]
        //public void LoadYamlTest()
        //{
        //    var file = File.ReadAllText(@"D:\F1,22.yaml");
        //    var input = new StringReader(file);
        //    var yaml = new YamlStream();
        //    yaml.Load(input);
        //    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
        //    var header = mapping[new YamlScalarNode("_header")];
        //    var bodys = (YamlMappingNode)mapping[new YamlScalarNode("_bodys")];
        //    //var check = mapping[new YamlScalarNode("_check")];
        //    foreach (var body in bodys)
        //    {
        //        var key = body.Key;
        //        var value = (YamlMappingNode)body.Value;
        //        foreach (var item in value)
        //        {

        //        }
        //    }
        //}

        /// <summary>
        /// SessionPacket
        /// </summary>
        [TestMethod()]
        public void GetSessionPacketTest()
        {
            var bytes = new byte[] { 230, 7, 1, 7, 1, 1, 225, 223, 146, 215, 18, 9, 66, 169, 20, 232, 201, 65, 246, 5, 0, 0, 0, 255, 0, 36, 29, 1, 32, 21, 13, 3, 0, 0, 0, 88, 2, 80, 0, 0, 255, 0, 17, 177, 76, 116, 63, 0, 99, 71, 220, 61, 0, 253, 224, 48, 62, 0, 120, 238, 129, 62, 0, 112, 39, 164, 62, 0, 103, 111, 180, 62, 0, 56, 154, 193, 62, 0, 192, 251, 210, 62, 0, 134, 1, 228, 62, 0, 239, 132, 247, 62, 0, 14, 102, 3, 63, 0, 226, 52, 32, 63, 0, 125, 61, 41, 63, 0, 74, 143, 49, 63, 0, 126, 1, 64, 63, 0, 2, 105, 77, 63, 0, 92, 253, 99, 63, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 2, 212, 2, 0, 0, 0 };
            var pack = F1Adapter.GetF1Packet(bytes);
            Assert.AreNotEqual(pack, null);
        }

        /// <summary>
        /// MotionPacket
        /// </summary>
        [TestMethod()]
        public void GetMotionPacketTest()
        {
            var bytes = new byte[] { 230, 7, 1, 7, 1, 0, 225, 223, 146, 215, 18, 9, 66, 169, 57, 249, 201, 65, 247, 5, 0, 0, 0, 255, 1, 41, 202, 195, 218, 209, 183, 66, 49, 135, 212, 67, 221, 125, 252, 190, 33, 48, 205, 189, 210, 38, 235, 192, 249, 246, 29, 254, 87, 128, 172, 127, 64, 255, 251, 246, 51, 77, 121, 62, 194, 116, 38, 189, 94, 222, 108, 60, 240, 138, 68, 192, 0, 118, 157, 59, 101, 5, 192, 59, 100, 78, 188, 195, 134, 73, 182, 66, 143, 205, 195, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 146, 6, 25, 0, 45, 128, 208, 127, 239, 1, 146, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 198, 69, 64, 0, 69, 120, 188, 43, 238, 119, 188, 48, 235, 190, 195, 27, 35, 182, 66, 34, 84, 180, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 6, 0, 0, 45, 128, 207, 127, 251, 1, 154, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 235, 193, 69, 64, 0, 116, 125, 188, 41, 199, 125, 188, 162, 148, 188, 195, 163, 78, 182, 66, 83, 202, 163, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 193, 5, 232, 255, 35, 128, 217, 127, 13, 2, 193, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 171, 46, 70, 64, 64, 235, 130, 188, 50, 84, 131, 188, 153, 102, 191, 195, 197, 36, 182, 66, 183, 97, 148, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 142, 4, 250, 255, 22, 128, 230, 127, 13, 2, 141, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 200, 70, 64, 128, 38, 131, 188, 181, 74, 131, 188, 192, 245, 188, 195, 160, 76, 182, 66, 217, 227, 131, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 179, 3, 13, 0, 15, 128, 237, 127, 243, 1, 179, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 21, 54, 71, 64, 128, 197, 121, 188, 200, 172, 121, 188, 132, 173, 191, 195, 2, 36, 182, 66, 153, 97, 104, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128, 4, 13, 0, 22, 128, 231, 127, 224, 1, 129, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 43, 207, 70, 64, 0, 127, 112, 188, 175, 105, 112, 188, 136, 44, 189, 195, 175, 74, 182, 66, 96, 7, 72, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 5, 0, 0, 27, 128, 225, 127, 244, 1, 19, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 133, 70, 64, 0, 26, 122, 188, 103, 72, 122, 188, 134, 13, 192, 195, 3, 36, 182, 66, 64, 139, 40, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 60, 5, 195, 255, 29, 128, 223, 127, 238, 1, 59, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 63, 113, 70, 64, 0, 199, 117, 188, 89, 63, 119, 188, 238, 151, 189, 195, 33, 79, 182, 66, 196, 230, 7, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 161, 5, 254, 255, 33, 128, 219, 127, 213, 1, 161, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 228, 62, 70, 64, 128, 152, 106, 188, 9, 223, 106, 188, 191, 127, 192, 195, 221, 35, 182, 66, 54, 150, 209, 193, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 5, 34, 0, 35, 128, 218, 127, 229, 1, 190, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 93, 48, 70, 64, 128, 133, 115, 188, 193, 255, 114, 188, 236, 224, 189, 195, 243, 76, 182, 66, 189, 27, 144, 193, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 252, 3, 6, 0, 17, 128, 235, 127, 2, 2, 252, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 76, 17, 71, 64, 0, 149, 128, 188, 183, 152, 128, 188, 104, 216, 192, 195, 165, 32, 182, 66, 17, 58, 35, 193, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 219, 5, 226, 255, 36, 128, 216, 127, 6, 2, 218, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 33, 70, 64, 192, 35, 129, 188, 239, 158, 129, 188, 194, 59, 190, 195, 24, 79, 182, 66, 114, 212, 250, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 24, 5, 240, 255, 27, 128, 225, 127, 231, 1, 24, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 131, 70, 64, 0, 38, 115, 188, 19, 173, 115, 188, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 252, 236, 10, 66, 98, 2, 2, 66, 248, 99, 12, 66, 110, 55, 21, 66, 186, 202, 49, 193, 113, 210, 170, 65, 119, 50, 61, 193, 127, 221, 70, 65, 147, 192, 15, 196, 86, 187, 110, 68, 36, 133, 3, 196, 128, 218, 18, 68, 44, 64, 236, 64, 94, 82, 235, 64, 144, 77, 236, 64, 254, 78, 235, 64, 255, 43, 39, 58, 77, 80, 202, 185, 102, 12, 106, 58, 90, 102, 214, 185, 114, 119, 217, 188, 96, 24, 13, 60, 94, 179, 235, 64, 5, 27, 50, 187, 14, 155, 102, 188, 39, 246, 170, 188, 141, 123, 13, 190, 37, 2, 183, 63, 187, 219, 11, 63, 64, 202, 12, 58 };
            var pack = F1Adapter.GetF1Packet(bytes);
            Assert.AreNotEqual(pack, null);
        }

        /// <summary>
        /// ParticipantsPacket
        /// </summary>
        [TestMethod()]
        public void GetParticipantsPacketTest()
        {
            var bytes = new byte[] { 230, 7, 1, 7, 1, 4, 225, 223, 146, 215, 18, 9, 66, 169, 57, 249, 201, 65, 247, 5, 0, 0, 0, 255, 1, 0, 255, 0, 0, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 1, 0, 0, 2, 255, 233, 187, 152, 232, 174, 164, 229, 189, 177, 229, 173, 144, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 2, 0, 0, 2, 255, 228, 184, 170, 228, 186, 186, 230, 156, 128, 228, 189, 179, 230, 136, 144, 231, 187, 169, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 0, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 2, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 1, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 8, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 5, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 6, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 4, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 3, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 9, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 7, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 255, 3, 104, 0, 2, 0, 78, 105, 110, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var pack = F1Adapter.GetF1Packet(bytes);
            Assert.AreNotEqual(pack, null);
        }

        /// <summary>
        /// EventPacket
        /// </summary>
        [TestMethod()]
        public void GetEventPacketTest()
        {
            var bytes = new byte[] { 230, 7, 1, 7, 1, 3, 74, 154, 133, 197, 38, 170, 0, 75, 6, 86, 134, 66, 228, 15, 0, 0, 0, 255, 83, 80, 84, 80, 0, 169, 68, 162, 67, 0, 0, 0, 148, 29, 164, 67 };
            var pack = F1Adapter.GetF1Packet(bytes);
            Assert.AreNotEqual(pack, null);
        }

        /// <summary>
        /// CarTelemetryPacket
        /// </summary>
        [TestMethod()]
        public void GetCarTelemetryPacketTest()
        {
            var bytes = new byte[] { 230, 7, 1, 8, 1, 6, 238, 39, 24, 54, 168, 117, 184, 232, 223, 38, 190, 65, 166, 5, 0, 0, 19, 255, 88, 0, 0, 0, 0, 63, 177, 196, 105, 62, 0, 0, 0, 0, 0, 1, 17, 40, 0, 0, 0, 0, 217, 0, 216, 0, 62, 1, 62, 1, 74, 68, 69, 69, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 1, 0, 0, 85, 0, 152, 187, 184, 61, 28, 221, 77, 62, 0, 0, 0, 0, 0, 1, 85, 37, 0, 0, 0, 0, 83, 1, 83, 1, 236, 1, 236, 1, 68, 66, 68, 67, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 227, 0, 208, 242, 199, 61, 225, 143, 156, 188, 0, 0, 0, 0, 0, 6, 248, 41, 0, 0, 0, 0, 15, 1, 13, 1, 252, 0, 251, 0, 81, 88, 80, 82, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 124, 0, 0, 0, 0, 0, 0, 0, 0, 128, 0, 0, 0, 0, 0, 2, 82, 43, 0, 12, 0, 0, 205, 0, 203, 0, 37, 1, 35, 1, 81, 76, 70, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 87, 0, 64, 226, 151, 62, 248, 42, 112, 62, 0, 0, 0, 0, 0, 1, 9, 39, 0, 0, 0, 0, 5, 1, 5, 1, 121, 1, 121, 1, 70, 66, 68, 67, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 84, 0, 0, 0, 0, 0, 99, 232, 160, 61, 0, 0, 0, 0, 0, 1, 22, 37, 0, 0, 0, 0, 123, 1, 123, 1, 33, 2, 33, 2, 67, 67, 68, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 104, 0, 0, 0, 0, 63, 0, 0, 0, 128, 0, 0, 0, 0, 0, 1, 133, 46, 0, 100, 224, 127, 235, 0, 234, 0, 66, 1, 65, 1, 74, 69, 70, 68, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 114, 0, 215, 182, 129, 61, 141, 168, 136, 187, 0, 0, 0, 0, 0, 2, 221, 39, 0, 0, 0, 0, 255, 0, 253, 0, 107, 1, 103, 1, 77, 74, 70, 69, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 106, 0, 62, 47, 161, 62, 91, 206, 215, 60, 0, 0, 0, 0, 0, 2, 113, 37, 0, 0, 0, 0, 214, 0, 213, 0, 40, 1, 39, 1, 72, 69, 69, 68, 69, 69, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 85, 0, 49, 83, 190, 62, 65, 109, 101, 62, 0, 0, 0, 0, 0, 1, 53, 38, 0, 0, 0, 0, 37, 1, 37, 1, 170, 1, 170, 1, 68, 66, 67, 67, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 100, 0, 94, 249, 1, 63, 225, 10, 62, 62, 0, 0, 0, 0, 0, 1, 79, 46, 0, 97, 224, 127, 176, 0, 175, 0, 251, 0, 250, 0, 76, 72, 69, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 84, 0, 80, 169, 133, 62, 169, 34, 194, 189, 0, 0, 0, 0, 0, 1, 155, 37, 0, 0, 0, 0, 177, 1, 177, 1, 105, 2, 105, 2, 69, 68, 69, 69, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 232, 0, 0, 0, 0, 0, 106, 200, 158, 188, 0, 0, 128, 63, 0, 6, 69, 40, 0, 0, 0, 0, 40, 1, 39, 1, 30, 1, 29, 1, 83, 90, 83, 84, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 168, 179, 21, 187, 0, 0, 0, 0, 0, 2, 105, 38, 0, 0, 0, 0, 206, 0, 205, 0, 28, 1, 26, 1, 72, 68, 69, 68, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 229, 0, 0, 0, 0, 0, 13, 182, 107, 188, 10, 215, 35, 60, 0, 6, 103, 40, 0, 0, 0, 0, 233, 0, 231, 0, 208, 0, 206, 0, 82, 88, 82, 83, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 108, 0, 140, 22, 163, 62, 95, 221, 12, 61, 0, 0, 0, 0, 0, 2, 54, 38, 0, 0, 0, 0, 142, 0, 141, 0, 217, 0, 216, 0, 71, 69, 70, 68, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 243, 0, 136, 55, 28, 63, 121, 165, 25, 189, 0, 0, 0, 0, 0, 6, 103, 43, 0, 14, 0, 0, 37, 1, 35, 1, 16, 1, 15, 1, 86, 94, 85, 86, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 85, 0, 60, 83, 129, 60, 137, 240, 244, 60, 0, 0, 0, 0, 0, 1, 80, 37, 0, 0, 0, 0, 202, 1, 202, 1, 147, 2, 147, 2, 70, 69, 71, 71, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 112, 0, 252, 195, 2, 63, 57, 194, 33, 62, 0, 0, 0, 0, 0, 2, 151, 40, 0, 0, 0, 0, 180, 0, 179, 0, 255, 0, 254, 0, 79, 74, 69, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 1, 0, 110, 0, 157, 156, 156, 62, 0, 0, 0, 128, 0, 0, 0, 0, 0, 2, 227, 38, 0, 0, 0, 0, 30, 0, 30, 0, 30, 0, 30, 0, 68, 67, 70, 69, 69, 68, 68, 68, 110, 0, 239, 75, 159, 65, 57, 6, 159, 65, 13, 253, 173, 65, 42, 230, 173, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0 };
            var pack = F1Adapter.GetF1Packet(bytes);
            Assert.AreNotEqual(pack, null);
        }

        /// <summary>
        /// DEBUG
        /// </summary>
        [TestMethod()]
        public void DEBUG_DecoderPacketTest()
        {
            var bytes = new byte[] { 230, 7, 1, 9, 1, 3, 199, 117, 6, 172, 183, 56, 14, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 83, 69, 78, 68, 200, 94, 49, 67, 1, 0, 0, 0, 224, 214, 161, 164 };
            var pack = F1Adapter.GetF1Packet(bytes);
            Assert.AreNotEqual(pack, null);
        }
    }
}