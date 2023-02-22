using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.ConnectClass
{
	public class Singleton<T> where T : class, new()
	{
		private static object _sysncobj = new object();
		private static volatile T _instance = null;
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_sysncobj)
					{
						if (_instance == null)
						{
							_instance = new T();
						}
					}
				}
				return _instance;
			}
		}

		public delegate void ExceptionEventHandler(string LocationID, Exception ex);
	}
}
