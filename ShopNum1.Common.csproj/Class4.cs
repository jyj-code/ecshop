using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
internal class Class4
{
	private long long_0;
	private long long_1;
	private long long_2;
	[DllImport("Kernel32.dll")]
	private static extern bool QueryPerformanceFrequency(out long long_3);
	[DllImport("Kernel32.dll")]
	private static extern bool QueryPerformanceCounter(out long long_3);
	public Class4(bool bool_0)
	{
		this.long_1 = 0L;
		this.long_2 = 0L;
		if (!Class4.QueryPerformanceFrequency(out this.long_0))
		{
			throw new Win32Exception();
		}
		if (bool_0)
		{
			this.method_1();
		}
	}
	public void method_0()
	{
		Class4.QueryPerformanceCounter(out this.long_2);
	}
	public void method_1()
	{
		Thread.Sleep(0);
		Class4.QueryPerformanceCounter(out this.long_1);
	}
	public double method_2()
	{
		return (double)(this.long_2 - this.long_1) / (double)this.long_0;
	}
}
