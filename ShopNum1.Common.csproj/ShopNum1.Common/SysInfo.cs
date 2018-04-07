using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
namespace ShopNum1.Common
{
	public class SysInfo
	{
		public abstract class CpuUsage
		{
			private static SysInfo.CpuUsage cpuUsage_0 = null;
			public static SysInfo.CpuUsage Create()
			{
				if (SysInfo.CpuUsage.cpuUsage_0 == null)
				{
					if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					{
						SysInfo.CpuUsage.cpuUsage_0 = new SysInfo.Class3();
					}
					else
					{
						if (Environment.OSVersion.Platform != PlatformID.Win32Windows)
						{
							throw new NotSupportedException();
						}
						SysInfo.CpuUsage.cpuUsage_0 = new SysInfo.Class2();
					}
				}
				return SysInfo.CpuUsage.cpuUsage_0;
			}
			public abstract int Query();
		}
		internal sealed class Class2 : SysInfo.CpuUsage
		{
			private RegistryKey registryKey_0;
			public Class2()
			{
				try
				{
					RegistryKey registryKey = Registry.DynData.OpenSubKey("PerfStats\\StartStat", false);
					if (registryKey == null)
					{
						throw new NotSupportedException();
					}
					registryKey.GetValue("KERNEL\\CPUUsage");
					registryKey.Close();
					this.registryKey_0 = Registry.DynData.OpenSubKey("PerfStats\\StatData", false);
					if (this.registryKey_0 == null)
					{
						throw new NotSupportedException();
					}
				}
				catch (NotSupportedException ex)
				{
					throw ex;
				}
				catch (Exception innerException)
				{
					throw new NotSupportedException("Error while querying the system information.", innerException);
				}
			}
			public override int Query()
			{
				int result;
				try
				{
					result = (int)this.registryKey_0.GetValue("KERNEL\\CPUUsage");
				}
				catch (Exception innerException)
				{
					throw new NotSupportedException("Error while querying the system information.", innerException);
				}
				return result;
			}
            //protected override void Finalize()
            //{
            //    try
            //    {
            //        try
            //        {
            //            this.registryKey_0.Close();
            //        }
            //        catch
            //        {
            //        }
            //        try
            //        {
            //            RegistryKey registryKey = Registry.DynData.OpenSubKey("PerfStats\\StopStat", false);
            //            registryKey.GetValue("KERNEL\\CPUUsage", false);
            //            registryKey.Close();
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    finally
            //    {
            //        base.Finalize();
            //    }
            //}
		}
		internal sealed class Class3 : SysInfo.CpuUsage
		{
			private const int int_0 = 0;
			private const int int_1 = 2;
			private const int int_2 = 3;
			private const int int_3 = 0;
			private long long_0;
			private long long_1;
			private double double_0;
			public Class3()
			{
				byte[] array = new byte[32];
				byte[] array2 = new byte[312];
				byte[] array3 = new byte[44];
				int num = SysInfo.Class3.NtQuerySystemInformation(3, array, array.Length, IntPtr.Zero);
				if (num != 0)
				{
					throw new NotSupportedException();
				}
				num = SysInfo.Class3.NtQuerySystemInformation(2, array2, array2.Length, IntPtr.Zero);
				if (num != 0)
				{
					throw new NotSupportedException();
				}
				num = SysInfo.Class3.NtQuerySystemInformation(0, array3, array3.Length, IntPtr.Zero);
				if (num != 0)
				{
					throw new NotSupportedException();
				}
				this.long_0 = BitConverter.ToInt64(array2, 0);
				this.long_1 = BitConverter.ToInt64(array, 8);
				this.double_0 = (double)array3[40];
			}
			public override int Query()
			{
				byte[] array = new byte[32];
				byte[] array2 = new byte[312];
				int num = SysInfo.Class3.NtQuerySystemInformation(3, array, array.Length, IntPtr.Zero);
				if (num != 0)
				{
					throw new NotSupportedException();
				}
				num = SysInfo.Class3.NtQuerySystemInformation(2, array2, array2.Length, IntPtr.Zero);
				if (num != 0)
				{
					throw new NotSupportedException();
				}
				double num2 = (double)(BitConverter.ToInt64(array2, 0) - this.long_0);
				double num3 = (double)(BitConverter.ToInt64(array, 8) - this.long_1);
				if (num3 != 0.0)
				{
					num2 /= num3;
				}
				num2 = 100.0 - num2 * 100.0 / this.double_0 + 0.5;
				this.long_0 = BitConverter.ToInt64(array2, 0);
				this.long_1 = BitConverter.ToInt64(array, 8);
				return (int)num2;
			}
			[DllImport("ntdll")]
			private static extern int NtQuerySystemInformation(int int_4, byte[] byte_0, int int_5, IntPtr intptr_0);
		}
		public static int GetCpuUsage()
		{
			return SysInfo.CpuUsage.Create().Query();
		}
	}
}
