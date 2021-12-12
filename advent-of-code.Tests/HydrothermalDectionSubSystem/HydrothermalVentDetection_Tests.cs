using advent_of_code.HydrothermalDectionSubSystem;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace advent_of_code.Tests.HydrothermalDectionSubSystem
{
    public class HydrothermalVentDetection_Tests
    {

        ILogger log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();


        [Fact]
        public void Drawline_up_test()
        {
            string[] demoData1 = { };
            var hvd = new HydrothermalVentDetection(log);

            Line l = new Line(1, 9, 5, 9);
            hvd.DrawALine(l);

            Assert.Equal(0, hvd.OceanFloorMap[0, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[1, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[3, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[4, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[5, 9]);
            Assert.Equal(0, hvd.OceanFloorMap[6, 9]);

        }

        [Fact]
        public void Drawline_down_test()
        {
            string[] demoData1 = { };
            var hvd = new HydrothermalVentDetection(log);

            Line l = new Line(5, 9, 1, 9);
            hvd.DrawALine(l);

            Assert.Equal(0, hvd.OceanFloorMap[0, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[1, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[3, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[4, 9]);
            Assert.Equal(1, hvd.OceanFloorMap[5, 9]);
            Assert.Equal(0, hvd.OceanFloorMap[6, 9]);
        }

        [Fact]
        public void Drawline_left_test()
        {
            string[] demoData1 = { };
            var hvd = new HydrothermalVentDetection(log);

            Line l = new Line(2, 5, 2, 2);
            hvd.DrawALine(l);

            Assert.Equal(0, hvd.OceanFloorMap[2, 1]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 2]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 3]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 4]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 5]);
            Assert.Equal(0, hvd.OceanFloorMap[2, 6]);

        }

        [Fact]
        public void Drawline_right_test()
        {
            string[] demoData1 = { };
            var hvd = new HydrothermalVentDetection(log);

            Line l = new Line(2, 2, 2, 5);
            hvd.DrawALine(l);

            Assert.Equal(0, hvd.OceanFloorMap[2, 1]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 2]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 3]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 4]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 5]);
            Assert.Equal(0, hvd.OceanFloorMap[2, 6]);
        }


        [Fact]
        public void Drawline_crossing_test()
        {
            string[] demoData1 = { };
            var hvd = new HydrothermalVentDetection(log);

            Line l = new Line(2, 2, 2, 5);
            hvd.DrawALine(l);
            hvd.DrawALine(new Line(2, 3, 2, 4));
            hvd.DrawALine(new Line(1, 3, 3, 3));

            Assert.Equal(0, hvd.OceanFloorMap[2, 1]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 2]);
            Assert.Equal(3, hvd.OceanFloorMap[2, 3]);
            Assert.Equal(2, hvd.OceanFloorMap[2, 4]);
            Assert.Equal(1, hvd.OceanFloorMap[2, 5]);
            Assert.Equal(0, hvd.OceanFloorMap[2, 6]);
            Assert.Equal(1, hvd.OceanFloorMap[1, 3]);
            Assert.Equal(1, hvd.OceanFloorMap[3, 3]);
        }


        [Fact]
        public void Line_isHorizontalOrVertical()
        {
            Assert.True(new Line(2, 2, 2, 5).IsHorizontalOrVerticalLine());
            Assert.True(new Line(2, 5, 2, 2).IsHorizontalOrVerticalLine());

            Assert.True(new Line(2, 2, 5, 2).IsHorizontalOrVerticalLine());
            Assert.True(new Line(5, 2, 2, 2).IsHorizontalOrVerticalLine());

            Assert.False(new Line(1, 2, 2, 3).IsHorizontalOrVerticalLine());
            Assert.False(new Line(3, 3, 1, 2).IsHorizontalOrVerticalLine());
        }

    }
}
