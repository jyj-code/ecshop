using System;
namespace ShopNum1.QRCode.Codec.Reader.Pattern
{
	public class LogicalSeed
	{
		private static int[][] int_0;
		public static int[] getSeed(int version)
		{
			return LogicalSeed.int_0[version - 1];
		}
		public static int getSeed(int version, int patternNumber)
		{
			return LogicalSeed.int_0[version - 1][patternNumber];
		}
		static LogicalSeed()
		{
			LogicalSeed.int_0 = new int[40][];
			LogicalSeed.int_0[0] = new int[]
			{
				6,
				14
			};
			LogicalSeed.int_0[1] = new int[]
			{
				6,
				18
			};
			LogicalSeed.int_0[2] = new int[]
			{
				6,
				22
			};
			LogicalSeed.int_0[3] = new int[]
			{
				6,
				26
			};
			LogicalSeed.int_0[4] = new int[]
			{
				6,
				30
			};
			LogicalSeed.int_0[5] = new int[]
			{
				6,
				34
			};
			LogicalSeed.int_0[6] = new int[]
			{
				6,
				22,
				38
			};
			LogicalSeed.int_0[7] = new int[]
			{
				6,
				24,
				42
			};
			LogicalSeed.int_0[8] = new int[]
			{
				6,
				26,
				46
			};
			LogicalSeed.int_0[9] = new int[]
			{
				6,
				28,
				50
			};
			LogicalSeed.int_0[10] = new int[]
			{
				6,
				30,
				54
			};
			LogicalSeed.int_0[11] = new int[]
			{
				6,
				32,
				58
			};
			LogicalSeed.int_0[12] = new int[]
			{
				6,
				34,
				62
			};
			LogicalSeed.int_0[13] = new int[]
			{
				6,
				26,
				46,
				66
			};
			LogicalSeed.int_0[14] = new int[]
			{
				6,
				26,
				48,
				70
			};
			LogicalSeed.int_0[15] = new int[]
			{
				6,
				26,
				50,
				74
			};
			LogicalSeed.int_0[16] = new int[]
			{
				6,
				30,
				54,
				78
			};
			LogicalSeed.int_0[17] = new int[]
			{
				6,
				30,
				56,
				82
			};
			LogicalSeed.int_0[18] = new int[]
			{
				6,
				30,
				58,
				86
			};
			LogicalSeed.int_0[19] = new int[]
			{
				6,
				34,
				62,
				90
			};
			LogicalSeed.int_0[20] = new int[]
			{
				6,
				28,
				50,
				72,
				94
			};
			LogicalSeed.int_0[21] = new int[]
			{
				6,
				26,
				50,
				74,
				98
			};
			LogicalSeed.int_0[22] = new int[]
			{
				6,
				30,
				54,
				78,
				102
			};
			LogicalSeed.int_0[23] = new int[]
			{
				6,
				28,
				54,
				80,
				106
			};
			LogicalSeed.int_0[24] = new int[]
			{
				6,
				32,
				58,
				84,
				110
			};
			LogicalSeed.int_0[25] = new int[]
			{
				6,
				30,
				58,
				86,
				114
			};
			LogicalSeed.int_0[26] = new int[]
			{
				6,
				34,
				62,
				90,
				118
			};
			LogicalSeed.int_0[27] = new int[]
			{
				6,
				26,
				50,
				74,
				98,
				122
			};
			LogicalSeed.int_0[28] = new int[]
			{
				6,
				30,
				54,
				78,
				102,
				126
			};
			LogicalSeed.int_0[29] = new int[]
			{
				6,
				26,
				52,
				78,
				104,
				130
			};
			LogicalSeed.int_0[30] = new int[]
			{
				6,
				30,
				56,
				82,
				108,
				134
			};
			LogicalSeed.int_0[31] = new int[]
			{
				6,
				34,
				60,
				86,
				112,
				138
			};
			LogicalSeed.int_0[32] = new int[]
			{
				6,
				30,
				58,
				86,
				114,
				142
			};
			LogicalSeed.int_0[33] = new int[]
			{
				6,
				34,
				62,
				90,
				118,
				146
			};
			LogicalSeed.int_0[34] = new int[]
			{
				6,
				30,
				54,
				78,
				102,
				126,
				150
			};
			LogicalSeed.int_0[35] = new int[]
			{
				6,
				24,
				50,
				76,
				102,
				128,
				154
			};
			LogicalSeed.int_0[36] = new int[]
			{
				6,
				28,
				54,
				80,
				106,
				132,
				158
			};
			LogicalSeed.int_0[37] = new int[]
			{
				6,
				32,
				58,
				84,
				110,
				136,
				162
			};
			LogicalSeed.int_0[38] = new int[]
			{
				6,
				26,
				54,
				82,
				110,
				138,
				166
			};
			LogicalSeed.int_0[39] = new int[]
			{
				6,
				30,
				58,
				86,
				114,
				142,
				170
			};
		}
	}
}
